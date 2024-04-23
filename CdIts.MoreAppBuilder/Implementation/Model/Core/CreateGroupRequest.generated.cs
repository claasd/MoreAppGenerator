#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class CreateGroupRequest : IEquatable<CreateGroupRequest> {
        public const string CreateGroupRequestObjectName = "CreateGroupRequest";
        [JsonProperty("name")]
        public string Name { get; set; }

        public CreateGroupRequest(){}
        public CreateGroupRequest(CreateGroupRequest other) {
            Name = other.Name;
        }
        public CreateGroupRequest ToCreateGroupRequest() => new CreateGroupRequest(this);
        public bool Equals(CreateGroupRequest other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(CreateGroupRequest other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as CreateGroupRequest);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
