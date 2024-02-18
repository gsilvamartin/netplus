using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace NetDevExtensions.ServiceAbstractions.Database.NoSQL.MongoDB.Interfaces;

/// <summary>
/// Interface for a generic MongoDB repository providing asynchronous operations for entity management.
/// </summary>
/// <typeparam name="T">The type of entities managed by the repository.</typeparam>
public interface IMongoRepository<T>
{
    /// <summary>
    /// Inserts a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task InsertAsync(T entity);

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to update.</param>
    /// <param name="entity">The updated entity.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(string id, T entity);

    /// <summary>
    /// Deletes an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(string id);

    /// <summary>
    /// Retrieves an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>A task representing the asynchronous operation and containing the retrieved entity.</returns>
    Task<T> GetByIdAsync(string id);

    /// <summary>
    /// Retrieves all entities in the collection asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation and containing a collection of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Finds entities matching the provided filter expression asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Finds entities matching the provided MongoDB filter definition asynchronously.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter);

    /// <summary>
    /// Finds entities matching the provided JSON filter expression asynchronously.
    /// </summary>
    /// <param name="filterJson">The JSON filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(string filterJson);

    /// <summary>
    /// Finds entities matching the provided MongoDB filter builder asynchronously.
    /// </summary>
    /// <param name="filterBuilder">The MongoDB filter builder.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(FilterDefinitionBuilder<T> filterBuilder);

    /// <summary>
    /// Finds entities matching a specific property and value asynchronously.
    /// </summary>
    /// <param name="propertyName">The name of the property to filter.</param>
    /// <param name="value">The value to match.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(string propertyName, object value);

    /// <summary>
    /// Finds entities matching a set of filters asynchronously.
    /// </summary>
    /// <param name="filters">A dictionary of property-value pairs to filter entities.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(Dictionary<string, object> filters);

