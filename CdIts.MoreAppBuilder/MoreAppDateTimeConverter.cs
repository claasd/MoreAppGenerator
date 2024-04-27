using Newtonsoft.Json;

namespace MoreAppBuilder;

public class MoreAppDateTimeConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? ReadJson(JsonReader reader, Type objectType, DateTimeOffset? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return reader.Value switch
        {
            long value => DateTimeOffset.FromUnixTimeMilliseconds(value),
            string strValue when long.TryParse(strValue, out var parsedValue) => DateTimeOffset.FromUnixTimeMilliseconds(parsedValue),
            _ => null
        };
    }

    public override void WriteJson(JsonWriter writer, DateTimeOffset? value, JsonSerializer serializer)
    {
        if (value is null)
            writer.WriteNull();
        else
            writer.WriteValue(value.Value.ToUnixTimeMilliseconds());
    }
}