#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FormVersionCopyDto : IEquatable<FormVersionCopyDto> {
        public const string FormVersionCopyDtoObjectName = "FormVersionCopyDto";
        [JsonProperty("customerId", Required = Required.Always)]
        public long CustomerId { get; set; }

        [JsonProperty("folderId", Required = Required.Always)]
        public string FolderId { get; set; }

        [JsonProperty("formName", Required = Required.Always)]
        public string FormName { get; set; }

        public FormVersionCopyDto(){}
        public FormVersionCopyDto(FormVersionCopyDto other) {
            CustomerId = other.CustomerId;
            FolderId = other.FolderId;
            FormName = other.FormName;
        }
        public FormVersionCopyDto ToFormVersionCopyDto() => new FormVersionCopyDto(this);
        public bool Equals(FormVersionCopyDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = CustomerId == other.CustomerId
                && FolderId == other.FolderId
                && FormName == other.FormName;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormVersionCopyDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormVersionCopyDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(CustomerId);
            hashCode.Add(FolderId);
            hashCode.Add(FormName);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