    /// <summary>
    /// Finds entities and projects the result using a filter and projection expression asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projection result.</typeparam>
    /// <param name="filter">The filter expression.</param>
    /// <param name="projection">The projection expression.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of projected entities.</returns>
    Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
        Expression<Func<T, bool>> filter,
        Expression<Func<T, TProjection>> projection);

    /// <summary>
    /// Finds entities and projects the result using a filter and MongoDB projection definition asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projection result.</typeparam>
    /// <param name="filter">The MongoDB filter definition.</param>
    /// <param name="projection">The MongoDB projection definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of projected entities.</returns>
    Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
        FilterDefinition<T> filter,
        ProjectionDefinition<T, TProjection> projection);

    /// <summary>
    /// Finds entities and projects the result using a JSON filter and MongoDB projection definition asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projection result.</typeparam>
    /// <param name="filterJson">The JSON filter expression.</param>
    /// <param name="projection">The MongoDB projection definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of projected entities.</returns>
    Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
        string filterJson,
        ProjectionDefinition<T, TProjection> projection);

    /// <summary>
    /// Finds entities and projects the result using a filter builder and MongoDB projection definition asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projection result.</typeparam>
    /// <param name="filterBuilder">The MongoDB filter builder.</param>
    /// <param name="projection">The MongoDB projection definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of projected entities.</returns>
    Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
        FilterDefinitionBuilder<T> filterBuilder,
        ProjectionDefinition<T, TProjection> projection);

    /// <summary>
    /// Finds entities and projects the result using a specific property-value filter and MongoDB projection definition asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projection result.</typeparam>
    /// <param name="propertyName">The name of the property to filter.</param>
    /// <param name="value">The value to match.</param>
    /// <param name="projection">The MongoDB projection definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of projected entities.</returns>
    Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
        string propertyName,
        object value,
        ProjectionDefinition<T, TProjection> projection);

    /// <summary>
    /// Finds entities and projects the result using a set of filters and MongoDB projection definition asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projection result.</typeparam>
    /// <param name="filters">A dictionary of property-value pairs to filter entities.</param>
    /// <param name="projection">The MongoDB projection definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of projected entities.</returns>
    Task<IEnumerable<TProjection>> FindProjectionAsync<TProjection>(
        Dictionary<string, object> filters,
        ProjectionDefinition<T, TProjection> projection);

    /// <summary>
    /// Checks if any entities match the provided filter expression asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities match the filter.</returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Checks if any entities match the provided MongoDB filter definition asynchronously.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities match the filter.</returns>
    Task<bool> AnyAsync(FilterDefinition<T> filter);

    /// <summary>
    /// Checks if any entities match the provided JSON filter expression asynchronously.
    /// </summary>
    /// <param name="filterJson">The JSON filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities match the filter.</returns>
    Task<bool> AnyAsync(string filterJson);

    /// <summary>
    /// Checks if any entities match the provided MongoDB filter builder asynchronously.
    /// </summary>
    /// <param name="filterBuilder">The MongoDB filter builder.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities match the filter.</returns>
    Task<bool> AnyAsync(FilterDefinitionBuilder<T> filterBuilder);

    /// <summary>
    /// Checks if any entities match a specific property and value asynchronously.
    /// </summary>
    /// <param name="propertyName">The name of the property to filter.</param>
    /// <param name="value">The value to match.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities match the filter.</returns>
    Task<bool> AnyAsync(string propertyName, object value);

    /// <summary>
    /// Checks if any entities match a set of filters asynchronously.
    /// </summary>
    /// <param name="filters">A dictionary of property-value pairs to filter entities.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities match the filter.</returns>
    Task<bool> AnyAsync(Dictionary<string, object> filters);

    /// <summary>
    /// Counts the number of entities matching the provided filter expression asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of matching entities.</returns>
    Task<long> CountAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Counts the number of entities matching the provided MongoDB filter definition asynchronously.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of matching entities.</returns>
    Task<long> CountAsync(FilterDefinition<T> filter);

    /// <summary>
    /// Counts the number of entities matching the provided JSON filter expression asynchronously.
    /// </summary>
    /// <param name="filterJson">The JSON filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of matching entities.</returns>
    Task<long> CountAsync(string filterJson);

    /// <summary>
    /// Counts the number of entities matching the provided MongoDB filter builder asynchronously.
    /// </summary>
    /// <param name="filterBuilder">The MongoDB filter builder.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of matching entities.</returns>
    Task<long> CountAsync(FilterDefinitionBuilder<T> filterBuilder);

    /// <summary>
    /// Counts the number of entities matching a specific property and value asynchronously.
    /// </summary>
    /// <param name="propertyName">The name of the property to filter.</param>
    /// <param name="value">The value to match.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of matching entities.</returns>
    Task<long> CountAsync(string propertyName, object value);

    /// <summary>
    /// Counts the number of entities matching a set of filters asynchronously.
    /// </summary>
    /// <param name="filters">A dictionary of property-value pairs to filter entities.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of matching entities.</returns>
    Task<long> CountAsync(Dictionary<string, object> filters);

    /// <summary>
    /// Counts all entities in the repository asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation and containing the count of entities.</returns>
    Task<long> CountAsync();

    /// <summary>
    /// Checks if any entities exist in the repository asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities exist.</returns>
    Task<bool> AnyAsync();

    /// <summary>
    /// Sorts all entities in ascending or descending order based on the specified key selector asynchronously.
    /// </summary>
    /// <param name="keySelector">The key selector for sorting.</param>
    /// <param name="ascending">True for ascending order, false for descending order.</param>
    /// <returns>A task representing the asynchronous operation and containing the sorted entities.</returns>
    Task<IEnumerable<T>> SortByAsync(Expression<Func<T, object>> keySelector, bool ascending = true);

    /// <summary>
    /// Sorts all entities based on the provided sort definition asynchronously.
    /// </summary>
    /// <param name="sortDefinition">The sort definition.</param>
    /// <returns>A task representing the asynchronous operation and containing the sorted entities.</returns>
    Task<IEnumerable<T>> SortByAsync(SortDefinition<T> sortDefinition);

    /// <summary>
    /// Retrieves a paginated subset of entities from the repository asynchronously.
    /// </summary>
    /// <param name="page">The page number (1-based).</param>
    /// <param name="pageSize">The number of entities per page.</param>
    /// <returns>A task representing the asynchronous operation and containing the paginated entities.</returns>
    Task<IEnumerable<T>> PaginateAsync(int page, int pageSize);

    /// <summary>
    /// Retrieves a paginated subset of entities from the repository based on the provided filter asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <param name="page">The page number (1-based).</param>
    /// <param name="pageSize">The number of entities per page.</param>
    /// <returns>A task representing the asynchronous operation and containing the paginated entities.</returns>
    Task<IEnumerable<T>> PaginateAsync(Expression<Func<T, bool>> filter, int page, int pageSize);

    /// <summary>
    /// Retrieves a paginated subset of entities from the repository based on the provided sort definition asynchronously.
    /// </summary>
    /// <param name="sortDefinition">The sort definition.</param>
    /// <param name="page">The page number (1-based).</param>
    /// <param name="pageSize">The number of entities per page.</param>
    /// <returns>A task representing the asynchronous operation and containing the paginated entities.</returns>
    Task<IEnumerable<T>> PaginateAsync(SortDefinition<T> sortDefinition, int page, int pageSize);

    /// <summary>
    /// Retrieves a paginated subset of entities from the repository based on the provided filter and sort definition asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <param name="sortDefinition">The sort definition.</param>
    /// <param name="page">The page number (1-based).</param>
    /// <param name="pageSize">The number of entities per page.</param>
    /// <returns>A task representing the asynchronous operation and containing the paginated entities.</returns>
    Task<IEnumerable<T>> PaginateAsync(Expression<Func<T, bool>> filter, SortDefinition<T> sortDefinition, int page,
        int pageSize);

    /// <summary>
    /// Updates a document partially by applying the provided update definition asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the document to update.</param>
    /// <param name="updateDefinition">The update definition.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the update was successful.</returns>
    Task<bool> UpdatePartialAsync(string id, UpdateDefinition<T> updateDefinition);

    /// <summary>
    /// Performs an aggregation and counts the resulting entities asynchronously.
    /// </summary>
    /// <param name="pipeline">The aggregation pipeline.</param>
    /// <returns>A task representing the asynchronous operation and containing the count of resulting entities.</returns>
    Task<long> AggregateCountAsync(PipelineDefinition<T, T> pipeline);

    /// <summary>
    /// Performs an aggregation and retrieves the resulting entities asynchronously.
    /// </summary>
    /// <typeparam name="TResult">The type of the result entities.</typeparam>
    /// <param name="pipeline">The aggregation pipeline.</param>
    /// <returns>A task representing the asynchronous operation and containing the resulting entities.</returns>
    Task<IEnumerable<TResult>> AggregateAsync<TResult>(PipelineDefinition<T, TResult> pipeline);

    /// <summary>
    /// Deletes multiple entities based on the provided filter asynchronously.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if any entities were deleted.</returns>
    Task<bool> DeleteManyAsync(Expression<Func<T, bool>> filter);

    /// <summary>
    /// Projects the entities using the provided projection definition asynchronously.
    /// </summary>
    /// <typeparam name="TProjection">The type of the projected entities.</typeparam>
    /// <param name="projection">The projection definition.</param>
    /// <returns>A task representing the asynchronous operation and containing the projected entities.</returns>
    Task<IEnumerable<T>> ProjectAsync<TProjection>(ProjectionDefinition<T, TProjection> projection);

    /// <summary>
    /// Gets an <see cref="IQueryable{T}"/> for querying entities.
    /// </summary>
    /// <returns>The queryable interface for entities in the repository.</returns>
    IQueryable<T> AsQueryable();

    /// <summary>
    /// Gets an <see cref="IMongoQueryable"/> for querying entities.
    /// </summary>
    /// <returns>The MongoDB queryable interface for entities in the repository.</returns>
    IMongoQueryable<T> AsMongoQueryable();
}