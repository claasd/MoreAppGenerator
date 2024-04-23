#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Settings : IEquatable<Settings> {
        public const string SettingsObjectName = "Settings";
        [JsonProperty("interaction")]
        public InteractionValue? Interaction { get; set; }

        [JsonProperty("saveMode")]
        public SaveModeValue? SaveMode { get; set; }

        [JsonProperty("searchSettings")]
        public SearchSettings SearchSettings { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("itemHtml")]
        public string ItemHtml { get; set; }

        public Settings(){}
        public Settings(Settings other) {
            Interaction = other.Interaction == null ? null : (Settings.InteractionValue)other.Interaction;
            SaveMode = other.SaveMode == null ? null : (Settings.SaveModeValue)other.SaveMode;
            SearchSettings = other.SearchSettings?.ToSearchSettings();
            Icon = other.Icon;
            ItemHtml = other.ItemHtml;
        }
        public Settings ToSettings() => new Settings(this);
        public bool Equals(Settings other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Interaction == other.Interaction
                && SaveMode == other.SaveMode
                && (SearchSettings?.Equals(other.SearchSettings) ?? other.SearchSettings is null)
                && Icon == other.Icon
                && ItemHtml == other.ItemHtml;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Settings other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Settings);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Interaction);
            hashCode.Add((int) SaveMode);
            hashCode.Add(SearchSettings);
            hashCode.Add(Icon);
            hashCode.Add(ItemHtml);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
