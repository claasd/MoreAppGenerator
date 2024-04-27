using Newtonsoft.Json;

namespace MoreAppBuilder;

public class MoreAppDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value as long?;
            if (value.HasValue)
                return DateTimeOffset.FromUnixTimeMilliseconds(value.Value);
            return null;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
}