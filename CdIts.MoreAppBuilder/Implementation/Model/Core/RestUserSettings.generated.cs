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
    public sealed  partial class RestUserSettings : IEquatable<RestUserSettings> {
        public const string RestUserSettingsObjectName = "RestUserSettings";
        [JsonProperty("firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("language", Required = Required.Always)]
        public LanguageValue Language { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("receiveNewsLetter", Required = Required.Always)]
        public bool ReceiveNewsLetter { get; set; }

        [JsonProperty("finishedTour", Required = Required.Always)]
        public bool FinishedTour { get; set; }

        [JsonProperty("timeZone")]
        public JToken? TimeZone { get; set; }

        public RestUserSettings(){}
        public RestUserSettings(RestUserSettings other) {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Language = (RestUserSettings.LanguageValue)other.Language;
            PhoneNumber = other.PhoneNumber;
            ReceiveNewsLetter = other.ReceiveNewsLetter;
            FinishedTour = other.FinishedTour;
            TimeZone = other.TimeZone?.DeepClone();
        }
        public RestUserSettings ToRestUserSettings() => new RestUserSettings(this);
        public bool Equals(RestUserSettings other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = FirstName == other.FirstName
                && LastName == other.LastName
                && Language == other.Language
                && PhoneNumber == other.PhoneNumber
                && ReceiveNewsLetter == other.ReceiveNewsLetter
                && FinishedTour == other.FinishedTour
                && (TimeZone?.Equals(other.TimeZone) ?? other.TimeZone is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestUserSettings other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestUserSettings);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add((int) Language);
            hashCode.Add(PhoneNumber);
            hashCode.Add(ReceiveNewsLetter);
            hashCode.Add(FinishedTour);
            hashCode.Add(TimeZone);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
