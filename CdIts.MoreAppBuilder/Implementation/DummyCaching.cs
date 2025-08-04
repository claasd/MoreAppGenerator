namespace MoreAppBuilder.Implementation;

internal class DummyCaching : IMoreAppCaching
{
    public ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash) => new((string?)null);

    public ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash) => new((string?)null);
    public ValueTask<IDataSource?> FindDataSourceByHashAsync(int customerId, string sourceName, string hash) => new((IDataSource?)null);
    public ValueTask<IDataSource?> FindLatestDataSourceAsync(int customerId, string name) => new((IDataSource?)null);

    public ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id) => ValueTask.CompletedTask;

    public ValueTask StoreFolderIdAsync(int customerId, string name, string hash, string id) => ValueTask.CompletedTask;
    public ValueTask StoreDataSourceAsync(int customerId, string hash, IDataSource dataSource) => ValueTask.CompletedTask;
}