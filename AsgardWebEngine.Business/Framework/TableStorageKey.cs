
namespace AsgardWebEngine.Business.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class TableStorageKey
    {
        /// <summary>
        /// Gets or sets the partition key.
        /// </summary>
        /// <value>
        /// The partition key.
        /// </value>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the row key.
        /// </summary>
        /// <value>
        /// The row key.
        /// </value>
        public string RowKey { get; set; }
    }
}
