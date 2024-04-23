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
    public sealed  partial class SearchDataSource : IEquatable<SearchDataSource> {
        public const string SearchDataSourceObjectName = "SearchDataSource";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mapping")]
        public Dictionary<string, bool> Mapping { get; set; }

        public SearchDataSource(){}
        public SearchDataSource(SearchDataSource other) {
            Id = other.Id;
            Mapping = other.Mapping?.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public SearchDataSource ToSearchDataSource() => new SearchDataSource(this);
        public bool Equals(SearchDataSource other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && (Mapping?.SequenceEqual(other.Mapping) ?? other.Mapping is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(SearchDataSource other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as SearchDataSource);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Mapping);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
