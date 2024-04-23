#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FilterQuery : IEquatable<FilterQuery> {
        public const string FilterQueryObjectName = "FilterQuery";
        [JsonProperty("path", Required = Required.Always)]
        public string Path { get; set; }

        [JsonProperty("value", Required = Required.Always)]
        public JToken Value { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        public FilterQuery(){}
        public FilterQuery(FilterQuery other) {
            Path = other.Path;
            Value = other.Value?.DeepClone();
            Type = other.Type;
        }
        public FilterQuery ToFilterQuery() => new FilterQuery(this);
        public bool Equals(FilterQuery other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Path == other.Path
                && (Value?.Equals(other.Value) ?? other.Value is null)
                && Type == other.Type;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FilterQuery other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FilterQuery);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Path);
            hashCode.Add(Value);
            hashCode.Add(Type);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
