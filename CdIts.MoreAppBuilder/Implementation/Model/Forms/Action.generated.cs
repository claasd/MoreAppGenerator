#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Action : IEquatable<Action> {
        public const string ActionObjectName = "Action";
        [JsonProperty("fieldUid")]
        public string FieldUid { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public JToken? Value { get; set; }

        public Action(){}
        public Action(Action other) {
            FieldUid = other.FieldUid;
            Key = other.Key;
            Value = other.Value?.DeepClone();
        }
        public Action ToAction() => new Action(this);
        public bool Equals(Action other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = FieldUid == other.FieldUid
                && Key == other.Key
                && (Value?.Equals(other.Value) ?? other.Value is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Action other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Action);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(FieldUid);
            hashCode.Add(Key);
            hashCode.Add(Value);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
