using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestCustomerSettings {
        // enum values for "dateFormat"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DateFormatValue {
            [EnumMember(Value = "DDMMYYYY")] DDMMYYYY,
            [EnumMember(Value = "YYYYMMDD")] YYYYMMDD,
            [EnumMember(Value = "MMDDYYYY")] MMDDYYYY
        }
    }
}