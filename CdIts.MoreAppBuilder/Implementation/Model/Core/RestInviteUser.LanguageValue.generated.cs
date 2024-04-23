using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestInviteUser {
        // enum values for "language"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageValue {
            [EnumMember(Value = "nl")] Nl,
            [EnumMember(Value = "en")] En,
            [EnumMember(Value = "es")] Es,
            [EnumMember(Value = "de")] De,
            [EnumMember(Value = "pt")] Pt,
            [EnumMember(Value = "fr")] Fr,
            [EnumMember(Value = "ca")] Ca
        }
    }
}