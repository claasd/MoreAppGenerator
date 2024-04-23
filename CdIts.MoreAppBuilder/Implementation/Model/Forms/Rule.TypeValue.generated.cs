using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class Rule {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "AND")] AND,
            [EnumMember(Value = "OR")] OR
        }
    }
}