#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestUrlConfiguration : IEquatable<RestUrlConfiguration> {
        public const string RestUrlConfigurationObjectName = "RestUrlConfiguration";
        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty("credentials")]
        public RestCredentials Credentials { get; set; }

        [JsonProperty("requestHeaders")]
        public Dictionary<string, string> RequestHeaders { get; set; }

        [JsonProperty("parameters")]
        public Dictionary<string, string> Parameters { get; set; }

        [JsonProperty("updateInterval", Required = Required.Always)]
        public UpdateIntervalValue UpdateInterval { get; set; }

        public RestUrlConfiguration(){}
        public RestUrlConfiguration(RestUrlConfiguration other) {
            Url = other.Url;
            Credentials = other.Credentials?.ToRestCredentials();
            RequestHeaders = other.RequestHeaders?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Parameters = other.Parameters?.ToDictionary(entry => entry.Key, entry => entry.Value);
            UpdateInterval = (RestUrlConfiguration.UpdateIntervalValue)other.UpdateInterval;
        }
        public RestUrlConfiguration ToRestUrlConfiguration() => new RestUrlConfiguration(this);
        public bool Equals(RestUrlConfiguration other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Url == other.Url
                && (Credentials?.Equals(other.Credentials) ?? other.Credentials is null)
                && (RequestHeaders?.SequenceEqual(other.RequestHeaders) ?? other.RequestHeaders is null)
                && (Parameters?.SequenceEqual(other.Parameters) ?? other.Parameters is null)
                && UpdateInterval == other.UpdateInterval;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestUrlConfiguration other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestUrlConfiguration);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Url);
            hashCode.Add(Credentials);
            hashCode.Add(RequestHeaders);
            hashCode.Add(Parameters);
            hashCode.Add((int) UpdateInterval);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
