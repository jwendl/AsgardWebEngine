using AsgardWebEngine.Common;
using AsgardWebEngine.Data.Interfaces;
using AsgardWebEngine.Data.Repositories.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AsgardWebEngine.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentRepository
        : IDocumentRepository
    {
        private CloudBlobClient cloudBlobClient { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentRepository"/> class.
        /// </summary>
        public DocumentRepository(IStorageAccountWrapper storageAccountWrapper)
        {
            Args.IsNotNull(() => storageAccountWrapper);

            cloudBlobClient = storageAccountWrapper.CreateCloudBlobClient();
            cloudBlobClient.DefaultRequestOptions.RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(45), 5);
        }

        /// <summary>
        /// Downloads the document.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="documentName">Name of the document.</param>
        /// <returns></returns>
        public async Task<string> DownloadDocumentAsync(string containerName, string documentName)
        {
            var cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            var cloudBlob = cloudBlobContainer.GetBlockBlobReference(documentName);

            return await cloudBlob.DownloadTextAsync();
        }

        /// <summary>
        /// Uploads the document asynchronous.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="documentName">Name of the document.</param>
        /// <param name="fileContents">The file contents.</param>
        /// <returns></returns>
        public async Task UploadDocumentAsync(string containerName, string documentName, string fileContents)
        {
            var cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            var cloudBlob = cloudBlobContainer.GetBlockBlobReference(documentName);

            var documentBytes = Encoding.UTF8.GetBytes(fileContents);
            await cloudBlob.UploadFromByteArrayAsync(documentBytes, 0, documentBytes.Length);
        }
    }
}
