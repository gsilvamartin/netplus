using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NetDevExtensions.ServiceAbstractions.Database.NoSQL.MongoDB.Interfaces
{
    public interface IMongoRepository<T>
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter);
        Task<IEnumerable<T>> FindAsync(string filterJson);
        Task<IEnumerable<T>> FindAsync(FilterDefinitionBuilder<T> filterBuilder);
        Task<IEnumerable<T>> FindAsync(string propertyName, object value);
        Task<IEnumerable<T>> FindAsync(Dictionary<string, object> filters);

        Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, TProjection>> projection);

        Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            FilterDefinition<T> filter,
            ProjectionDefinition<T, TProjection> projection);

        Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            string filterJson,
            ProjectionDefinition<T, TProjection> projection);

        Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            FilterDefinitionBuilder<T> filterBuilder,
            ProjectionDefinition<T, TProjection> projection);

        Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            string propertyName,
            object value,
            ProjectionDefinition<T, TProjection> projection);

        Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
            Dictionary<string, object> filters,
            ProjectionDefinition<T, TProjection> projection);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<bool> AnyAsync(FilterDefinition<T> filter);
        Task<bool> AnyAsync(string filterJson);
        Task<bool> AnyAsync(FilterDefinitionBuilder<T> filterBuilder);
        Task<bool> AnyAsync(string propertyName, object value);
        Task<bool> AnyAsync(Dictionary<string, object> filters);
        Task<long> CountAsync(Expression<Func<T, bool>> filter);
        Task<long> CountAsync(FilterDefinition<T> filter);
        Task<long> CountAsync(string filterJson);
        Task<long> CountAsync(FilterDefinitionBuilder<T> filterBuilder);
        Task<long> CountAsync(string propertyName, object value);
        Task<long> CountAsync(Dictionary<string, object> filters);
        IQueryable<T> AsQueryable();
    }
}