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
    public sealed  partial class Field : IEquatable<Field> {
        public const string FieldObjectName = "Field";
        [JsonProperty("uid", Required = Required.Always)]
        public string Uid { get; set; }

        [JsonProperty("widget", Required = Required.Always)]
        public string Widget { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }

        public Field(){}
        public Field(Field other) {
            Uid = other.Uid;
            Widget = other.Widget;
            Properties = other.Properties?.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public Field ToField() => new Field(this);
        public bool Equals(Field other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Uid == other.Uid
                && Widget == other.Widget
                && (other.Properties is null ? Properties is null : Properties?.SequenceEqual(other.Properties) ?? other.Properties is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Field other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Field);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Uid);
            hashCode.Add(Widget);
            hashCode.Add(Properties);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
