using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Webhooks {
    public partial class Subscriber {
        // enum values for "status"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "ACTIVE")] ACTIVE,
            [EnumMember(Value = "DISABLED")] DISABLED
        }
    }
}