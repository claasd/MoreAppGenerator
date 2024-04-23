using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class GoogleConfiguration {
        // enum values for "updateInterval"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UpdateIntervalValue {
            [EnumMember(Value = "QUARTER_HOUR")] QUARTER_HOUR,
            [EnumMember(Value = "HALF_HOUR")] HALF_HOUR,
            [EnumMember(Value = "HOURLY")] HOURLY,
            [EnumMember(Value = "DAILY")] DAILY,
            [EnumMember(Value = "WEEKLY")] WEEKLY,
            [EnumMember(Value = "NEVER")] NEVER
        }
    }
}