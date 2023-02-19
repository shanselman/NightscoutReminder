using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NightScoutV3.Models;
using NightScoutV3.V3.Settings.History;
using NightScoutV3.V3.Settings.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace NightScoutV3.V3.Settings {
    /// <summary>
    /// Builds and executes requests for operations under \v3\settings
    /// </summary>
    public class SettingsRequestBuilder {
        /// <summary>The history property</summary>
        public HistoryRequestBuilder History { get =>
            new HistoryRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>Gets an item from the NightScoutV3.v3.settings.item collection</summary>
        public WithIdentifierItemRequestBuilder this[string position] { get {
            var urlTplParams = new Dictionary<string, object>(PathParameters);
            if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("identifier", position);
            return new WithIdentifierItemRequestBuilder(urlTplParams, RequestAdapter);
        } }
        /// <summary>
        /// Instantiates a new SettingsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SettingsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3/settings{?filter_parameters*,sort*,sort%24desc*,limit*,skip*,fields*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new SettingsRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SettingsRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3/settings{?filter_parameters*,sort*,sort%24desc*,limit*,skip*,fields*}";
            var urlTplParams = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(rawUrl)) urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// General search operation through documents of one collection, matching the specified filtering criteria. You can apply&amp;#58;        1) filtering - combining any number of filtering parameters        2) ordering - using `sort` or `sort$desc` parameter        3) paging - using `limit` and `skip` parameters        If successful, HTTP 200 code is returned with JSON array of matching documents as a response content (it may be empty).        This operation requires `read` permission for the API and the collection (e.g. `*:*:read`, `api:*:read`, `*:treatments:read`, `api:treatments:read`).        The only exception is the `settings` collection which requires `admin` permission (`api:settings:admin`), because the settings of each application should be isolated and kept secret. You need to know the concrete identifier to access the app&apos;s settings.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<SettingsResponse?> GetAsync(Action<SettingsRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<SettingsResponse> GetAsync(Action<SettingsRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", BadRequestFailedResponse.CreateFromDiscriminatorValue},
                {"401", UnauthenticatedFailedResponse.CreateFromDiscriminatorValue},
                {"403", UnauthorizedFailedResponse.CreateFromDiscriminatorValue},
                {"404", NotFoundFailedResponse.CreateFromDiscriminatorValue},
                {"406", NotAcceptableFailedResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<SettingsResponse>(requestInfo, SettingsResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Using this operation you can insert new documents into collection. Normally the operation ends with 201 HTTP status code, `Last-Modified` and `Location` headers specified.`identifier` is included in response body or it can be parsed from the `Location` response header.When the document to post is marked as a duplicate (using rules described at `API3_DEDUP_FALLBACK_ENABLED` switch), the update operation takes place instead of inserting. In this case the original document in the collection is found and it gets updated by the actual operation POST body. Finally the operation ends with 200 HTTP status code along with `Last-Modified` and correct `Location` headers. The response body then includes `isDeduplication`=`true` and `deduplicatedIdentifier` fields.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `create` (and/or `update` for deduplication) permission for the API and the collection (e.g. `api:treatments:create` and `api:treatments:update`)
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<UpdatedDocument?> PostAsync(NightScoutV3.Models.Settings body, Action<SettingsRequestBuilderPostRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<UpdatedDocument> PostAsync(NightScoutV3.Models.Settings body, Action<SettingsRequestBuilderPostRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", BadRequestFailedResponse.CreateFromDiscriminatorValue},
                {"401", UnauthenticatedFailedResponse.CreateFromDiscriminatorValue},
                {"403", UnauthorizedFailedResponse.CreateFromDiscriminatorValue},
                {"404", NotFoundFailedResponse.CreateFromDiscriminatorValue},
                {"406", NotAcceptableFailedResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<UpdatedDocument>(requestInfo, UpdatedDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// General search operation through documents of one collection, matching the specified filtering criteria. You can apply&amp;#58;        1) filtering - combining any number of filtering parameters        2) ordering - using `sort` or `sort$desc` parameter        3) paging - using `limit` and `skip` parameters        If successful, HTTP 200 code is returned with JSON array of matching documents as a response content (it may be empty).        This operation requires `read` permission for the API and the collection (e.g. `*:*:read`, `api:*:read`, `*:treatments:read`, `api:treatments:read`).        The only exception is the `settings` collection which requires `admin` permission (`api:settings:admin`), because the settings of each application should be isolated and kept secret. You need to know the concrete identifier to access the app&apos;s settings.
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<SettingsRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<SettingsRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new SettingsRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Using this operation you can insert new documents into collection. Normally the operation ends with 201 HTTP status code, `Last-Modified` and `Location` headers specified.`identifier` is included in response body or it can be parsed from the `Location` response header.When the document to post is marked as a duplicate (using rules described at `API3_DEDUP_FALLBACK_ENABLED` switch), the update operation takes place instead of inserting. In this case the original document in the collection is found and it gets updated by the actual operation POST body. Finally the operation ends with 200 HTTP status code along with `Last-Modified` and correct `Location` headers. The response body then includes `isDeduplication`=`true` and `deduplicatedIdentifier` fields.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `create` (and/or `update` for deduplication) permission for the API and the collection (e.g. `api:treatments:create` and `api:treatments:update`)
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(NightScoutV3.Models.Settings body, Action<SettingsRequestBuilderPostRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(NightScoutV3.Models.Settings body, Action<SettingsRequestBuilderPostRequestConfiguration> requestConfiguration = default) {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new SettingsRequestBuilderPostRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// General search operation through documents of one collection, matching the specified filtering criteria. You can apply&amp;#58;        1) filtering - combining any number of filtering parameters        2) ordering - using `sort` or `sort$desc` parameter        3) paging - using `limit` and `skip` parameters        If successful, HTTP 200 code is returned with JSON array of matching documents as a response content (it may be empty).        This operation requires `read` permission for the API and the collection (e.g. `*:*:read`, `api:*:read`, `*:treatments:read`, `api:treatments:read`).        The only exception is the `settings` collection which requires `admin` permission (`api:settings:admin`), because the settings of each application should be isolated and kept secret. You need to know the concrete identifier to access the app&apos;s settings.
        /// </summary>
        public class SettingsRequestBuilderGetQueryParameters {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Fields { get; set; }
#nullable restore
#else
            public string Fields { get; set; }
#endif
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Filter_parameters { get; set; }
#nullable restore
#else
            public string Filter_parameters { get; set; }
#endif
            public int? Limit { get; set; }
            public int? Skip { get; set; }
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Sort { get; set; }
#nullable restore
#else
            public string Sort { get; set; }
#endif
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("sort%24desc")]
            public string? Sortdesc { get; set; }
#nullable restore
#else
            [QueryParameter("sort%24desc")]
            public string Sortdesc { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class SettingsRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public SettingsRequestBuilderGetQueryParameters QueryParameters { get; set; } = new SettingsRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new settingsRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public SettingsRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class SettingsRequestBuilderPostRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new settingsRequestBuilderPostRequestConfiguration and sets the default values.
            /// </summary>
            public SettingsRequestBuilderPostRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
