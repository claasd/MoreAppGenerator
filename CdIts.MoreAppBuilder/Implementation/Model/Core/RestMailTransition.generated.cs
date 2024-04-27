#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestMailTransition : IEquatable<RestMailTransition> {
        public const string RestMailTransitionObjectName = "RestMailTransition";
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("rejectReason")]
        public string RejectReason { get; set; }

        [JsonProperty("bounceDescription")]
        public string BounceDescription { get; set; }

        public RestMailTransition(){}
        public RestMailTransition(RestMailTransition other) {
            Date = other.Date;
            Status = other.Status;
            RejectReason = other.RejectReason;
            BounceDescription = other.BounceDescription;
        }
        public RestMailTransition ToRestMailTransition() => new RestMailTransition(this);
        public bool Equals(RestMailTransition other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Date == other.Date
                && Status == other.Status
                && RejectReason == other.RejectReason
                && BounceDescription == other.BounceDescription;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestMailTransition other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestMailTransition);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Date);
            hashCode.Add(Status);
            hashCode.Add(RejectReason);
            hashCode.Add(BounceDescription);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
