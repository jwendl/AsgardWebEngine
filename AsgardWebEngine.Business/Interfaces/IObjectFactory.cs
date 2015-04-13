
namespace AsgardWebEngine.Business.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    public interface IObjectFactory<TBusinessObject, TKey>
        where TBusinessObject : IBusinessObject<TBusinessObject, TKey>, new()
    {
        /// <summary>
        /// Fetches the factory.
        /// </summary>
        /// <returns></returns>
        TBusinessObject FetchFactory();
    }
}
