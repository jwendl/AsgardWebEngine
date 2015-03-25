using WindowsAzure.Table.Attributes;

namespace AsgardWebEngine.Data.Models
{
    public class SteamWishListEntity
    {
        /// <summary>
        /// Gets or sets the partition key.
        /// </summary>
        /// <value>
        /// The partition key.
        /// </value>
        [PartitionKey]
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the row key.
        /// </summary>
        /// <value>
        /// The row key.
        /// </value>
        [RowKey]
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
