#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestRegistrationInfo : IEquatable<RestRegistrationInfo> {
        public const string RestRegistrationInfoObjectName = "RestRegistrationInfo";
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("partnerId")]
        public string PartnerId { get; set; }

        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("formVersionId")]
        public string FormVersionId { get; set; }

        [JsonProperty("formId")]
        public string FormId { get; set; }

        [JsonProperty("formName")]
        public string FormName { get; set; }

        [JsonProperty("paid")]
        public bool? Paid { get; set; }

        [JsonProperty("copy")]
        public bool? Copy { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("credits")]
        public int? Credits { get; set; }

        [JsonProperty("resends")]
        public int? Resends { get; set; }

        /// <summary>
        /// Use 'formVersionId' instead
        /// </summary>
        [JsonProperty("applicationArtifactVersion")]
        public string ApplicationArtifactVersion { get; set; }

        public RestRegistrationInfo(){}
        public RestRegistrationInfo(RestRegistrationInfo other) {
            Date = other.Date;
            UserId = other.UserId;
            PartnerId = other.PartnerId;
            CustomerId = other.CustomerId;
            CustomerName = other.CustomerName;
            FormVersionId = other.FormVersionId;
            FormId = other.FormId;
            FormName = other.FormName;
            Paid = other.Paid;
            Copy = other.Copy;
            Price = other.Price;
            Credits = other.Credits;
            Resends = other.Resends;
            ApplicationArtifactVersion = other.ApplicationArtifactVersion;
        }
        public RestRegistrationInfo ToRestRegistrationInfo() => new RestRegistrationInfo(this);
        public bool Equals(RestRegistrationInfo other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Date == other.Date
                && UserId == other.UserId
                && PartnerId == other.PartnerId
                && CustomerId == other.CustomerId
                && CustomerName == other.CustomerName
                && FormVersionId == other.FormVersionId
                && FormId == other.FormId
                && FormName == other.FormName
                && Paid == other.Paid
                && Copy == other.Copy
                && Price == other.Price
                && Credits == other.Credits
                && Resends == other.Resends
                && ApplicationArtifactVersion == other.ApplicationArtifactVersion;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestRegistrationInfo other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestRegistrationInfo);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Date);
            hashCode.Add(UserId);
            hashCode.Add(PartnerId);
            hashCode.Add(CustomerId);
            hashCode.Add(CustomerName);
            hashCode.Add(FormVersionId);
            hashCode.Add(FormId);
            hashCode.Add(FormName);
            hashCode.Add(Paid);
            hashCode.Add(Copy);
            hashCode.Add(Price);
            hashCode.Add(Credits);
            hashCode.Add(Resends);
            hashCode.Add(ApplicationArtifactVersion);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
