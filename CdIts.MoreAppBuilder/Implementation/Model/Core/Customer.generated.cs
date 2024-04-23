#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Customer : IEquatable<Customer> {
        public const string CustomerObjectName = "Customer";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logoAssetId")]
        public string LogoAssetId { get; set; }

        [JsonProperty("settings")]
        public RestCustomerSettings Settings { get; set; }

        [JsonProperty("meta")]
        public RestCustomerMeta Meta { get; set; }

        public Customer(){}
        public Customer(Customer other) {
            Id = other.Id;
            CustomerId = other.CustomerId;
            Name = other.Name;
            LogoAssetId = other.LogoAssetId;
            Settings = other.Settings?.ToRestCustomerSettings();
            Meta = other.Meta?.ToRestCustomerMeta();
        }
        public Customer ToCustomer() => new Customer(this);
        public bool Equals(Customer other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && CustomerId == other.CustomerId
                && Name == other.Name
                && LogoAssetId == other.LogoAssetId
                && (Settings?.Equals(other.Settings) ?? other.Settings is null)
                && (Meta?.Equals(other.Meta) ?? other.Meta is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Customer other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Customer);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(CustomerId);
            hashCode.Add(Name);
            hashCode.Add(LogoAssetId);
            hashCode.Add(Settings);
            hashCode.Add(Meta);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
