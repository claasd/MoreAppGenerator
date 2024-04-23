using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class ExportRequest {
        // enum values for "exporterType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExporterTypeValue {
            [EnumMember(Value = "EXCEL")] EXCEL
        }
    }
}