#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestInviteUser : IEquatable<RestInviteUser> {
        public const string RestInviteUserObjectName = "RestInviteUser";
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("language")]
        public LanguageValue? Language { get; set; }

        [JsonProperty("groups")]
        public ICollection<string> Groups { get; set; }

        [JsonProperty("grants")]
        public ICollection<Grant> Grants { get; set; }

        public RestInviteUser(){}
        public RestInviteUser(RestInviteUser other) {
            EmailAddress = other.EmailAddress;
            Language = other.Language == null ? null : (RestInviteUser.LanguageValue)other.Language;
            Groups = other.Groups?.ToList();
            Grants = other.Grants?.Select(value=>value?.ToGrant())?.ToList();
        }
        public RestInviteUser ToRestInviteUser() => new RestInviteUser(this);
        public bool Equals(RestInviteUser other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = EmailAddress == other.EmailAddress
                && Language == other.Language
                && (other.Groups is null ? Groups is null : Groups?.SequenceEqual(other.Groups) ?? other.Groups is null)
                && (other.Grants is null ? Grants is null : Grants?.SequenceEqual(other.Grants) ?? other.Grants is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestInviteUser other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestInviteUser);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(EmailAddress);
            hashCode.Add((int) Language);
            hashCode.Add(Groups);
            hashCode.Add(Grants);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
