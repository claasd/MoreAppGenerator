using Caffoa;
using Caffoa.Defaults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using static System.FormattableString;
using MoreAppBuilder.Implementation.Model.Webhooks;

#nullable enable

namespace MoreAppBuilder.Implementation.Client
{
    /// AUTO GENERATED CLASS
    public partial class MoreAppSubscribersClient
    {
        private string _baseUri = null!;
        internal string BaseUri {
            get => _baseUri;
            set => _baseUri = value.EndsWith("/") ? value : $"{value}/";
        }
        internal HttpClient Client { get; }
        internal ILogger Logger { get; }
        internal ICaffoaParseErrorHandler ErrorHandler  { get; }
        internal ICaffoaJsonParser JsonParser { get; }
        internal ICaffoaJsonSerializer JsonSerializer { get; }
        private MoreAppSubscribersClient(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {
            BaseUri = baseUri;
            Client = client ?? new HttpClient();
            Logger = logger ?? NullLogger.Instance;
            JsonSerializer = jsonSerializer ?? new DefaultCaffoaResultHandler();
            ErrorHandler = errorHandler ?? new DefaultCaffoaErrorHandler(Logger, JsonSerializer);
            JsonParser = jsonParser ?? new DefaultCaffoaJsonParser(ErrorHandler);
        }
        partial void PrepareRequest(HttpRequestMessage msg);
        partial void ProcessResponse(HttpResponseMessage msg);

        /// <summary>
        /// Retrieves the details of a subscriber.
        /// 200 -> OK
        /// </summary>
        public async Task<Subscriber> GetWebhookSubscriberAsync(double customerId, string subscriberId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/subscribers/{subscriberId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<Subscriber>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Updates the subscriber by setting the values of the fields passed. All fields are required.
        /// 200 -> OK
        /// </summary>
        public async Task<Subscriber> UpdateWebhookSubscriberAsync(double customerId, string subscriberId, Subscriber payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/subscribers/{subscriberId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json");
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<Subscriber>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Irrevocably deletes the subscriber.
        /// 200 -> OK
        /// </summary>
        public async Task<Subscriber> DeleteWebhookSubscriberAsync(double customerId, string subscriberId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/subscribers/{subscriberId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<Subscriber>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Returns a list of subscribers for the given customer.
        /// 200 -> OK
        /// </summary>
        public async Task<IReadOnlyList<Subscriber>> GetWebhookSubscribersAsync(double customerId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/subscribers"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<Subscriber>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Creates and activates a new subscriber. There is a maximum number of subscribers you can have, so the request may fail.
        /// 200 -> OK
        /// </summary>
        public async Task<Subscriber> CreateWebhookSubscriberAsync(double customerId, Subscriber payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/subscribers"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json");
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<Subscriber>(resultStream);
            return resultObject;
        }
    }
}