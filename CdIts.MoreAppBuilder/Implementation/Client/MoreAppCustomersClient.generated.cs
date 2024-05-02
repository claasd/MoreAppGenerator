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
    public partial class MoreAppCustomersClient
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
        private MoreAppCustomersClient(string baseUri, HttpClient? client = null, ILogger? logger = null, ICaffoaParseErrorHandler? errorHandler = null, ICaffoaJsonParser? jsonParser = null, ICaffoaJsonSerializer? jsonSerializer = null) {
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
        /// Retrieves the customer with the given ID.
        /// 200 -> OK
        /// 400 -> Bad Request
        /// 404 -> Not Found
        /// </summary>
        public async Task<Customer> GetCustomerAsync(double customerId, CancellationToken cancellationToken = default) {
            var uriBuilder = new UriBuilder(Invariant($"{BaseUri}api/v1.0/customers/{customerId}"));
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
            var resultObject = await JsonParser.Parse<Customer>(resultStream);
            return resultObject;
        }
    }
}