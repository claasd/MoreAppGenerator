using MoreAppBuilder.Implementation;

namespace MoreAppBuilder.Testing;

public class LocalTestingDataSource(string id, string name, List<string> columns, Dictionary<string, object> testData)
    : DataSource(id, name, columns)
{
    public Dictionary<string, object> Data => testData;
}