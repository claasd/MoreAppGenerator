using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class UrlDataSourceBuilder : IUrlDataSourceBuilder
{
    private readonly RestClient _client;
    private readonly IMoreAppCaching _caching;
    internal RestCreateDataSource Source { get; private set; }
    internal UrlDataSourceBuilder(RestClient client, string name, string url, IMoreAppCaching caching)
    {
        _client = client;
        _caching = caching;
        Source = new RestCreateDataSource()
        {
            Name = name,
            UrlConfiguration = new RestUrlConfiguration()
            {
                Url = url,
                RequestHeaders = new Dictionary<string, string>(),
                Parameters = new Dictionary<string, string>()
            }
        };
    }

    public IUrlDataSourceBuilder Header(string key, string value)
    {
        Source.UrlConfiguration.RequestHeaders[key] = value;
        return this;
    }

    public IUrlDataSourceBuilder WeeklyUpdate()
    {
        Source.UrlConfiguration.UpdateInterval = RestUrlConfiguration.UpdateIntervalValue.WEEKLY;
        return this;
    }public IUrlDataSourceBuilder DailyUpdate()
    {
        Source.UrlConfiguration.UpdateInterval = RestUrlConfiguration.UpdateIntervalValue.DAILY;
        return this;
    }

    public IUrlDataSourceBuilder HourlyUpdate()
    {
        Source.UrlConfiguration.UpdateInterval = RestUrlConfiguration.UpdateIntervalValue.HOURLY;
        return this;
    }
    public IUrlDataSourceBuilder HalfHourlyUpdate()
    {
        Source.UrlConfiguration.UpdateInterval = RestUrlConfiguration.UpdateIntervalValue.HALF_HOUR;
        return this;
    }
    public IUrlDataSourceBuilder QuarterHourlyUpdate()
    {
        Source.UrlConfiguration.UpdateInterval = RestUrlConfiguration.UpdateIntervalValue.QUARTER_HOUR;
        return this;
    }

    internal string Hash() => Element.Hash(JsonConvert.SerializeObject(Source));

    public async Task<IDataSource> BuildAsync()
    {
        var hash = Hash();
        var cached = await _caching.FindDataSourceByHashAsync(_client.CustomerId, Source.Name, hash);
        if (cached != null)
            return cached;
        var client = new MoreAppDatasourcesClient( _client.HttpClient);
        var list = await client.GetAllAsync(_client.CustomerId);
        var current = list.FirstOrDefault(item => item.Name == Source.Name);
        if (current is null)
            current = await client.CreateAsync(_client.CustomerId, Source);
        else if(!current.UrlConfiguration.Equals(Source.UrlConfiguration))
            current = await client.UpdateAsync(_client.CustomerId, current.Id, Source);
        var result = new DataSource(current.Id, current.Name, current.ColumnMapping.Select(key=>key.Id).ToList());
        await _caching.StoreDataSourceAsync(_client.CustomerId, hash, result);
        return result;
    }
}
