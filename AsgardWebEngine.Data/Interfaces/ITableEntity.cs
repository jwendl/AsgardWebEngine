using WindowsAzure.Table.Attributes;

namespace AsgardWebEngine.Data.Interfaces
{
    public interface ITableEntity
    {
        /// <summary>
        /// Gets or sets the partition key.
        /// </summary>
        /// <value>
        /// The partition key.
        /// </value>
        [PartitionKey]
        string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the row key.
        /// </summary>
        /// <value>
        /// The row key.
        /// </value>
        [RowKey]
        string RowKey { get; set; }
    }
}
