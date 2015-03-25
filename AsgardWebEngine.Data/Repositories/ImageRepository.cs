using AsgardWebEngine.Data.Repositories.Interfaces;

namespace AsgardWebEngine.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public class ImageRepository<TKey>
        : IImageRepository<TKey>
    {
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public byte[] Get(TKey key)
        {
            return default(byte[]);
        }
    }
}
