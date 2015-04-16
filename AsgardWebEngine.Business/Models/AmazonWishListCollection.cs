using AsgardWebEngine.Data.Models;
using AsgardWebEngine.Data.Repositories.Interfaces;

namespace AsgardWebEngine.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AmazonWishListCollection
        : BaseMetadataObjectCollection<AmazonWishList, AmazonWishListEntity>
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
