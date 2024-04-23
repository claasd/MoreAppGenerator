using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class FolderDto {
        // enum values for "status"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusValue {
            [EnumMember(Value = "ACTIVE")] ACTIVE,
            [EnumMember(Value = "HIDDEN")] HIDDEN,
            [EnumMember(Value = "UNKNOWN")] UNKNOWN
        }
    }
}