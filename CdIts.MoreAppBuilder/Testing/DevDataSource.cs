using MoreAppBuilder.Implementation;

namespace MoreAppBuilder.Debug;

public class DevDataSource(string id, string name, List<string> columns, Dictionary<string, object> testData)
    : DataSource(id, name, columns)
{
    public Dictionary<string, object> Data => testData;
}