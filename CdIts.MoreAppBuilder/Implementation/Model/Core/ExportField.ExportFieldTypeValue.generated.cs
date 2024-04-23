using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class ExportField {
        // enum values for "exportFieldType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ExportFieldTypeValue {
            [EnumMember(Value = "BOOLEAN")] BOOLEAN,
            [EnumMember(Value = "STRING")] STRING,
            [EnumMember(Value = "DATE_TIME")] DATE_TIME,
            [EnumMember(Value = "NUMBER")] NUMBER,
            [EnumMember(Value = "FILE")] FILE,
            [EnumMember(Value = "LIST")] LIST,
            [EnumMember(Value = "MAP")] MAP,
            [EnumMember(Value = "REFERENCE")] REFERENCE
        }
    }
}