using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace AsgardWebEngine.Data.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStorageAccountWrapper
    {
        /// <summary>
        /// Creates the cloud table client.
        /// </summary>
        /// <returns></returns>
        CloudTableClient CreateCloudTableClient();

        /// <summary>
        /// Creates the cloud BLOB client.
        /// </summary>
        /// <returns></returns>
        CloudBlobClient CreateCloudBlobClient();
    }
}
