
namespace AsgardWebEngine.Data.Repositories.Interfaces
{
    public interface ISearchRepository<TMetadata>
        where TMetadata : class
    {
        void AddIndex(TMetadata metadata);
    }
}
