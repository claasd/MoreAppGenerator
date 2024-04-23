using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestDataSource {
        // enum values for "lastUpdateType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LastUpdateTypeValue {
            [EnumMember(Value = "EXCEL")] EXCEL,
            [EnumMember(Value = "URL")] URL,
            [EnumMember(Value = "GOOGLE_SPREADSHEET")] GOOGLE_SPREADSHEET
        }
    }
}