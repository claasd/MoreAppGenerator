#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestCredentials : IEquatable<RestCredentials> {
        public const string RestCredentialsObjectName = "RestCredentials";
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public RestCredentials(){}
        public RestCredentials(RestCredentials other) {
            Username = other.Username;
            Password = other.Password;
        }
        public RestCredentials ToRestCredentials() => new RestCredentials(this);
        public bool Equals(RestCredentials other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Username == other.Username
                && Password == other.Password;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestCredentials other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestCredentials);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Username);
            hashCode.Add(Password);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
