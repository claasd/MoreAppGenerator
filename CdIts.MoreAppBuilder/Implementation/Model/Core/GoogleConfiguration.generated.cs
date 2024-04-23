#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class GoogleConfiguration : IEquatable<GoogleConfiguration> {
        public const string GoogleConfigurationObjectName = "GoogleConfiguration";
        [JsonProperty("spreadsheetId")]
        public string SpreadsheetId { get; set; }

        [JsonProperty("updateInterval")]
        public UpdateIntervalValue? UpdateInterval { get; set; }

        public GoogleConfiguration(){}
        public GoogleConfiguration(GoogleConfiguration other) {
            SpreadsheetId = other.SpreadsheetId;
            UpdateInterval = other.UpdateInterval == null ? null : (GoogleConfiguration.UpdateIntervalValue)other.UpdateInterval;
        }
        public GoogleConfiguration ToGoogleConfiguration() => new GoogleConfiguration(this);
        public bool Equals(GoogleConfiguration other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = SpreadsheetId == other.SpreadsheetId
                && UpdateInterval == other.UpdateInterval;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(GoogleConfiguration other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as GoogleConfiguration);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(SpreadsheetId);
            hashCode.Add((int) UpdateInterval);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
