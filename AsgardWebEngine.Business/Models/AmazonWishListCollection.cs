using AsgardWebEngine.Data.Models;
using AsgardWebEngine.Data.Repositories.Interfaces;
using AsgardWebEngine.Framework.Models;

namespace AsgardWebEngine.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AmazonWishListCollection
        : BaseBusinessObjectCollection<AmazonWishList, AmazonWishListEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonWishListCollection"/> class.
        /// </summary>
        /// <param name="metadataRepository">The metadata repository.</param>
        public AmazonWishListCollection(IMetadataRepository<AmazonWishListEntity> metadataRepository)
            : base(metadataRepository)
        {

        }
    }
}
