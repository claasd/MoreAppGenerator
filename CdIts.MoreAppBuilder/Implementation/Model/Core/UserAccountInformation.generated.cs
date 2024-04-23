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
    public sealed  partial class UserAccountInformation : IEquatable<UserAccountInformation> {
        public const string UserAccountInformationObjectName = "UserAccountInformation";
        [JsonProperty("firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("language", Required = Required.Always)]
        public LanguageValue Language { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("receiveNewsLetter", Required = Required.Always)]
        public bool ReceiveNewsLetter { get; set; }

        [JsonProperty("timeZone", Required = Required.Always)]
        public JToken TimeZone { get; set; }

        public UserAccountInformation(){}
        public UserAccountInformation(UserAccountInformation other) {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Language = (UserAccountInformation.LanguageValue)other.Language;
            Country = other.Country;
            ReceiveNewsLetter = other.ReceiveNewsLetter;
            TimeZone = other.TimeZone?.DeepClone();
        }
        public UserAccountInformation ToUserAccountInformation() => new UserAccountInformation(this);
        public bool Equals(UserAccountInformation other) {
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
        partial void _PartialEquals(UserAccountInformation other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as UserAccountInformation);
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
