#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FormVersionCopyResponseDto : IEquatable<FormVersionCopyResponseDto> {
        public const string FormVersionCopyResponseDtoObjectName = "FormVersionCopyResponseDto";
        [JsonProperty("folder")]
        public FolderDto Folder { get; set; }

        [JsonProperty("form")]
        public FormDto Form { get; set; }

        [JsonProperty("formVersion")]
        public FormVersionDto FormVersion { get; set; }

        public FormVersionCopyResponseDto(){}
        public FormVersionCopyResponseDto(FormVersionCopyResponseDto other) {
            Folder = other.Folder?.ToFolderDto();
            Form = other.Form?.ToFormDto();
            FormVersion = other.FormVersion?.ToFormVersionDto();
        }
        public FormVersionCopyResponseDto ToFormVersionCopyResponseDto() => new FormVersionCopyResponseDto(this);
        public bool Equals(FormVersionCopyResponseDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Folder?.Equals(other.Folder) ?? other.Folder is null)
                && (Form?.Equals(other.Form) ?? other.Form is null)
                && (FormVersion?.Equals(other.FormVersion) ?? other.FormVersion is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormVersionCopyResponseDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormVersionCopyResponseDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Folder);
            hashCode.Add(Form);
            hashCode.Add(FormVersion);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
