using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class FormDto {
        // enum values for "scope"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ScopeValue {
            [EnumMember(Value = "GLOBAL")] GLOBAL,
            [EnumMember(Value = "CUSTOMER")] CUSTOMER
        }
    }
}