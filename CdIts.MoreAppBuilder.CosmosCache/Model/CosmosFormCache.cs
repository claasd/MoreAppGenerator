using Newtonsoft.Json;

namespace MoreAppBuilder.Cache.Model;

public class CosmosFormCache
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CacheType
    {
        Form,
        Folder,
        DataSource,
        Group
    };

    [JsonProperty("id")] public Guid Id { get; set; } = Guid.NewGuid();
    public CacheType Type { get; set; }
    public int CustomerId { get; set; }
    public string FormName { get; set; } = string.Empty;
    public string ElementId { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
    public List<string> Columns { get; set; } = [];
    public DateTimeOffset Timestamp { get; set; }
    [JsonProperty("ttl")] public int TimeToLive { get; set; }
}

