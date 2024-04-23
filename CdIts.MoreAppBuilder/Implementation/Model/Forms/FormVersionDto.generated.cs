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
    public sealed  partial class FormVersionDto : IEquatable<FormVersionDto> {
        public const string FormVersionDtoObjectName = "FormVersionDto";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("formId")]
        public string FormId { get; set; }

        [JsonProperty("fields")]
        public ICollection<Field> Fields { get; set; }

        [JsonProperty("rules")]
        public ICollection<Rule> Rules { get; set; }

        [JsonProperty("triggers")]
        public ICollection<Trigger> Triggers { get; set; }

        [JsonProperty("integrations")]
        public ICollection<IntegrationConfiguration> Integrations { get; set; }

        [JsonProperty("dependencies")]
        public ICollection<Dependency> Dependencies { get; set; }

        [JsonProperty("fieldProperties")]
        public Dictionary<string, object> FieldProperties { get; set; }

        [JsonProperty("meta")]
        public FormVersionMetadata Meta { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("theme")]
        public ThemeDto Theme { get; set; }

        public FormVersionDto(){}
        public FormVersionDto(FormVersionDto other) {
            Id = other.Id;
            FormId = other.FormId;
            Fields = other.Fields?.Select(value=>value?.ToField())?.ToList();
            Rules = other.Rules?.Select(value=>value?.ToRule())?.ToList();
            Triggers = other.Triggers?.Select(value=>value?.ToTrigger())?.ToList();
            Integrations = other.Integrations?.Select(value=>value?.ToIntegrationConfiguration())?.ToList();
            Dependencies = other.Dependencies?.Select(value=>value?.ToDependency())?.ToList();
            FieldProperties = other.FieldProperties?.ToDictionary(entry => entry.Key, entry => entry.Value);
            Meta = other.Meta?.ToFormVersionMetadata();
            Settings = other.Settings?.ToSettings();
            Theme = other.Theme?.ToThemeDto();
        }
        public FormVersionDto ToFormVersionDto() => new FormVersionDto(this);
        public bool Equals(FormVersionDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && FormId == other.FormId
                && (Fields?.SequenceEqual(other.Fields) ?? other.Fields is null)
                && (Rules?.SequenceEqual(other.Rules) ?? other.Rules is null)
                && (Triggers?.SequenceEqual(other.Triggers) ?? other.Triggers is null)
                && (Integrations?.SequenceEqual(other.Integrations) ?? other.Integrations is null)
                && (Dependencies?.SequenceEqual(other.Dependencies) ?? other.Dependencies is null)
                && (FieldProperties?.SequenceEqual(other.FieldProperties) ?? other.FieldProperties is null)
                && (Meta?.Equals(other.Meta) ?? other.Meta is null)
                && (Settings?.Equals(other.Settings) ?? other.Settings is null)
                && (Theme?.Equals(other.Theme) ?? other.Theme is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormVersionDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormVersionDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(FormId);
            hashCode.Add(Fields);
            hashCode.Add(Rules);
            hashCode.Add(Triggers);
            hashCode.Add(Integrations);
            hashCode.Add(Dependencies);
            hashCode.Add(FieldProperties);
            hashCode.Add(Meta);
            hashCode.Add(Settings);
            hashCode.Add(Theme);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
