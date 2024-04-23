using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Forms {
    public partial class FormMetadataDto {
        // enum values for "iconColor"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IconColorValue {
            [EnumMember(Value = "Default")] Default,
            [EnumMember(Value = "Dark")] Dark,
            [EnumMember(Value = "Gold")] Gold,
            [EnumMember(Value = "Green")] Green,
            [EnumMember(Value = "Mauve")] Mauve,
            [EnumMember(Value = "Purple")] Purple,
            [EnumMember(Value = "Red")] Red,
            [EnumMember(Value = "White")] White
        }
    }
}