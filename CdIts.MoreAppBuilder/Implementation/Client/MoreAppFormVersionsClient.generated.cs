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
using MoreAppBuilder.Implementation.Model.Forms;

#nullable enable

namespace MoreAppBuilder.Implementation.Client
{
    /// AUTO GENERATED CLASS
    public partial class MoreAppFormVersionsClient
    {
        /// <summary>
        /// all servers from the openapi definition  
        /// </summary>
        public static string[] Servers => new string[] { "https://api.moreapp.com/api/v1.0/forms" };
        
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
        private MoreAppFormVersionsClient(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {
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
        /// 200 -> OK
        /// </summary>
        public virtual async Task<FormVersionDto> GetFormVersionForForm1Async(double customerId, string formId, string formVersionId, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions/{formVersionId}"));
            var queryBuilder = new QueryBuilder();
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FormVersionDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Updating is only allowed for form versions with a non-FINAL status
        /// 200 -> OK
        /// </summary>
        public virtual async Task<FormVersionDto> UpdateFormVersion1Async(double customerId, string formId, string formVersionId, FormVersionDto payload, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions/{formVersionId}"));
            var queryBuilder = new QueryBuilder();
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
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
            var resultObject = await JsonParser.Parse<FormVersionDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Only form versions with status 'DRAFT' can be deleted.
        /// 200 -> OK
        /// </summary>
        public virtual async Task DeleteFormVersion1Async(double customerId, string formId, string formVersionId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions/{formVersionId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public virtual async Task<IReadOnlyList<FormVersionDto>> GetFormVersionsForForm1Async(double customerId, string formId, int? page = 0, int? size = 10, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions"));
            var queryBuilder = new QueryBuilder();
            if(page != null)
                queryBuilder.Add("page", Invariant($"{page}"));
            if(size != null)
                queryBuilder.Add("size", Invariant($"{size}"));
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<List<FormVersionDto>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 201 -> Created
        /// </summary>
        public virtual async Task<FormVersionDto> CreateFormVersion1Async(double customerId, string formId, FormVersionDto payload, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions"));
            var queryBuilder = new QueryBuilder();
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
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
            var resultObject = await JsonParser.Parse<FormVersionDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public virtual async Task<FormVersionDto> FinalizeFormVersion1Async(double customerId, string formId, string formVersionId, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions/{formVersionId}/finalize"));
            var queryBuilder = new QueryBuilder();
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FormVersionDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public virtual async Task<FormVersionCopyResponseDto> CopyFormVersionAsync(double customerId, string formId, string formVersionId, FormVersionCopyDto payload, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions/{formVersionId}/copy"));
            var queryBuilder = new QueryBuilder();
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
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
            var resultObject = await JsonParser.Parse<FormVersionCopyResponseDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public virtual async Task ValidateFormVersion1Async(double customerId, string formId, FormVersionDto payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/{formId}/versions/validate"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json");
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public virtual async Task<FormVersionDto> GetTemplateFormVersionAsync(double customerId, string formVersionId, string brandingId = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/forms/templates/{formVersionId}"));
            var queryBuilder = new QueryBuilder();
            if(brandingId != null)
                queryBuilder.Add("brandingId", brandingId);
            uriBuilder.Query = queryBuilder.ToString() ?? string.Empty;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FormVersionDto>(resultStream);
            return resultObject;
        }
    }
}