#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Trigger : IEquatable<Trigger> {
        public const string TriggerObjectName = "Trigger";
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("staticRecipients")]
        public ICollection<string> StaticRecipients { get; set; }

        [JsonProperty("dynamicRecipients")]
        public ICollection<string> DynamicRecipients { get; set; }

        [JsonProperty("carbonCopyRecipients")]
        public ICollection<string> CarbonCopyRecipients { get; set; }

        [JsonProperty("blindCarbonCopyRecipients")]
        public ICollection<string> BlindCarbonCopyRecipients { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("pdfContent")]
        public string PdfContent { get; set; }

        [JsonProperty("pdfFilename")]
        public string PdfFilename { get; set; }

        [JsonProperty("fromName")]
        public string FromName { get; set; }

        [JsonProperty("replyTo")]
        public string ReplyTo { get; set; }

        [JsonProperty("pdfHeaderLogoResourceId")]
        public string PdfHeaderLogoResourceId { get; set; }

        [JsonProperty("configuration")]
        public TriggerConfiguration Configuration { get; set; }

        public Trigger(){}
        public Trigger(Trigger other) {
            Type = other.Type;
            Name = other.Name;
            StaticRecipients = other.StaticRecipients?.ToList();
            DynamicRecipients = other.DynamicRecipients?.ToList();
            CarbonCopyRecipients = other.CarbonCopyRecipients?.ToList();
            BlindCarbonCopyRecipients = other.BlindCarbonCopyRecipients?.ToList();
            Subject = other.Subject;
            Content = other.Content;
            PdfContent = other.PdfContent;
            PdfFilename = other.PdfFilename;
            FromName = other.FromName;
            ReplyTo = other.ReplyTo;
            PdfHeaderLogoResourceId = other.PdfHeaderLogoResourceId;
            Configuration = other.Configuration?.ToTriggerConfiguration();
        }
        public Trigger ToTrigger() => new Trigger(this);
        public bool Equals(Trigger other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Type == other.Type
                && Name == other.Name
                && (StaticRecipients?.SequenceEqual(other.StaticRecipients) ?? other.StaticRecipients is null)
                && (DynamicRecipients?.SequenceEqual(other.DynamicRecipients) ?? other.DynamicRecipients is null)
                && (CarbonCopyRecipients?.SequenceEqual(other.CarbonCopyRecipients) ?? other.CarbonCopyRecipients is null)
                && (BlindCarbonCopyRecipients?.SequenceEqual(other.BlindCarbonCopyRecipients) ?? other.BlindCarbonCopyRecipients is null)
                && Subject == other.Subject
                && Content == other.Content
                && PdfContent == other.PdfContent
                && PdfFilename == other.PdfFilename
                && FromName == other.FromName
                && ReplyTo == other.ReplyTo
                && PdfHeaderLogoResourceId == other.PdfHeaderLogoResourceId
                && (Configuration?.Equals(other.Configuration) ?? other.Configuration is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Trigger other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Trigger);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Type);
            hashCode.Add(Name);
            hashCode.Add(StaticRecipients);
            hashCode.Add(DynamicRecipients);
            hashCode.Add(CarbonCopyRecipients);
            hashCode.Add(BlindCarbonCopyRecipients);
            hashCode.Add(Subject);
            hashCode.Add(Content);
            hashCode.Add(PdfContent);
            hashCode.Add(PdfFilename);
            hashCode.Add(FromName);
            hashCode.Add(ReplyTo);
            hashCode.Add(PdfHeaderLogoResourceId);
            hashCode.Add(Configuration);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
