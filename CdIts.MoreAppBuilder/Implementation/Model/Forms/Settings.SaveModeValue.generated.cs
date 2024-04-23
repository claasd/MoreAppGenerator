using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class Settings {
        // enum values for "saveMode"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SaveModeValue {
            [EnumMember(Value = "ALL")] ALL,
            [EnumMember(Value = "SAVE_AND_CLOSE_ONLY")] SAVE_AND_CLOSE_ONLY,
            [EnumMember(Value = "NO_SAVE")] NO_SAVE
        }
    }
}