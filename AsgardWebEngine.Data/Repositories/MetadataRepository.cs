using AsgardWebEngine.Common;
using AsgardWebEngine.Data.Interfaces;
using AsgardWebEngine.Data.Repositories.Interfaces;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WindowsAzure.Table;
using WindowsAzure.Table.Extensions;

namespace AsgardWebEngine.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MetadataRepository<TEntity, TPartitionKey, TRowKey>
        : IMetadataRepository<TEntity, TPartitionKey, TRowKey>
        where TEntity : class, new()
    {
        private CloudTableClient cloudTableClient { get; set; }
        private TableSet<TEntity> tableSet { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataRepository{TEntity, TPartitionKey, TRowKey}" /> class.
        /// </summary>
        /// <param name="cloudStorageAccount">The cloud storage account.</param>
        public MetadataRepository(IStorageAccountWrapper storageAccountWrapper)
        {
            Args.IsNotNull(() => storageAccountWrapper);

            cloudTableClient = storageAccountWrapper.CreateCloudTableClient();
            cloudTableClient.DefaultRequestOptions.RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(45), 5);

            var cloudTableName = typeof(TEntity).Name.Replace("Entity", String.Empty);
            tableSet = new TableSet<TEntity>(cloudTableClient, cloudTableName);
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CreateTableIfNotExistsAsync()
        {
            var cloudTableName = typeof(TEntity).Name.Replace("Entity", String.Empty);
            var cloudTable = cloudTableClient.GetTableReference(cloudTableName);
            return await cloudTable.CreateIfNotExistsAsync();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public TEntity Add(TEntity item)
        {
            return tableSet.Add(item);
        }

        /// <summary>
        /// Asynchronously adds an item to the context.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(TEntity item)
        {
            return await tableSet.AddAsync(item);
        }

        /// <summary>
        /// Asynchronously removes an item from the context.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task RemoveAsync(TEntity item)
        {
            await tableSet.RemoveAsync(item);
        }

        /// <summary>
        /// Asynchronously updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            return await tableSet.UpdateAsync(item);
        }

        /// <summary>
        /// Finds the specified item based on a predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            Args.IsNotNull(() => predicate);

            return tableSet.Where(predicate)
                .SingleOrDefault();
        }

        /// <summary>
        /// Asynchronously queries for an item based on the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Args.IsNotNull(() => predicate);

            return await tableSet.Where(predicate)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Asynchronously queries for an item based on the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Args.IsNotNull(() => predicate);

            return await tableSet.Where(predicate)
                .ToListAsync();
        }

        /// <summary>
        /// Fetches all items from table storage.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> FetchAll()
        {
            return tableSet.ToList();
        }

        /// <summary>
        /// Fetches all items from table storage.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FetchAllAsync()
        {
            return await tableSet.ToListAsync();
        }
    }
}
