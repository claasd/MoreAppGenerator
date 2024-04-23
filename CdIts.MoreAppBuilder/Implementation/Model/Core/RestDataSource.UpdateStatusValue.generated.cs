using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestDataSource {
        // enum values for "updateStatus"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpdateStatusValue {
            [EnumMember(Value = "SUCCESS")] SUCCESS,
            [EnumMember(Value = "NEVER")] NEVER,
            [EnumMember(Value = "FAILURE")] FAILURE
        }
    }
}