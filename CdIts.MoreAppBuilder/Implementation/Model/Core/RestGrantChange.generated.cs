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
    public sealed  partial class RestGrantChange : IEquatable<RestGrantChange> {
        public const string RestGrantChangeObjectName = "RestGrantChange";
        [JsonProperty("operation", Required = Required.Always)]
        public OperationValue Operation { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        [JsonProperty("resourceId", Required = Required.Always)]
        public string ResourceId { get; set; }

        [JsonProperty("resourceType", Required = Required.Always)]
        public ResourceTypeValue ResourceType { get; set; }

        public RestGrantChange(){}
        public RestGrantChange(RestGrantChange other) {
            Operation = (RestGrantChange.OperationValue)other.Operation;
            RoleId = other.RoleId;
            ResourceId = other.ResourceId;
            ResourceType = (RestGrantChange.ResourceTypeValue)other.ResourceType;
        }
        public RestGrantChange ToRestGrantChange() => new RestGrantChange(this);
        public bool Equals(RestGrantChange other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Operation == other.Operation
                && RoleId == other.RoleId
                && ResourceId == other.ResourceId
                && ResourceType == other.ResourceType;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestGrantChange other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestGrantChange);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Operation);
            hashCode.Add(RoleId);
            hashCode.Add(ResourceId);
            hashCode.Add((int) ResourceType);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
