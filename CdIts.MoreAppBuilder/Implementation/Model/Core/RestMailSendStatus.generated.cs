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
    public sealed  partial class RestMailSendStatus : IEquatable<RestMailSendStatus> {
        public const string RestMailSendStatusObjectName = "RestMailSendStatus";
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("transitions")]
        public ICollection<RestMailTransition> Transitions { get; set; }

        public RestMailSendStatus(){}
        public RestMailSendStatus(RestMailSendStatus other) {
            Email = other.Email;
            Transitions = other.Transitions?.Select(value=>value?.ToRestMailTransition())?.ToList();
        }
        public RestMailSendStatus ToRestMailSendStatus() => new RestMailSendStatus(this);
        public bool Equals(RestMailSendStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Email == other.Email
                && (other.Transitions is null ? Transitions is null : Transitions?.SequenceEqual(other.Transitions) ?? other.Transitions is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestMailSendStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestMailSendStatus);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Email);
            hashCode.Add(Transitions);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
