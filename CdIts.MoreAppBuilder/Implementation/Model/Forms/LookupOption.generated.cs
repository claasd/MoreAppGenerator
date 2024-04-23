#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class LookupOption : IEquatable<LookupOption> {
        public const string LookupOptionObjectName = "LookupOption";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public LookupOption(){}
        public LookupOption(LookupOption other) {
            Id = other.Id;
            Name = other.Name;
        }
        public LookupOption ToLookupOption() => new LookupOption(this);
        public bool Equals(LookupOption other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Name == other.Name;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(LookupOption other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as LookupOption);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
