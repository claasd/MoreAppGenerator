using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class Condition {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "FIELD")] FIELD,
            [EnumMember(Value = "USER")] USER,
            [EnumMember(Value = "FIELD_DATA_SOURCE")] FIELD_DATA_SOURCE
        }
    }
}