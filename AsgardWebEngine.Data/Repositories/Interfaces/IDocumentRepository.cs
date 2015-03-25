
namespace AsgardWebEngine.Data.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentRepository<TDocument, TKey>
        where TDocument : class
    {
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TDocument Get(TKey key);
    }
}
