#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestRegistrationMeta : IEquatable<RestRegistrationMeta> {
        public const string RestRegistrationMetaObjectName = "RestRegistrationMeta";
        [JsonProperty("registrationDate")]
        public string RegistrationDate { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("instructionId")]
        public string InstructionId { get; set; }

        [JsonProperty("taskId")]
        public string TaskId { get; set; }

        [JsonProperty("compatibilityLevel")]
        public string CompatibilityLevel { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("serialNumber")]
        public int? SerialNumber { get; set; }

        [JsonProperty("hiddenFields")]
        public ICollection<string> HiddenFields { get; set; }

        [JsonProperty("location")]
        public RestRegistrationMetaLocation Location { get; set; }

        [JsonProperty("device")]
        public RestRegistrationMetaDevice Device { get; set; }

        public RestRegistrationMeta(){}
        public RestRegistrationMeta(RestRegistrationMeta other) {
            RegistrationDate = other.RegistrationDate;
            Guid = other.Guid;
            InstructionId = other.InstructionId;
            TaskId = other.TaskId;
            CompatibilityLevel = other.CompatibilityLevel;
            Version = other.Version;
            SerialNumber = other.SerialNumber;
            HiddenFields = other.HiddenFields?.ToList();
            Location = other.Location?.ToRestRegistrationMetaLocation();
            Device = other.Device?.ToRestRegistrationMetaDevice();
        }
        public RestRegistrationMeta ToRestRegistrationMeta() => new RestRegistrationMeta(this);
        public bool Equals(RestRegistrationMeta other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = RegistrationDate == other.RegistrationDate
                && Guid == other.Guid
                && InstructionId == other.InstructionId
                && TaskId == other.TaskId
                && CompatibilityLevel == other.CompatibilityLevel
                && Version == other.Version
                && SerialNumber == other.SerialNumber
                && (other.HiddenFields is null ? HiddenFields is null : HiddenFields?.SequenceEqual(other.HiddenFields) ?? other.HiddenFields is null)
                && (Location?.Equals(other.Location) ?? other.Location is null)
                && (Device?.Equals(other.Device) ?? other.Device is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestRegistrationMeta other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestRegistrationMeta);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(RegistrationDate);
            hashCode.Add(Guid);
            hashCode.Add(InstructionId);
            hashCode.Add(TaskId);
            hashCode.Add(CompatibilityLevel);
            hashCode.Add(Version);
            hashCode.Add(SerialNumber);
            hashCode.Add(HiddenFields);
            hashCode.Add(Location);
            hashCode.Add(Device);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
