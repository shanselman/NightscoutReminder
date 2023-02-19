using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NightScoutV3.Models;
using NightScoutV3.V3.Profile.History.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace NightScoutV3.V3.Profile.History {
    /// <summary>
    /// Builds and executes requests for operations under \v3\profile\history
    /// </summary>
    public class HistoryRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>Gets an item from the NightScoutV3.v3.profile.history.item collection</summary>
        public WithLastModifiedItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("lastModified", position);
            return new WithLastModifiedItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new HistoryRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public HistoryRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3/profile/history{?limit*,fields*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new HistoryRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public HistoryRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3/profile/history{?limit*,fields*}";
            var urlTplParams = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(rawUrl)) urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// HISTORY operation is intended for continuous data synchronization with other systems.Every insertion, update and deletion will be included in the resulting JSON array of documents (since timestamp in `Last-Modified` request header value). All changes are listed chronologically in response with 200 HTTP status code. The maximum listed `srvModified` timestamp is also stored in `Last-Modified` and `ETag` response headers that you can use for future, directly following synchronization. You can also limit the array&apos;s length using `limit` parameter.Deleted documents will appear with `isValid` = `false` field.HISTORY operation has a fallback mechanism in place for documents, which were not created by API v3. For such documents `srvModified` is virtually assigned from the `date` field (for `entries` collection) or from the `created_at` field (for other collections).This operation requires `read` permission for the API and the collection (e.g. `api:treatments:read`)The only exception is the `settings` collection which requires `admin` permission (`api:settings:admin`), because the settings of each application should be isolated and kept secret. You need to know the concrete identifier to access the app&apos;s settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<HistoryResponse?> GetAsync(Action<HistoryRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<HistoryResponse> GetAsync(Action<HistoryRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", BadRequestFailedResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<HistoryResponse>(requestInfo, HistoryResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// HISTORY operation is intended for continuous data synchronization with other systems.Every insertion, update and deletion will be included in the resulting JSON array of documents (since timestamp in `Last-Modified` request header value). All changes are listed chronologically in response with 200 HTTP status code. The maximum listed `srvModified` timestamp is also stored in `Last-Modified` and `ETag` response headers that you can use for future, directly following synchronization. You can also limit the array&apos;s length using `limit` parameter.Deleted documents will appear with `isValid` = `false` field.HISTORY operation has a fallback mechanism in place for documents, which were not created by API v3. For such documents `srvModified` is virtually assigned from the `date` field (for `entries` collection) or from the `created_at` field (for other collections).This operation requires `read` permission for the API and the collection (e.g. `api:treatments:read`)The only exception is the `settings` collection which requires `admin` permission (`api:settings:admin`), because the settings of each application should be isolated and kept secret. You need to know the concrete identifier to access the app&apos;s settings.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<HistoryRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<HistoryRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new HistoryRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// HISTORY operation is intended for continuous data synchronization with other systems.Every insertion, update and deletion will be included in the resulting JSON array of documents (since timestamp in `Last-Modified` request header value). All changes are listed chronologically in response with 200 HTTP status code. The maximum listed `srvModified` timestamp is also stored in `Last-Modified` and `ETag` response headers that you can use for future, directly following synchronization. You can also limit the array&apos;s length using `limit` parameter.Deleted documents will appear with `isValid` = `false` field.HISTORY operation has a fallback mechanism in place for documents, which were not created by API v3. For such documents `srvModified` is virtually assigned from the `date` field (for `entries` collection) or from the `created_at` field (for other collections).This operation requires `read` permission for the API and the collection (e.g. `api:treatments:read`)The only exception is the `settings` collection which requires `admin` permission (`api:settings:admin`), because the settings of each application should be isolated and kept secret. You need to know the concrete identifier to access the app&apos;s settings.
        /// </summary>
        public class HistoryRequestBuilderGetQueryParameters {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Fields { get; set; }
#nullable restore
#else
            public string Fields { get; set; }
#endif
            public int? Limit { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class HistoryRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public HistoryRequestBuilderGetQueryParameters QueryParameters { get; set; } = new HistoryRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new historyRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public HistoryRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
