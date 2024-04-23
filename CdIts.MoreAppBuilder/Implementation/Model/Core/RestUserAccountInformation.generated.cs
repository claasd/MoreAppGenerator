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
    public sealed  partial class RestUserAccountInformation : IEquatable<RestUserAccountInformation> {
        public const string RestUserAccountInformationObjectName = "RestUserAccountInformation";
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("language", Required = Required.Always)]
        public LanguageValue Language { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("receiveNewsLetter", Required = Required.Always)]
        public bool ReceiveNewsLetter { get; set; }

        [JsonProperty("timeZone")]
        public JToken? TimeZone { get; set; }

        public RestUserAccountInformation(){}
        public RestUserAccountInformation(RestUserAccountInformation other) {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Language = (RestUserAccountInformation.LanguageValue)other.Language;
            Country = other.Country;
            ReceiveNewsLetter = other.ReceiveNewsLetter;
            TimeZone = other.TimeZone?.DeepClone();
        }
        public RestUserAccountInformation ToRestUserAccountInformation() => new RestUserAccountInformation(this);
        public bool Equals(RestUserAccountInformation other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = FirstName == other.FirstName
                && LastName == other.LastName
                && Language == other.Language
                && Country == other.Country
                && ReceiveNewsLetter == other.ReceiveNewsLetter
                && (TimeZone?.Equals(other.TimeZone) ?? other.TimeZone is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestUserAccountInformation other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestUserAccountInformation);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add((int) Language);
            hashCode.Add(Country);
            hashCode.Add(ReceiveNewsLetter);
            hashCode.Add(TimeZone);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
