#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    /// <summary>
    /// Sort the results based on the given field
    /// </summary>
    public sealed  partial class SortProperty : IEquatable<SortProperty> {
        public const string SortPropertyObjectName = "SortProperty";
        [JsonProperty("key", Required = Required.Always)]
        public string Key { get; set; }

        [JsonProperty("direction", Required = Required.Always)]
        public int Direction { get; set; }

        public SortProperty(){}
        public SortProperty(SortProperty other) {
            Key = other.Key;
            Direction = other.Direction;
        }
        public SortProperty ToSortProperty() => new SortProperty(this);
        public bool Equals(SortProperty other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Key == other.Key
                && Direction == other.Direction;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(SortProperty other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as SortProperty);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Key);
            hashCode.Add(Direction);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
