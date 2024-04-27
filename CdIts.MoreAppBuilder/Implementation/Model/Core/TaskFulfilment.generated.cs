#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class TaskFulfilment : IEquatable<TaskFulfilment> {
        public const string TaskFulfilmentObjectName = "TaskFulfilment";
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("formId")]
        public string FormId { get; set; }

        [JsonProperty("registrationId")]
        public string RegistrationId { get; set; }

        public TaskFulfilment(){}
        public TaskFulfilment(TaskFulfilment other) {
            UserId = other.UserId;
            Date = other.Date;
            FormId = other.FormId;
            RegistrationId = other.RegistrationId;
        }
        public TaskFulfilment ToTaskFulfilment() => new TaskFulfilment(this);
        public bool Equals(TaskFulfilment other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = UserId == other.UserId
                && Date == other.Date
                && FormId == other.FormId
                && RegistrationId == other.RegistrationId;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(TaskFulfilment other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as TaskFulfilment);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(UserId);
            hashCode.Add(Date);
            hashCode.Add(FormId);
            hashCode.Add(RegistrationId);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
