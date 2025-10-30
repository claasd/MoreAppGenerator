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
    public sealed  partial class RestRegistrationMailStatus : IEquatable<RestRegistrationMailStatus> {
        public const string RestRegistrationMailStatusObjectName = "RestRegistrationMailStatus";
        [JsonProperty("mailIds")]
        public ICollection<string> MailIds { get; set; }

        [JsonProperty("pdfFileId")]
        public string PdfFileId { get; set; }

        [JsonProperty("emailAddresses")]
        public ICollection<string> EmailAddresses { get; set; }

        [JsonProperty("status")]
        public Dictionary<string, RestMailSendStatus> Status { get; set; }

        [JsonProperty("notificationId")]
        public string NotificationId { get; set; }

        [JsonProperty("attempt")]
        public int? Attempt { get; set; }

        public RestRegistrationMailStatus(){}
        public RestRegistrationMailStatus(RestRegistrationMailStatus other) {
            MailIds = other.MailIds?.ToList();
            PdfFileId = other.PdfFileId;
            EmailAddresses = other.EmailAddresses?.ToList();
            Status = other.Status?.ToDictionary(entry => entry.Key, entry => entry.Value?.ToRestMailSendStatus());
            NotificationId = other.NotificationId;
            Attempt = other.Attempt;
        }
        public RestRegistrationMailStatus ToRestRegistrationMailStatus() => new RestRegistrationMailStatus(this);
        public bool Equals(RestRegistrationMailStatus other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.MailIds is null ? MailIds is null : MailIds?.SequenceEqual(other.MailIds) ?? other.MailIds is null)
                && PdfFileId == other.PdfFileId
                && (other.EmailAddresses is null ? EmailAddresses is null : EmailAddresses?.SequenceEqual(other.EmailAddresses) ?? other.EmailAddresses is null)
                && (other.Status is null ? Status is null : Status?.SequenceEqual(other.Status) ?? other.Status is null)
                && NotificationId == other.NotificationId
                && Attempt == other.Attempt;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestRegistrationMailStatus other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestRegistrationMailStatus);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(MailIds);
            hashCode.Add(PdfFileId);
            hashCode.Add(EmailAddresses);
            hashCode.Add(Status);
            hashCode.Add(NotificationId);
            hashCode.Add(Attempt);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
