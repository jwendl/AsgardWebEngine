using Microsoft.WindowsAzure.Storage.Table;

namespace AsgardWebEngine.Data.Interfaces
{
    public interface IStorageAccountWrapper
    {
        CloudTableClient CreateCloudTableClient();
    }
}
