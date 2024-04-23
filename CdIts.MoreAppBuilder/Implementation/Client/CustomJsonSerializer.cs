using Caffoa.Defaults;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation.Client;

public class CustomJsonSerializer : DefaultCaffoaResultHandler
{
    public CustomJsonSerializer() : base(new JsonSerializerSettings()
    {
        NullValueHandling = NullValueHandling.Ignore
    })
    {
    }
}