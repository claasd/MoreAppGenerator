#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestRegistrationMetaDevice : IEquatable<RestRegistrationMetaDevice> {
        public const string RestRegistrationMetaDeviceObjectName = "RestRegistrationMetaDevice";
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        public RestRegistrationMetaDevice(){}
        public RestRegistrationMetaDevice(RestRegistrationMetaDevice other) {
            Uuid = other.Uuid;
            Name = other.Name;
            Network = other.Network;
            UserAgent = other.UserAgent;
            AppVersion = other.AppVersion;
        }
        public RestRegistrationMetaDevice ToRestRegistrationMetaDevice() => new RestRegistrationMetaDevice(this);
        public bool Equals(RestRegistrationMetaDevice other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Uuid == other.Uuid
                && Name == other.Name
                && Network == other.Network
                && UserAgent == other.UserAgent
                && AppVersion == other.AppVersion;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestRegistrationMetaDevice other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestRegistrationMetaDevice);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Uuid);
            hashCode.Add(Name);
            hashCode.Add(Network);
            hashCode.Add(UserAgent);
            hashCode.Add(AppVersion);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
