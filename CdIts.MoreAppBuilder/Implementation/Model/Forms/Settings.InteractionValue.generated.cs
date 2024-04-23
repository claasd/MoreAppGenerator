using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class Settings {
        // enum values for "interaction"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InteractionValue {
            [EnumMember(Value = "IMMEDIATE_UPLOAD")] IMMEDIATE_UPLOAD,
            [EnumMember(Value = "MANUAL_UPLOAD")] MANUAL_UPLOAD
        }
    }
}