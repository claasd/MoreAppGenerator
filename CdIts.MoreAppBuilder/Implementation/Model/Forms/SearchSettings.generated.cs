#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class SearchSettings : IEquatable<SearchSettings> {
        public const string SearchSettingsObjectName = "SearchSettings";
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("onlyForCurrentUser")]
        public bool? OnlyForCurrentUser { get; set; }

        [JsonProperty("fields")]
        public Dictionary<string, bool> Fields { get; set; }

        [JsonProperty("filteringEnabled")]
        public bool? FilteringEnabled { get; set; }

        [JsonProperty("filteredFields")]
        public ICollection<string> FilteredFields { get; set; }

        public SearchSettings(){}
        public SearchSettings(SearchSettings other) {
            Enabled = other.Enabled;
            OnlyForCurrentUser = other.OnlyForCurrentUser;
            Fields = other.Fields?.ToDictionary(entry => entry.Key, entry => entry.Value);
            FilteringEnabled = other.FilteringEnabled;
            FilteredFields = other.FilteredFields?.ToList();
        }
        public SearchSettings ToSearchSettings() => new SearchSettings(this);
        public bool Equals(SearchSettings other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Enabled == other.Enabled
                && OnlyForCurrentUser == other.OnlyForCurrentUser
                && (Fields?.SequenceEqual(other.Fields) ?? other.Fields is null)
                && FilteringEnabled == other.FilteringEnabled
                && (FilteredFields?.SequenceEqual(other.FilteredFields) ?? other.FilteredFields is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(SearchSettings other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as SearchSettings);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Enabled);
            hashCode.Add(OnlyForCurrentUser);
            hashCode.Add(Fields);
            hashCode.Add(FilteringEnabled);
            hashCode.Add(FilteredFields);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
