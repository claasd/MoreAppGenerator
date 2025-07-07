namespace MoreAppBuilder.Implementation;

internal class DummyCaching : IMoreAppCaching
{
    public ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash) => new((string?)null);

    public ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash) => new((string?)null);

    public ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id) =>
        ValueTask.CompletedTask;

    public Task StoreFolderIdAsync(int customerId, string name, string hash, string id) => Task.CompletedTask;
}