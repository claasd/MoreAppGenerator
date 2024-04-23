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
    public sealed  partial class Role : IEquatable<Role> {
        public const string RoleObjectName = "Role";
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permissions")]
        public ICollection<string> Permissions { get; set; }

        public Role(){}
        public Role(Role other) {
            Name = other.Name;
            Permissions = other.Permissions?.ToList();
        }
        public Role ToRole() => new Role(this);
        public bool Equals(Role other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && (Permissions?.SequenceEqual(other.Permissions) ?? other.Permissions is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Role other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Role);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Permissions);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
