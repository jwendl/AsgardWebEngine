using AsgardWebEngine.Data.Interfaces;
using AsgardWebEngine.Data.Models;

namespace AsgardWebEngine.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class PostMetadataRepository
        : MetadataRepository<PostEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostMetadataRepository"/> class.
        /// </summary>
        /// <param name="storageAccountWrapper"></param>
        public PostMetadataRepository(IStorageAccountWrapper storageAccountWrapper)
            : base(storageAccountWrapper)
        {

        }
    }
}
