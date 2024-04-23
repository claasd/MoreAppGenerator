#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Group : IEquatable<Group> {
        public const string GroupObjectName = "Group";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("grants")]
        public ICollection<Grant> Grants { get; set; }

        public Group(){}
        public Group(Group other) {
            Id = other.Id;
            Name = other.Name;
            Grants = other.Grants?.Select(value=>value?.ToGrant())?.ToList();
        }
        public Group ToGroup() => new Group(this);
        public bool Equals(Group other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Name == other.Name
                && (Grants?.SequenceEqual(other.Grants) ?? other.Grants is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Group other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Group);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(Grants);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
