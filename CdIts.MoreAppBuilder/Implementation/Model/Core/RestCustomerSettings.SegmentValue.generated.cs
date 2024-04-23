using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestCustomerSettings {
        // enum values for "segment"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SegmentValue {
            [EnumMember(Value = "OTHER")] OTHER,
            [EnumMember(Value = "AUTOMOTIVE")] AUTOMOTIVE,
            [EnumMember(Value = "CONSTRUCTION")] CONSTRUCTION,
            [EnumMember(Value = "FACILITY")] FACILITY,
            [EnumMember(Value = "FINANCIAL")] FINANCIAL,
            [EnumMember(Value = "TRADE_AND_INDUSTRY")] TRADE_AND_INDUSTRY,
            [EnumMember(Value = "GOVERNMENT")] GOVERNMENT,
            [EnumMember(Value = "HEALTH_CARE")] HEALTH_CARE,
            [EnumMember(Value = "INSTALLATION")] INSTALLATION
        }
    }
}