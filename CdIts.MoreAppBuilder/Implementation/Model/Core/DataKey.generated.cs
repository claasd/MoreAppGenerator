#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class DataKey : IEquatable<DataKey> {
        public const string DataKeyObjectName = "DataKey";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        public DataKey(){}
        public DataKey(DataKey other) {
            Id = other.Id;
            Label = other.Label;
        }
        public DataKey ToDataKey() => new DataKey(this);
        public bool Equals(DataKey other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Label == other.Label;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(DataKey other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as DataKey);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Label);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
