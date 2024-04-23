using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class TaskPublishInfo {
        // enum values for "type"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeValue {
            [EnumMember(Value = "IMMEDIATE")] IMMEDIATE,
            [EnumMember(Value = "RELATIVE")] RELATIVE,
            [EnumMember(Value = "ABSOLUTE")] ABSOLUTE
        }
    }
}