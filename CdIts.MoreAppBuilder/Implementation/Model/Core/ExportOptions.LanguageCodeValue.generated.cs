using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class ExportOptions {
        // enum values for "languageCode"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LanguageCodeValue {
            [EnumMember(Value = "NL")] NL,
            [EnumMember(Value = "EN")] EN,
            [EnumMember(Value = "ES")] ES,
            [EnumMember(Value = "DE")] DE,
            [EnumMember(Value = "PT")] PT,
            [EnumMember(Value = "RU")] RU,
            [EnumMember(Value = "FR")] FR,
            [EnumMember(Value = "IT")] IT
        }
    }
}