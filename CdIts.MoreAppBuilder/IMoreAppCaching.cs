using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

public interface IMoreAppCaching
{
    ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash);
    ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash);
    ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id);
    Task StoreFolderIdAsync(int customerId, string name, string hash, string id);
}