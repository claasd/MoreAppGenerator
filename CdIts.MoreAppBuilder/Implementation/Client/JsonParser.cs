using Caffoa;
using Caffoa.Defaults;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation.Client;

public class JsonParser : DefaultCaffoaJsonParser
{
    public JsonParser() : base(new ParseErrorHandler(), new JsonSerializerSettings()
    {
        Converters = new List<JsonConverter>()
        {
            new UnixMilliesDateTimeConverter()
        }
    })
    {
    }


}