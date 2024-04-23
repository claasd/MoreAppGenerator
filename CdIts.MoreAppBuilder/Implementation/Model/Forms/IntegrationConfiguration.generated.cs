#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class IntegrationConfiguration : IEquatable<IntegrationConfiguration> {
        public const string IntegrationConfigurationObjectName = "IntegrationConfiguration";
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public int? Version { get; set; }

        [JsonProperty("configuration")]
        public Dictionary<string, object> Configuration { get; set; }

        public IntegrationConfiguration(){}
        public IntegrationConfiguration(IntegrationConfiguration other) {
            Uid = other.Uid;
            Key = other.Key;
            Namespace = other.Namespace;
            Name = other.Name;
            Version = other.Version;
            Configuration = other.Configuration?.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public IntegrationConfiguration ToIntegrationConfiguration() => new IntegrationConfiguration(this);
        public bool Equals(IntegrationConfiguration other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Uid == other.Uid
                && Key == other.Key
                && Namespace == other.Namespace
                && Name == other.Name
                && Version == other.Version
                && (Configuration?.SequenceEqual(other.Configuration) ?? other.Configuration is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(IntegrationConfiguration other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as IntegrationConfiguration);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Uid);
            hashCode.Add(Key);
            hashCode.Add(Namespace);
            hashCode.Add(Name);
            hashCode.Add(Version);
            hashCode.Add(Configuration);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
