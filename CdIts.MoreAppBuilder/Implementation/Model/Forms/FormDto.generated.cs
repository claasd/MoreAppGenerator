#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FormDto : IEquatable<FormDto> {
        public const string FormDtoObjectName = "FormDto";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("publishedVersion", Required = Required.Always)]
        public FormPublishedVersionDto PublishedVersion { get; set; } = new FormPublishedVersionDto();

        [JsonProperty("meta")]
        public FormMetadataDto Meta { get; set; }

        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("scope")]
        public ScopeValue? Scope { get; set; }

        public FormDto(){}
        public FormDto(FormDto other) {
            Id = other.Id;
            PublishedVersion = other.PublishedVersion?.ToFormPublishedVersionDto();
            Meta = other.Meta?.ToFormMetadataDto();
            Status = other.Status == null ? null : (FormDto.StatusValue)other.Status;
            Scope = other.Scope == null ? null : (FormDto.ScopeValue)other.Scope;
        }
        public FormDto ToFormDto() => new FormDto(this);
        public bool Equals(FormDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && (PublishedVersion?.Equals(other.PublishedVersion) ?? other.PublishedVersion is null)
                && (Meta?.Equals(other.Meta) ?? other.Meta is null)
                && Status == other.Status
                && Scope == other.Scope;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(PublishedVersion);
            hashCode.Add(Meta);
            hashCode.Add((int) Status);
            hashCode.Add((int) Scope);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
