namespace MoreAppBuilder.Testing;

public class LocalTestingUrlDataSource(string name, string url, Dictionary<string, object> testData) : IUrlDataSourceBuilder
{ 
    public Task<IDataSource> BuildAsync() => Task.FromResult<IDataSource>(new LocalTestingDataSource(Id, name, testData.Keys.ToList(), testData));
    public IUrlDataSourceBuilder Header(string key, string value) => this;
    public IUrlDataSourceBuilder DailyUpdate() => this;
    public IUrlDataSourceBuilder HourlyUpdate() => this;
    public string Id { get; } = Guid.NewGuid().ToString("N");
 
}