
namespace AsgardWebEngine.Data.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IImageRepository<TKey>
    {
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        byte[] Get(TKey key);
    }
}
