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
    public sealed  partial class User : IEquatable<User> {
        public const string UserObjectName = "User";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("settings")]
        public RestUserSettings Settings { get; set; }

        [JsonProperty("emailValidated")]
        public bool? EmailValidated { get; set; }

        [JsonProperty("grants")]
        public ICollection<Grant> Grants { get; set; }

        [JsonProperty("groups")]
        public ICollection<string> Groups { get; set; }

        public User(){}
        public User(User other) {
            Id = other.Id;
            Username = other.Username;
            EmailAddress = other.EmailAddress;
            Settings = other.Settings?.ToRestUserSettings();
            EmailValidated = other.EmailValidated;
            Grants = other.Grants?.Select(value=>value?.ToGrant())?.ToList();
            Groups = other.Groups?.ToList();
        }
        public User ToUser() => new User(this);
        public bool Equals(User other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Username == other.Username
                && EmailAddress == other.EmailAddress
                && (Settings?.Equals(other.Settings) ?? other.Settings is null)
                && EmailValidated == other.EmailValidated
                && (Grants?.SequenceEqual(other.Grants) ?? other.Grants is null)
                && (Groups?.SequenceEqual(other.Groups) ?? other.Groups is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(User other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as User);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Username);
            hashCode.Add(EmailAddress);
            hashCode.Add(Settings);
            hashCode.Add(EmailValidated);
            hashCode.Add(Grants);
            hashCode.Add(Groups);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
