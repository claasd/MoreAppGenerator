using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation.Model.Core;

public partial class Role
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("translatableKey")]
    public string TranslatableKey { get; set; }
}