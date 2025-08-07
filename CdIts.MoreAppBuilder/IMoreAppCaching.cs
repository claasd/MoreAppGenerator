using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

public interface IMoreAppCaching
{
    ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash);
    ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash);
    ValueTask<IDataSource?> FindDataSourceByHashAsync(int customerId, string sourceName, string hash);
    ValueTask<IDataSource?> FindLatestDataSourceAsync(int customerId, string name);
    ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id);
    ValueTask StoreFolderIdAsync(int customerId, string name, string hash, string id);
    ValueTask StoreDataSourceAsync(int customerId, string hash, IDataSource dataSource);
    ValueTask<string?> FindGroupIdAsync(int customerId, string name);
    ValueTask StoreGroupIdAsync(int customerId, string name, string id);
}