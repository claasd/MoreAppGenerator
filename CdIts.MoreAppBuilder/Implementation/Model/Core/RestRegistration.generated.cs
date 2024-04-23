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
    public sealed  partial class RestRegistration : IEquatable<RestRegistration> {
        public const string RestRegistrationObjectName = "RestRegistration";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

        [JsonProperty("info")]
        public RestRegistrationInfo Info { get; set; }

        [JsonProperty("meta")]
        public RestRegistrationMeta Meta { get; set; }

        [JsonProperty("mailStatuses")]
        public ICollection<RestRegistrationMailStatus> MailStatuses { get; set; }

        public RestRegistration(){}
        public RestRegistration(RestRegistration other) {
            Id = other.Id;
            Data = other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Info = other.Info?.ToRestRegistrationInfo();
            Meta = other.Meta?.ToRestRegistrationMeta();
            MailStatuses = other.MailStatuses?.Select(value=>value?.ToRestRegistrationMailStatus())?.ToList();
        }
        public RestRegistration ToRestRegistration() => new RestRegistration(this);
        public bool Equals(RestRegistration other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && (Data?.SequenceEqual(other.Data) ?? other.Data is null)
                && (Info?.Equals(other.Info) ?? other.Info is null)
                && (Meta?.Equals(other.Meta) ?? other.Meta is null)
                && (MailStatuses?.SequenceEqual(other.MailStatuses) ?? other.MailStatuses is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestRegistration other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestRegistration);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Data);
            hashCode.Add(Info);
            hashCode.Add(Meta);
            hashCode.Add(MailStatuses);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
