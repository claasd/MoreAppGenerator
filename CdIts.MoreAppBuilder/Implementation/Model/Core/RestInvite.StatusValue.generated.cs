using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestInvite {
        // enum values for "status"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "NEW_USER")] NEW_USER,
            [EnumMember(Value = "EXISTING_USER")] EXISTING_USER,
            [EnumMember(Value = "PENDING")] PENDING
        }
    }
}