﻿using AsgardWebEngine.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AsgardWebEngine.Data.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMetadataRepository<TEntity>
        where TEntity : class, ITableEntity, new()
    {
        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <returns></returns>
        Task<bool> CreateTableIfNotExistsAsync();

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        TEntity Add(TEntity item);

        /// <summary>
        /// Asynchronously adds an item to the context.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity item);

        /// <summary>
        /// Asynchronously removes an item from the context.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task RemoveAsync(TEntity item);

        /// <summary>
        /// Updates all.
        /// </summary>
        /// <param name="items">The items.</param>
        void UpdateAll(IEnumerable<TEntity> items);

        /// <summary>
        /// Asynchronously updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity item);

        /// <summary>
        /// Finds the specified item based on a predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Asynchronously queries for an item based on the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Asynchronously queries for an item based on the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Fetches all items from table storage.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> FetchAll();

        /// <summary>
        /// Fetches all items from table storage.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FetchAllAsync();

        /// <summary>
        /// Fetches the specified partition key.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="rowKey">The row key.</param>
        /// <returns></returns>
        TEntity Fetch(string partitionKey, string rowKey);

        /// <summary>
        /// Fetches the specified partition key.
        /// </summary>
        /// <param name="partitionKey">The partition key.</param>
        /// <param name="rowKey">The row key.</param>
        /// <returns></returns>
        Task<TEntity> FetchAsync(string partitionKey, string rowKey);
    }
}
