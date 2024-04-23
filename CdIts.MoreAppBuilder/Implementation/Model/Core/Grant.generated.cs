#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Grant : IEquatable<Grant> {
        public const string GrantObjectName = "Grant";
        [JsonProperty("customerId")]
        public double? CustomerId { get; set; }

        [JsonProperty("resourceType")]
        public ResourceTypeValue? ResourceType { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; set; }

        public Grant(){}
        public Grant(Grant other) {
            CustomerId = other.CustomerId;
            ResourceType = other.ResourceType == null ? null : (Grant.ResourceTypeValue)other.ResourceType;
            RoleId = other.RoleId;
            ResourceId = other.ResourceId;
        }
        public Grant ToGrant() => new Grant(this);
        public bool Equals(Grant other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = CustomerId == other.CustomerId
                && ResourceType == other.ResourceType
                && RoleId == other.RoleId
                && ResourceId == other.ResourceId;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Grant other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Grant);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(CustomerId);
            hashCode.Add((int) ResourceType);
            hashCode.Add(RoleId);
            hashCode.Add(ResourceId);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
