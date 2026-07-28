#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using MoreAppBuilder.DefaultFormObjects;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestTask : IEquatable<RestTask> {
        public const string RestTaskObjectName = "RestTask";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }

        [JsonProperty("formId")]
        public string FormId { get; set; }

        [JsonProperty("formName")]
        public string FormName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("formIcon")]
        public string FormIcon { get; set; }

        [JsonProperty("formIconColor")]
        public string FormIconColor { get; set; }

        [JsonProperty("users", Required = Required.Always)]
        public ICollection<string> Users { get; set; } = new List<string>();

        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; set; }

        [JsonProperty("dates", Required = Required.Always)]
        public TaskDates Dates { get; set; } = new TaskDates();

        [JsonProperty("data", Required = Required.Always)]
        public object Data { get; set; }

        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("fulfilments")]
        public ICollection<TaskFulfilment> Fulfilments { get; set; } = new List<TaskFulfilment>();

        [JsonProperty("location")]
        public MoreAppLocation Location { get; set; }

        public RestTask(){}
        public RestTask(RestTask other) {
            Id = other.Id;
            CustomerId = other.CustomerId;
            FormId = other.FormId;
            FormName = other.FormName;
            Description = other.Description;
            FormIcon = other.FormIcon;
            FormIconColor = other.FormIconColor;
            Users = other.Users?.ToList();
            Message = other.Message;
            Dates = other.Dates?.ToTaskDates();
            Data = other.Data;
            Status = other.Status == null ? null : (RestTask.StatusValue)other.Status;
            Fulfilments = other.Fulfilments?.Select(value=>value?.ToTaskFulfilment())?.ToList();
            Location = other.Location?.ToMoreAppLocation();
        }
        public RestTask ToRestTask() => new RestTask(this);
        public bool Equals(RestTask other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && CustomerId == other.CustomerId
                && FormId == other.FormId
                && FormName == other.FormName
                && Description == other.Description
                && FormIcon == other.FormIcon
                && FormIconColor == other.FormIconColor
                && (other.Users is null ? Users is null : Users?.SequenceEqual(other.Users) ?? other.Users is null)
                && Message == other.Message
                && (Dates?.Equals(other.Dates) ?? other.Dates is null)
                && (Data?.Equals(other.Data) ?? other.Data is null)
                && Status == other.Status
                && (other.Fulfilments is null ? Fulfilments is null : Fulfilments?.SequenceEqual(other.Fulfilments) ?? other.Fulfilments is null)
                && (Location?.Equals(other.Location) ?? other.Location is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestTask other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestTask);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(CustomerId);
            hashCode.Add(FormId);
            hashCode.Add(FormName);
            hashCode.Add(Description);
            hashCode.Add(FormIcon);
            hashCode.Add(FormIconColor);
            hashCode.Add(Users);
            hashCode.Add(Message);
            hashCode.Add(Dates);
            hashCode.Add(Data);
            hashCode.Add((int?) Status);
            hashCode.Add(Fulfilments);
            hashCode.Add(Location);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
