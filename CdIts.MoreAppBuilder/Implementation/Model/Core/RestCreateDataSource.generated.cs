#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestCreateDataSource : IEquatable<RestCreateDataSource> {
        public const string RestCreateDataSourceObjectName = "RestCreateDataSource";
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("urlConfiguration")]
        public RestUrlConfiguration UrlConfiguration { get; set; }

        [JsonProperty("googleConfiguration")]
        public GoogleConfiguration GoogleConfiguration { get; set; }

        public RestCreateDataSource(){}
        public RestCreateDataSource(RestCreateDataSource other) {
            Name = other.Name;
            UrlConfiguration = other.UrlConfiguration?.ToRestUrlConfiguration();
            GoogleConfiguration = other.GoogleConfiguration?.ToGoogleConfiguration();
        }
        public RestCreateDataSource ToRestCreateDataSource() => new RestCreateDataSource(this);
        public bool Equals(RestCreateDataSource other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && (UrlConfiguration?.Equals(other.UrlConfiguration) ?? other.UrlConfiguration is null)
                && (GoogleConfiguration?.Equals(other.GoogleConfiguration) ?? other.GoogleConfiguration is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestCreateDataSource other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestCreateDataSource);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(UrlConfiguration);
            hashCode.Add(GoogleConfiguration);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
