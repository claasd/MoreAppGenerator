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
    public sealed  partial class RestCustomerSettings : IEquatable<RestCustomerSettings> {
        public const string RestCustomerSettingsObjectName = "RestCustomerSettings";
        [JsonProperty("dateFormat")]
        public DateFormatValue? DateFormat { get; set; }

        [JsonProperty("segment")]
        public SegmentValue? Segment { get; set; }

        [JsonProperty("otherSegment")]
        public string OtherSegment { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public RestCustomerSettings(){}
        public RestCustomerSettings(RestCustomerSettings other) {
            DateFormat = other.DateFormat == null ? null : (RestCustomerSettings.DateFormatValue)other.DateFormat;
            Segment = other.Segment == null ? null : (RestCustomerSettings.SegmentValue)other.Segment;
            OtherSegment = other.OtherSegment;
            Type = other.Type;
        }
        public RestCustomerSettings ToRestCustomerSettings() => new RestCustomerSettings(this);
        public bool Equals(RestCustomerSettings other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = DateFormat == other.DateFormat
                && Segment == other.Segment
                && OtherSegment == other.OtherSegment
                && Type == other.Type;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestCustomerSettings other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestCustomerSettings);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) DateFormat);
            hashCode.Add((int) Segment);
            hashCode.Add(OtherSegment);
            hashCode.Add(Type);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
