using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class Dependency {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "DATASOURCE")] DATASOURCE,
            [EnumMember(Value = "RESOURCE")] RESOURCE,
            [EnumMember(Value = "URL")] URL,
            [EnumMember(Value = "SERVICE_ACCOUNT")] SERVICE_ACCOUNT
        }
    }
}