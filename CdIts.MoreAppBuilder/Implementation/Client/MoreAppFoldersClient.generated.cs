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
    public partial class MoreAppFoldersClient
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
        private MoreAppFoldersClient(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {
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
        public async Task<FolderDto> MoveFormAsync(double customerId, string folderId, string formId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}/forms/{formId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public async Task<FolderDto> AddFormAsync(double customerId, string folderId, string formId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}/forms/{formId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// This doesn't delete the underlying form, just the reference from this folder
        /// 200 -> OK
        /// </summary>
        public async Task<FolderDto> RemoveFormAsync(double customerId, string folderId, string formId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}/forms/{formId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public async Task<FolderDto> MovePositionFormAsync(double customerId, string folderId, string formId, int position, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}/forms/{formId}/move/{position}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public async Task<IReadOnlyList<FolderDto>> GetFoldersByCustomerIdAsync(double customerId, ICollection<string>? filter = null, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders"));
            var queryBuilder = new QueryBuilder();
            if(filter != null)
                queryBuilder.Add("filter", Invariant($"{filter}"));
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
            var resultObject = await JsonParser.Parse<List<FolderDto>>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public async Task<FolderDto> CreateFolderAsync(double customerId, FolderDto payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders"));
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
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// 200 -> OK
        /// </summary>
        public async Task<FolderDto> GetFolderAsync(double customerId, string folderId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }

        /// <summary>
        /// Deletion is only permitted when all forms are removed from this folder
        /// 200 -> OK
        /// </summary>
        public async Task DeleteFolderAsync(double customerId, string folderId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}"));
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
        public async Task<FolderDto> UpdateFolderAsync(double customerId, string folderId, JsonPatch payload, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}customer/{customerId}/folders/{folderId}"));
            using var httpRequest = new HttpRequestMessage(HttpMethod.Patch, uriBuilder.ToString());
            httpRequest.Content = new StringContent(JsonSerializer.JsonString(payload), Encoding.UTF8, "application/json-patch+json");
            PrepareRequest(httpRequest);
            using var httpResult = await Client.SendAsync(httpRequest, cancellationToken);
            ProcessResponse(httpResult);
            if(!httpResult.IsSuccessStatusCode) {
                var errorData = await httpResult.Content.ReadAsStringAsync(cancellationToken);
                throw new CaffoaWebClientException((int)httpResult.StatusCode, errorData);
            }
            await using var resultStream = await httpResult.Content.ReadAsStreamAsync(cancellationToken);
            var resultObject = await JsonParser.Parse<FolderDto>(resultStream);
            return resultObject;
        }
    }
}