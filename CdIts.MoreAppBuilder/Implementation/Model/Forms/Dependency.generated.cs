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
    public sealed  partial class Dependency : IEquatable<Dependency> {
        public const string DependencyObjectName = "Dependency";
        [JsonProperty("type")]
        public TypeValue? Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        public Dependency(){}
        public Dependency(Dependency other) {
            Type = other.Type == null ? null : (Dependency.TypeValue)other.Type;
            Value = other.Value;
        }
        public Dependency ToDependency() => new Dependency(this);
        public bool Equals(Dependency other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Type == other.Type
                && Value == other.Value;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Dependency other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Dependency);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Type);
            hashCode.Add(Value);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
