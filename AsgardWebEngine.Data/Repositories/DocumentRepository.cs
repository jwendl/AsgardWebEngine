using AsgardWebEngine.Data.Repositories.Interfaces;

namespace AsgardWebEngine.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentRepository<TDocument, TKey>
        : IDocumentRepository<TDocument, TKey>
        where TDocument : class
    {
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TDocument Get(TKey key)
        {
            return default(TDocument);
        }
    }
}
