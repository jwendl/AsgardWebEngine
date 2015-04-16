using AsgardWebEngine.Data.Interfaces;
using System;

namespace AsgardWebEngine.Data.Extensions
{
    /// <summary>
    /// A set of extension methods to help build partition keys and row keys.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Builds the partition key.
        /// </summary>
        /// <param name="tableEntity">The table entity.</param>
        /// <returns></returns>
        public static string BuildPartitionKey<TEntity>(this TEntity tableEntity, Func<TEntity, string> partitionKeyFunction)
            where TEntity : ITableEntity
        {
            return partitionKeyFunction(tableEntity);
        }

        /// <summary>
        /// Builds the row key.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="tableEntity">The table entity.</param>
        /// <param name="rowKeyFunction">The row key function.</param>
        /// <returns></returns>
        public static string BuildRowKey<TEntity>(this TEntity tableEntity, Func<TEntity, string> rowKeyFunction)
            where TEntity : ITableEntity
        {
            return rowKeyFunction(tableEntity);
        }
    }
}
