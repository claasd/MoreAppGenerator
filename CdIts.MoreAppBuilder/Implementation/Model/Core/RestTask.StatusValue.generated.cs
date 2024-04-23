using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestTask {
        // enum values for "status"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "IN_PROGRESS")] IN_PROGRESS,
            [EnumMember(Value = "COMPLETED")] COMPLETED,
            [EnumMember(Value = "REVOKED")] REVOKED,
            [EnumMember(Value = "DECLINED")] DECLINED
        }
    }
}