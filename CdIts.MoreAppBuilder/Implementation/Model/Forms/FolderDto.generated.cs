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
    public sealed  partial class FolderDto : IEquatable<FolderDto> {
        public const string FolderDtoObjectName = "FolderDto";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("forms")]
        public ICollection<FormDto> Forms { get; set; }

        [JsonProperty("meta")]
        public FolderMetadataDto Meta { get; set; }

        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        public FolderDto(){}
        public FolderDto(FolderDto other) {
            Id = other.Id;
            Forms = other.Forms?.Select(value=>value?.ToFormDto())?.ToList();
            Meta = other.Meta?.ToFolderMetadataDto();
            Status = other.Status == null ? null : (FolderDto.StatusValue)other.Status;
        }
        public FolderDto ToFolderDto() => new FolderDto(this);
        public bool Equals(FolderDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && (other.Forms is null ? Forms is null : Forms?.SequenceEqual(other.Forms) ?? other.Forms is null)
                && (Meta?.Equals(other.Meta) ?? other.Meta is null)
                && Status == other.Status;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FolderDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FolderDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Forms);
            hashCode.Add(Meta);
            hashCode.Add((int) Status);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
