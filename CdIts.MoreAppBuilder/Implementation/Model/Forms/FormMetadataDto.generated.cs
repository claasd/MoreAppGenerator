#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FormMetadataDto : IEquatable<FormMetadataDto> {
        public const string FormMetadataDtoObjectName = "FormMetadataDto";
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("iconColor")]
        public IconColorValue? IconColor { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("viewId")]
        public string ViewId { get; set; }

        [JsonProperty("tags")]
        public ICollection<string> Tags { get; set; }

        [JsonProperty("templateId")]
        public string TemplateId { get; set; }

        [JsonProperty("archivedOn")]
        public DateTimeOffset? ArchivedOn { get; set; }

        [JsonProperty("archivedBy")]
        public string ArchivedBy { get; set; }

        public FormMetadataDto(){}
        public FormMetadataDto(FormMetadataDto other) {
            Name = other.Name;
            Icon = other.Icon;
            IconColor = other.IconColor == null ? null : (FormMetadataDto.IconColorValue)other.IconColor;
            Description = other.Description;
            Language = other.Language;
            ViewId = other.ViewId;
            Tags = other.Tags?.ToList();
            TemplateId = other.TemplateId;
            ArchivedOn = other.ArchivedOn;
            ArchivedBy = other.ArchivedBy;
        }
        public FormMetadataDto ToFormMetadataDto() => new FormMetadataDto(this);
        public bool Equals(FormMetadataDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && Icon == other.Icon
                && IconColor == other.IconColor
                && Description == other.Description
                && Language == other.Language
                && ViewId == other.ViewId
                && (Tags?.SequenceEqual(other.Tags) ?? other.Tags is null)
                && TemplateId == other.TemplateId
                && (ArchivedOn?.Equals(other.ArchivedOn) ?? other.ArchivedOn is null)
                && ArchivedBy == other.ArchivedBy;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormMetadataDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormMetadataDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Icon);
            hashCode.Add((int) IconColor);
            hashCode.Add(Description);
            hashCode.Add(Language);
            hashCode.Add(ViewId);
            hashCode.Add(Tags);
            hashCode.Add(TemplateId);
            hashCode.Add(ArchivedOn);
            hashCode.Add(ArchivedBy);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
