using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Connection;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Entity;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Interfaces;

namespace NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB
{
    /// <summary>
    /// Represents a generic MongoDB repository.
    /// </summary>
    /// <typeparam name="T">Type of the entity</typeparam>
    /// <inheritdoc/>
    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(Action<MongoDbConfiguration> configure)
        {
            var config = new MongoDbConfiguration();
            configure.Invoke(config);

            if (string.IsNullOrEmpty(config.ConnectionString))
                throw new ArgumentException("ConnectionString cannot be null or empty",
                    nameof(config.ConnectionString));

            if (string.IsNullOrEmpty(config.DatabaseName))
                throw new ArgumentException("DatabaseName cannot be null or empty", nameof(config.DatabaseName));

            var client = new MongoClient(config.ConnectionString);
            var database = client.GetDatabase(config.DatabaseName);

            _collection = database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(string filterJson)
        {
            var filter = BsonSerializer.Deserialize<FilterDefinition<T>>(filterJson);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(FilterDefinitionBuilder<T> filterBuilder)
        {
            var filter = filterBuilder.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(string propertyName, object value)
        {
            var filter = Builders<T>.Filter.Eq(propertyName, value);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Dictionary<string, object> filters)
        {
            var filterBuilder = Builders<T>.Filter;
            var filter = filters.Aggregate(filterBuilder.Empty,
                (current, kvp) => current & filterBuilder.Eq(kvp.Key, kvp.Value));

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TProjection>> projection)
        {
            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(FilterDefinition<T> filter,
            ProjectionDefinition<T, TProjection> projection)
        {
            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(string filterJson,
            ProjectionDefinition<T, TProjection> projection)
        {
            var filter = BsonSerializer.Deserialize<FilterDefinition<T>>(filterJson);
            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            FilterDefinitionBuilder<T> filterBuilder, ProjectionDefinition<T, TProjection> projection)
        {
            var filter = filterBuilder.Empty;
            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(string propertyName, object value,
            ProjectionDefinition<T, TProjection> projection)
        {
            var filter = Builders<T>.Filter.Eq(propertyName, value);
            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(Dictionary<string, object> filters,
            ProjectionDefinition<T, TProjection> projection)
        {
            var filterBuilder = Builders<T>.Filter;
            var filter = filters.Aggregate(filterBuilder.Empty,
                (current, kvp) => current & filterBuilder.Eq(kvp.Key, kvp.Value));

            return await _collection.Find(filter).Project(projection).ToListAsync();
        }

        public async Task<long> CountAsync()
        {
            return await _collection.CountDocumentsAsync(_ => true);
        }

        public async Task<bool> AnyAsync(Dictionary<string, object> filters)
        {
            var filterBuilder = Builders<T>.Filter;
            var filter = filters.Aggregate(filterBuilder.Empty,
                (current, kvp) => current & filterBuilder.Eq(kvp.Key, kvp.Value));

            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.CountDocumentsAsync(filter);
        }

        public async Task<long> CountAsync(FilterDefinition<T> filter)
        {
            return await _collection.CountDocumentsAsync(filter);
        }

        public async Task<long> CountAsync(string filterJson)
        {
            var filter = BsonSerializer.Deserialize<FilterDefinition<T>>(filterJson);
            return await _collection.CountDocumentsAsync(filter);
        }

        public async Task<long> CountAsync(FilterDefinitionBuilder<T> filterBuilder)
        {
            var filter = filterBuilder.Empty;
            return await _collection.CountDocumentsAsync(filter);
        }

        public async Task<long> CountAsync(string propertyName, object value)
        {
            var filter = Builders<T>.Filter.Eq(propertyName, value);
            return await _collection.CountDocumentsAsync(filter);
        }

        public async Task<long> CountAsync(Dictionary<string, object> filters)
        {
            var filterBuilder = Builders<T>.Filter;
            var filter = filters.Aggregate(filterBuilder.Empty,
                (current, kvp) => current & filterBuilder.Eq(kvp.Key, kvp.Value));

            return await _collection.CountDocumentsAsync(filter);
        }

        public async Task<bool> AnyAsync()
        {
            return await _collection.Find(_ => true).AnyAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<bool> AnyAsync(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<bool> AnyAsync(string filterJson)
        {
            var filter = BsonSerializer.Deserialize<FilterDefinition<T>>(filterJson);
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<bool> AnyAsync(FilterDefinitionBuilder<T> filterBuilder)
        {
            var filter = filterBuilder.Empty;
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<bool> AnyAsync(string propertyName, object value)
        {
            var filter = Builders<T>.Filter.Eq(propertyName, value);
            return await _collection.Find(filter).AnyAsync();
        }

        public async Task<IEnumerable<T>> SortByAsync(Expression<Func<T, object>> keySelector, bool ascending = true)
        {
            var sortDefinition = ascending
                ? Builders<T>.Sort.Ascending(keySelector)
                : Builders<T>.Sort.Descending(keySelector);

            return await _collection.Find(_ => true).Sort(sortDefinition).ToListAsync();
        }

        public async Task<IEnumerable<T>> SortByAsync(SortDefinition<T> sortDefinition)
        {
            return await _collection.Find(_ => true).Sort(sortDefinition).ToListAsync();
        }

        public async Task<IEnumerable<T>> PaginateAsync(int page, int pageSize)
        {
            return await _collection.Find(_ => true).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<T>> PaginateAsync(Expression<Func<T, bool>> filter, int page, int pageSize)
        {
            return await _collection.Find(filter).Skip((page - 1) * pageSize).Limit(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<T>> PaginateAsync(SortDefinition<T> sortDefinition, int page, int pageSize)
        {
            return await _collection.Find(_ => true).Sort(sortDefinition).Skip((page - 1) * pageSize).Limit(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> PaginateAsync(Expression<Func<T, bool>> filter,
            SortDefinition<T> sortDefinition, int page, int pageSize)
        {
            return await _collection.Find(filter).Sort(sortDefinition).Skip((page - 1) * pageSize).Limit(pageSize)
                .ToListAsync();
        }

        public async Task<bool> UpdatePartialAsync(string id, UpdateDefinition<T> updateDefinition)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var result = await _collection.UpdateOneAsync(filter, updateDefinition);
            return result.ModifiedCount > 0;
        }

        public async Task<long> AggregateCountAsync(PipelineDefinition<T, T> pipeline)
        {
            var results = await _collection.Aggregate(pipeline).ToListAsync();
            return results.Count;
        }

        public async Task<IEnumerable<TResult>> AggregateAsync<TResult>(PipelineDefinition<T, TResult> pipeline)
        {
            return await _collection.Aggregate(pipeline).ToListAsync();
        }


        public async Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filter)
        {
            var result = await _collection.DeleteManyAsync(filter);
            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<T>> ProjectAsync<TProjection>(ProjectionDefinition<T, TProjection> projection)
        {
            return (IEnumerable<T>)await _collection.Find(_ => true).Project(projection).ToListAsync();
        }

        public IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public IMongoQueryable<T> AsMongoQueryable()
        {
            return _collection.AsQueryable();
        }
    }
}