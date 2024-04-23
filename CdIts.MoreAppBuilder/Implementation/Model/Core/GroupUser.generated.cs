#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class GroupUser : IEquatable<GroupUser> {
        public const string GroupUserObjectName = "GroupUser";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("externallyManaged")]
        public bool? ExternallyManaged { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        public GroupUser(){}
        public GroupUser(GroupUser other) {
            Id = other.Id;
            Username = other.Username;
            FirstName = other.FirstName;
            LastName = other.LastName;
            ExternallyManaged = other.ExternallyManaged;
            Disabled = other.Disabled;
        }
        public GroupUser ToGroupUser() => new GroupUser(this);
        public bool Equals(GroupUser other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Username == other.Username
                && FirstName == other.FirstName
                && LastName == other.LastName
                && ExternallyManaged == other.ExternallyManaged
                && Disabled == other.Disabled;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(GroupUser other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as GroupUser);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Username);
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(ExternallyManaged);
            hashCode.Add(Disabled);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
