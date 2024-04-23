#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ThemeDto : IEquatable<ThemeDto> {
        public const string ThemeDtoObjectName = "ThemeDto";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("system")]
        public bool? System { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("colors")]
        public ThemeColors Colors { get; set; }

        [JsonProperty("defaultTheme")]
        public bool? DefaultTheme { get; set; }

        public ThemeDto(){}
        public ThemeDto(ThemeDto other) {
            Id = other.Id;
            System = other.System;
            Name = other.Name;
            Colors = other.Colors?.ToThemeColors();
            DefaultTheme = other.DefaultTheme;
        }
        public ThemeDto ToThemeDto() => new ThemeDto(this);
        public bool Equals(ThemeDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && System == other.System
                && Name == other.Name
                && (Colors?.Equals(other.Colors) ?? other.Colors is null)
                && DefaultTheme == other.DefaultTheme;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ThemeDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ThemeDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(System);
            hashCode.Add(Name);
            hashCode.Add(Colors);
            hashCode.Add(DefaultTheme);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
