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
using MoreAppBuilder.Implementation.Model.Core;

#nullable enable

namespace MoreAppBuilder.Implementation.Client
{
    /// AUTO GENERATED CLASS
    public partial class MoreAppUsersClient
    {
        /// <summary>
        /// all servers from the openapi definition  
        /// </summary>
        public static string[] Servers => new string[] { "https://api.moreapp.com" };
        
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
        private MoreAppUsersClient(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {
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
        /// Gets all current grants for this specific user. Does not contain grants that are inherited from groups.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// </summary>
        public virtual async Task<IReadOnlyList<Grant>> GetGrantsAsync(double customerId, string userId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v2/customers/{customerId}/users/{userId}/grants"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<Grant>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Modifies the grants for specified user.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public virtual async Task<IReadOnlyList<Grant>> PatchGrantAsync(double customerId, string userId, RestGrantChange payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v2/customers/{customerId}/users/{userId}/grants"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Patch, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json");
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<Grant>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Returns a list of all users.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// </summary>
        public virtual async Task<IReadOnlyList<User>> GetUsersAsync(double customerId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/users"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                try
                {
                    if((int)httpResult.StatusCode == 400)
                        throw new CaffoaWebClientException<JsonError>(400, JsonParser.Parse<JsonError>(errorData), errorData);
                }
                catch (Exception e) when(e is not CaffoaWebClientException)
                {
                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
                }

                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<User>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Retrieves the user with the given ID.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public virtual async Task<User> GetUserAsync(double customerId, string userId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/users/{userId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                try
                {
                    if((int)httpResult.StatusCode == 400)
                        throw new CaffoaWebClientException<JsonError>(400, JsonParser.Parse<JsonError>(errorData), errorData);
                }
                catch (Exception e) when(e is not CaffoaWebClientException)
                {
                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
                }

                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<User>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Removes the user from the given customer.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public virtual async Task RemoveUser1Async(double customerId, string userId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/users/{userId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                try
                {
                    if((int)httpResult.StatusCode == 400)
                        throw new CaffoaWebClientException<JsonError>(400, JsonParser.Parse<JsonError>(errorData), errorData);
                }
                catch (Exception e) when(e is not CaffoaWebClientException)
                {
                    throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
                }

                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
        }
    }
}