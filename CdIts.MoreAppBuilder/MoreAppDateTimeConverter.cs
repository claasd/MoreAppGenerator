using Newtonsoft.Json;

namespace MoreAppBuilder;

public class MoreAppDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return reader.Value switch
            {
                long value => DateTimeOffset.FromUnixTimeMilliseconds(value),
                string strValue when long.TryParse(strValue, out var parsedValue) => DateTimeOffset.FromUnixTimeMilliseconds(parsedValue),
                _ => null
            };
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
}