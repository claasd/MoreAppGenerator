#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Webhooks {
    public static partial class Extensions {
        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithSubscriber(this Subscriber item, Subscriber other, bool deepClone = true) {
            item.Id = other.Id;
            item.Url = other.Url;
            item.Name = other.Name;
            item.Type = deepClone ? other.Type?.ToList() : other.Type;
            item.Status = (Subscriber.StatusValue)other.Status;
            item.Secret = other.Secret;
        }
        
        /// <summary>
        /// Returns a new object of Subscriber with fileds filled from Subscriber. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Subscriber ToSubscriber(this Subscriber other, bool deepClone = true) => new Subscriber() { 
            Id = other.Id,
            Url = other.Url,
            Name = other.Name,
            Type = deepClone ? other.Type?.ToList() : other.Type,
            Status = (Subscriber.StatusValue)other.Status,
            Secret = other.Secret
        };
        
        /// <summary>
        /// Selects the type Subscriber from a IQueryable<Subscriber>
        /// </summary>
        public static IQueryable<Subscriber> SelectAsSubscriber(this IQueryable<Subscriber> query) => query.Select(other => new Subscriber() { 
            Id = other.Id,
            Url = other.Url,
            Name = other.Name,
            Type = other.Type,
            Status = (Subscriber.StatusValue)other.Status,
            Secret = other.Secret
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithInvocationResult(this InvocationResult item, InvocationResult other, bool deepClone = true) {
            item.Id = other.Id;
            item.SubscriberId = other.SubscriberId;
            item.EventId = other.EventId;
            item.Type = other.Type;
            item.CustomerId = other.CustomerId;
            item.Status = other.Status == null ? null : (InvocationResult.StatusValue)other.Status;
            item.Message = other.Message;
            item.InvokedOn = other.InvokedOn;
            item.RetryOn = other.RetryOn;
            item.Attempt = other.Attempt;
        }
        
        /// <summary>
        /// Returns a new object of InvocationResult with fileds filled from InvocationResult. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static InvocationResult ToInvocationResult(this InvocationResult other, bool deepClone = true) => new InvocationResult() { 
            Id = other.Id,
            SubscriberId = other.SubscriberId,
            EventId = other.EventId,
            Type = other.Type,
            CustomerId = other.CustomerId,
            Status = other.Status == null ? null : (InvocationResult.StatusValue)other.Status,
            Message = other.Message,
            InvokedOn = other.InvokedOn,
            RetryOn = other.RetryOn,
            Attempt = other.Attempt
        };
        
        /// <summary>
        /// Selects the type InvocationResult from a IQueryable<InvocationResult>
        /// </summary>
        public static IQueryable<InvocationResult> SelectAsInvocationResult(this IQueryable<InvocationResult> query) => query.Select(other => new InvocationResult() { 
            Id = other.Id,
            SubscriberId = other.SubscriberId,
            EventId = other.EventId,
            Type = other.Type,
            CustomerId = other.CustomerId,
            Status = other.Status == null ? null : (InvocationResult.StatusValue)other.Status,
            Message = other.Message,
            InvokedOn = other.InvokedOn,
            RetryOn = other.RetryOn,
            Attempt = other.Attempt
        });

        /// <summary>
        /// Replaces all fields with the data of the passed object
        /// </summary>
        public static void UpdateWithEvent(this Event item, Event other, bool deepClone = true) {
            item.Id = other.Id;
            item.Timestamp = other.Timestamp;
            item.CustomerId = other.CustomerId;
            item.Type = other.Type;
            item.IdempotencyKey = other.IdempotencyKey;
            item.Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data;
        }
        
        /// <summary>
        /// Returns a new object of Event with fileds filled from Event. 
        /// if deepClone is set to false, a shallow copy will be created.
        /// </summary>
        public static Event ToEvent(this Event other, bool deepClone = true) => new Event() { 
            Id = other.Id,
            Timestamp = other.Timestamp,
            CustomerId = other.CustomerId,
            Type = other.Type,
            IdempotencyKey = other.IdempotencyKey,
            Data = deepClone ? other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value) : other.Data
        };
        
        /// <summary>
        /// Selects the type Event from a IQueryable<Event>
        /// </summary>
        public static IQueryable<Event> SelectAsEvent(this IQueryable<Event> query) => query.Select(other => new Event() { 
            Id = other.Id,
            Timestamp = other.Timestamp,
            CustomerId = other.CustomerId,
            Type = other.Type,
            IdempotencyKey = other.IdempotencyKey,
            Data = other.Data
        });
    }
}
