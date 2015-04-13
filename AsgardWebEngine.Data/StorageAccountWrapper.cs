using AsgardWebEngine.Data.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace AsgardWebEngine.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageAccountWrapper
        : IStorageAccountWrapper
    {
        private CloudStorageAccount cloudStorageAccount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageAccountWrapper"/> class.
        /// </summary>
        public StorageAccountWrapper()
        {
            cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["TableStorageConnection"]);
        }

        /// <summary>
        /// Creates the cloud table client.
        /// </summary>
        /// <returns></returns>
        public CloudTableClient CreateCloudTableClient()
        {
            return cloudStorageAccount.CreateCloudTableClient();
        }

        /// <summary>
        /// Creates the cloud BLOB client.
        /// </summary>
        /// <returns></returns>
        public CloudBlobClient CreateCloudBlobClient()
        {
            return cloudStorageAccount.CreateCloudBlobClient();
        }
    }
}
