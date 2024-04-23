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
    public partial class MoreAppDatasourcesClient
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
        private MoreAppDatasourcesClient(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {
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
        /// Retrieves the datasource with the given ID.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public async Task<RestDataSource> GetSingleAsync(double customerId, string dataSourceId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/datasources/{dataSourceId}"));
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
            var resultObject = await JsonParser.Parse<RestDataSource>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Updates the given datasource configuration.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public async Task<RestDataSource> UpdateAsync(double customerId, string dataSourceId, RestCreateDataSource payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/datasources/{dataSourceId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json");
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
            var resultObject = await JsonParser.Parse<RestDataSource>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Deletes the given datasource.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public async Task DeleteAsync(double customerId, string dataSourceId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/datasources/{dataSourceId}"));
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

        /// <summary>
        /// Returns a list of your datasources.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// </summary>
        public async Task<IReadOnlyList<RestDataSource>> GetAllAsync(double customerId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/datasources"));
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
            var resultObject = await JsonParser.Parse<List<RestDataSource>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Creates a new datasource.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// </summary>
        public async Task<RestDataSource> CreateAsync(double customerId, RestCreateDataSource payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}/datasources"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json");
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
            var resultObject = await JsonParser.Parse<RestDataSource>(resultStream);
            return resultObject;
        }
    }
}