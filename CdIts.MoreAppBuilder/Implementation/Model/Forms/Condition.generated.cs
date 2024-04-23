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
    public sealed  partial class Condition : IEquatable<Condition> {
        public const string ConditionObjectName = "Condition";
        [JsonProperty("type")]
        public TypeValue? Type { get; set; }

        [JsonProperty("fieldUid")]
        public string FieldUid { get; set; }

        [JsonProperty("fieldObjectKey")]
        public string FieldObjectKey { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public JToken? Value { get; set; }

        public Condition(){}
        public Condition(Condition other) {
            Type = other.Type == null ? null : (Condition.TypeValue)other.Type;
            FieldUid = other.FieldUid;
            FieldObjectKey = other.FieldObjectKey;
            Key = other.Key;
            Value = other.Value?.DeepClone();
        }
        public Condition ToCondition() => new Condition(this);
        public bool Equals(Condition other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Type == other.Type
                && FieldUid == other.FieldUid
                && FieldObjectKey == other.FieldObjectKey
                && Key == other.Key
                && (Value?.Equals(other.Value) ?? other.Value is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Condition other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Condition);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Type);
            hashCode.Add(FieldUid);
            hashCode.Add(FieldObjectKey);
            hashCode.Add(Key);
            hashCode.Add(Value);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
