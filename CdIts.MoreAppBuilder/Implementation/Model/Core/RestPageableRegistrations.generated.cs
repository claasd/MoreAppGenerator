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
    public sealed  partial class RestPageableRegistrations : IEquatable<RestPageableRegistrations> {
        public const string RestPageableRegistrationsObjectName = "RestPageableRegistrations";
        [JsonProperty("totalSize")]
        public long? TotalSize { get; set; }

        [JsonProperty("elements")]
        public ICollection<RestRegistration> Elements { get; set; }

        [JsonProperty("headers")]
        public ICollection<WebRegistrationHeader> Headers { get; set; }

        public RestPageableRegistrations(){}
        public RestPageableRegistrations(RestPageableRegistrations other) {
            TotalSize = other.TotalSize;
            Elements = other.Elements?.Select(value=>value?.ToRestRegistration())?.ToList();
            Headers = other.Headers?.Select(value=>value?.ToWebRegistrationHeader())?.ToList();
        }
        public RestPageableRegistrations ToRestPageableRegistrations() => new RestPageableRegistrations(this);
        public bool Equals(RestPageableRegistrations other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = TotalSize == other.TotalSize
                && (Elements?.SequenceEqual(other.Elements) ?? other.Elements is null)
                && (Headers?.SequenceEqual(other.Headers) ?? other.Headers is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestPageableRegistrations other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestPageableRegistrations);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(TotalSize);
            hashCode.Add(Elements);
            hashCode.Add(Headers);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
