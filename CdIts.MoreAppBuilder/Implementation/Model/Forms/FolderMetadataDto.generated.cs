#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FolderMetadataDto : IEquatable<FolderMetadataDto> {
        public const string FolderMetadataDtoObjectName = "FolderMetadataDto";
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }

        public FolderMetadataDto(){}
        public FolderMetadataDto(FolderMetadataDto other) {
            Name = other.Name;
            Description = other.Description;
            Icon = other.Icon;
            Image = other.Image;
            ApplicationId = other.ApplicationId;
        }
        public FolderMetadataDto ToFolderMetadataDto() => new FolderMetadataDto(this);
        public bool Equals(FolderMetadataDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && Description == other.Description
                && Icon == other.Icon
                && Image == other.Image
                && ApplicationId == other.ApplicationId;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FolderMetadataDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FolderMetadataDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Description);
            hashCode.Add(Icon);
            hashCode.Add(Image);
            hashCode.Add(ApplicationId);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
