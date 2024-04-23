#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ThemeColors : IEquatable<ThemeColors> {
        public const string ThemeColorsObjectName = "ThemeColors";
        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("button")]
        public string Button { get; set; }

        [JsonProperty("saveButton")]
        public string SaveButton { get; set; }

        [JsonProperty("widget")]
        public string Widget { get; set; }

        [JsonProperty("bar")]
        public string Bar { get; set; }

        public ThemeColors(){}
        public ThemeColors(ThemeColors other) {
            Background = other.Background;
            Button = other.Button;
            SaveButton = other.SaveButton;
            Widget = other.Widget;
            Bar = other.Bar;
        }
        public ThemeColors ToThemeColors() => new ThemeColors(this);
        public bool Equals(ThemeColors other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Background == other.Background
                && Button == other.Button
                && SaveButton == other.SaveButton
                && Widget == other.Widget
                && Bar == other.Bar;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ThemeColors other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ThemeColors);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Background);
            hashCode.Add(Button);
            hashCode.Add(SaveButton);
            hashCode.Add(Widget);
            hashCode.Add(Bar);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
