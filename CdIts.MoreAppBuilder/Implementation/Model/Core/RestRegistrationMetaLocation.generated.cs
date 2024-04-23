#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestRegistrationMetaLocation : IEquatable<RestRegistrationMetaLocation> {
        public const string RestRegistrationMetaLocationObjectName = "RestRegistrationMetaLocation";
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        public RestRegistrationMetaLocation(){}
        public RestRegistrationMetaLocation(RestRegistrationMetaLocation other) {
            Latitude = other.Latitude;
            Longitude = other.Longitude;
        }
        public RestRegistrationMetaLocation ToRestRegistrationMetaLocation() => new RestRegistrationMetaLocation(this);
        public bool Equals(RestRegistrationMetaLocation other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Latitude == other.Latitude
                && Longitude == other.Longitude;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestRegistrationMetaLocation other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestRegistrationMetaLocation);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Latitude);
            hashCode.Add(Longitude);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
