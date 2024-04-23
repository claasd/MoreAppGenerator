#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class CreateRoleRequest : IEquatable<CreateRoleRequest> {
        public const string CreateRoleRequestObjectName = "CreateRoleRequest";
        [JsonProperty("name")]
        public string Name { get; set; }

        public CreateRoleRequest(){}
        public CreateRoleRequest(CreateRoleRequest other) {
            Name = other.Name;
        }
        public CreateRoleRequest ToCreateRoleRequest() => new CreateRoleRequest(this);
        public bool Equals(CreateRoleRequest other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(CreateRoleRequest other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as CreateRoleRequest);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
