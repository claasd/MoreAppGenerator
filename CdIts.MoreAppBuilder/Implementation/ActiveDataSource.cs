using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;

namespace MoreAppBuilder.Implementation;

public class ActiveDataSource(string id, string name, List<string> columns)
    : DataSource(id, name, columns), IActiveDataSource
{
    public bool IsActive { get; private init; }
    public DateTimeOffset? LastUpdated { get; private init; }
    public DateTimeOffset? LastSuccessfulUpdate { get; private init; }
    public string[] ErrorMessages { get; private init; } = [];

    private static IActiveDataSource AsActiveDataSource(RestDataSource current) =>
        new ActiveDataSource(current.Id, current.Name, [.. current.ColumnMapping.Select(m => m.Id)])
        {
            IsActive = current.UpdateStatus == RestDataSource.UpdateStatusValue.SUCCESS,
            LastUpdated = current.LastUpdated,
            LastSuccessfulUpdate = current.LastSuccessfulUpdate,
            ErrorMessages = current.LastUpdateWarningMessages?.ToArray() ?? []
        };

    public static async Task<List<IActiveDataSource>> LoadAllAsync(RestClient client)
    {
        var dsClient = new MoreAppDatasourcesClient(client.HttpClient);
        var list = await dsClient.GetAllAsync(client.CustomerId);
        return list.Select(AsActiveDataSource).ToList();
    }
}