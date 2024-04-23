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
    public sealed  partial class ExportOptions : IEquatable<ExportOptions> {
        public const string ExportOptionsObjectName = "ExportOptions";
        /// <summary>
        /// A time-zone ID, such as 'Europe/Paris' or offset such as 'GMT+2' or 'UTC+01:00'
        /// </summary>
        [JsonProperty("timezone", Required = Required.Always)]
        public string Timezone { get; set; }

        [JsonProperty("includeFiles")]
        public bool? IncludeFiles { get; set; }

        [JsonProperty("excelSingleSheet")]
        public bool? ExcelSingleSheet { get; set; }

        [JsonProperty("languageCode", Required = Required.Always)]
        public LanguageCodeValue LanguageCode { get; set; }

        public ExportOptions(){}
        public ExportOptions(ExportOptions other) {
            Timezone = other.Timezone;
            IncludeFiles = other.IncludeFiles;
            ExcelSingleSheet = other.ExcelSingleSheet;
            LanguageCode = (ExportOptions.LanguageCodeValue)other.LanguageCode;
        }
        public ExportOptions ToExportOptions() => new ExportOptions(this);
        public bool Equals(ExportOptions other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Timezone == other.Timezone
                && IncludeFiles == other.IncludeFiles
                && ExcelSingleSheet == other.ExcelSingleSheet
                && LanguageCode == other.LanguageCode;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ExportOptions other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ExportOptions);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Timezone);
            hashCode.Add(IncludeFiles);
            hashCode.Add(ExcelSingleSheet);
            hashCode.Add((int) LanguageCode);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
