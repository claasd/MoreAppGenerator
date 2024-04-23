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
    public sealed  partial class RestInvite : IEquatable<RestInvite> {
        public const string RestInviteObjectName = "RestInvite";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("grants")]
        public ICollection<Grant> Grants { get; set; }

        [JsonProperty("groups")]
        public ICollection<string> Groups { get; set; }

        [JsonProperty("settings")]
        public UserAccountInformation Settings { get; set; }

        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("expiresAt")]
        public DateTimeOffset? ExpiresAt { get; set; }

        public RestInvite(){}
        public RestInvite(RestInvite other) {
            Id = other.Id;
            CustomerId = other.CustomerId;
            EmailAddress = other.EmailAddress;
            Grants = other.Grants?.Select(value=>value?.ToGrant())?.ToList();
            Groups = other.Groups?.ToList();
            Settings = other.Settings?.ToUserAccountInformation();
            Status = other.Status == null ? null : (RestInvite.StatusValue)other.Status;
            ExpiresAt = other.ExpiresAt;
        }
        public RestInvite ToRestInvite() => new RestInvite(this);
        public bool Equals(RestInvite other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && CustomerId == other.CustomerId
                && EmailAddress == other.EmailAddress
                && (Grants?.SequenceEqual(other.Grants) ?? other.Grants is null)
                && (Groups?.SequenceEqual(other.Groups) ?? other.Groups is null)
                && (Settings?.Equals(other.Settings) ?? other.Settings is null)
                && Status == other.Status
                && (ExpiresAt?.Equals(other.ExpiresAt) ?? other.ExpiresAt is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestInvite other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestInvite);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(CustomerId);
            hashCode.Add(EmailAddress);
            hashCode.Add(Grants);
            hashCode.Add(Groups);
            hashCode.Add(Settings);
            hashCode.Add((int) Status);
            hashCode.Add(ExpiresAt);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
