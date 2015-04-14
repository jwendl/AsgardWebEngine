using System.Threading.Tasks;

namespace AsgardWebEngine.Data.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Downloads the document asynchronous.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="documentName">Name of the document.</param>
        /// <returns></returns>
        Task<string> DownloadDocumentAsync(string containerName, string documentName);

        /// <summary>
        /// Uploads the document asynchronous.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="documentName">Name of the document.</param>
        /// <param name="fileContents">The file contents.</param>
        Task UploadDocumentAsync(string containerName, string documentName, string fileContents);
    }
}
