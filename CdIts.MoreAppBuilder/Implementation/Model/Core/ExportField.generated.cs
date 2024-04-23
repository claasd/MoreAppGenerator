#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ExportField : IEquatable<ExportField> {
        public const string ExportFieldObjectName = "ExportField";
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dataName")]
        public string DataName { get; set; }

        [JsonProperty("exportFieldType")]
        public ExportFieldTypeValue? ExportFieldType { get; set; }

        [JsonProperty("fields")]
        public ICollection<ExportField> Fields { get; set; }

        public ExportField(){}
        public ExportField(ExportField other) {
            Name = other.Name;
            DataName = other.DataName;
            ExportFieldType = other.ExportFieldType == null ? null : (ExportField.ExportFieldTypeValue)other.ExportFieldType;
            Fields = other.Fields?.Select(value=>value?.ToExportField())?.ToList();
        }
        public ExportField ToExportField() => new ExportField(this);
        public bool Equals(ExportField other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && DataName == other.DataName
                && ExportFieldType == other.ExportFieldType
                && (Fields?.SequenceEqual(other.Fields) ?? other.Fields is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ExportField other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ExportField);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(DataName);
            hashCode.Add((int) ExportFieldType);
            hashCode.Add(Fields);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
