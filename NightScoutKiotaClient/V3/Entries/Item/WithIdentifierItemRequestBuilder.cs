using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using NightScoutV3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace NightScoutV3.V3.Entries.Item {
    /// <summary>
    /// Builds and executes requests for operations under \v3\entries\{identifier}
    /// </summary>
    public class WithIdentifierItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Instantiates a new WithIdentifierItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithIdentifierItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3/entries/{identifier}{?fields*,permanent*}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new WithIdentifierItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithIdentifierItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3/entries/{identifier}{?fields*,permanent*}";
            var urlTplParams = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(rawUrl)) urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// If the document has already been deleted, the operation will succeed anyway. Normally, documents are not really deleted from the collection but they are only marked as deleted. For special cases the deletion can be irreversible using `permanent` parameter.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `delete` permission for the API and the collection (e.g. `api:treatments:delete`)
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithIdentifierResponse?> DeleteAsync(Action<WithIdentifierItemRequestBuilderDeleteRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithIdentifierResponse> DeleteAsync(Action<WithIdentifierItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToDeleteRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"401", UnauthenticatedFailedResponse.CreateFromDiscriminatorValue},
                {"403", UnauthorizedFailedResponse.CreateFromDiscriminatorValue},
                {"404", NotFoundFailedResponse.CreateFromDiscriminatorValue},
                {"422", WithIdentifier422Error.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithIdentifierResponse>(requestInfo, WithIdentifierResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Basically this operation looks for a document matching the `identifier` field returning 200 or 404 HTTP status code.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When `If-Modified-Since` header is used and its value is greater than the timestamp of the document in the collection, 304 HTTP status code with empty response content is returned. It means that the document has not been modified on server since the last retrieval to client side.With `If-Modified-Since` header and less or equal timestamp `srvModified` a normal 200 HTTP status with full response is returned.This operation requires `read` permission for the API and the collection (e.g. `api:treatments:read`)
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<WithIdentifierResponse?> GetAsync(Action<WithIdentifierItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<WithIdentifierResponse> GetAsync(Action<WithIdentifierItemRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", BadRequestFailedResponse.CreateFromDiscriminatorValue},
                {"401", UnauthenticatedFailedResponse.CreateFromDiscriminatorValue},
                {"404", NotFoundFailedResponse.CreateFromDiscriminatorValue},
                {"406", NotAcceptableFailedResponse.CreateFromDiscriminatorValue},
                {"410", GoneFailedResponse.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<WithIdentifierResponse>(requestInfo, WithIdentifierResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Normally the document with the matching `identifier` will be retrieved from the collection and it will be patched by all specified fields from the JSON request body. Finally 200 HTTP status code will be returned.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When no document with `identifier` has been found in the collection, then the operation ends with 404 HTTP status code.You can also specify `If-Unmodified-Since` request header including your timestamp of document&apos;s last modification. If the document has been modified by somebody else on the server afterwards (and you do not know about it), the 412 HTTP status code is returned cancelling the update operation. You can use this feature to prevent race condition problems.`PATCH` operation can save some bandwidth for incremental document updates in comparison with `GET` - `UPDATE` operation sequence.While patching the document, the field `modifiedBy` is automatically set to the authorized subject&apos;s name.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `update` permission for the API and the collection (e.g. `api:treatments:update`)
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<UpdatedDocument?> PatchAsync(Action<WithIdentifierItemRequestBuilderPatchRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<UpdatedDocument> PatchAsync(Action<WithIdentifierItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToPatchRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", BadRequestFailedResponse.CreateFromDiscriminatorValue},
                {"401", UnauthenticatedFailedResponse.CreateFromDiscriminatorValue},
                {"403", UnauthorizedFailedResponse.CreateFromDiscriminatorValue},
                {"404", NotFoundFailedResponse.CreateFromDiscriminatorValue},
                {"410", GoneFailedResponse.CreateFromDiscriminatorValue},
                {"412", UpdatedDocument412Error.CreateFromDiscriminatorValue},
                {"422", UpdatedDocument422Error.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<UpdatedDocument>(requestInfo, UpdatedDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// Normally the document with the matching `identifier` will be replaced in the collection by the whole JSON request body and 200 HTTP status code will be returned.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When no document with `identifier` has been found in the collection, then an insert operation takes place instead of updating. Finally 201 HTTP status code is returned with only `Last-Modified` header (`identifier` is already known from the path parameter).You can also specify `If-Unmodified-Since` request header including your timestamp of document&apos;s last modification. If the document has been modified by somebody else on the server afterwards (and you do not know about it), the 412 HTTP status code is returned cancelling the update operation. You can use this feature to prevent race condition problems.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `update` (and/or `create`) permission for the API and the collection (e.g. `api:treatments:update` and `api:treatments:create`)
        /// </summary>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<UpdatedDocument?> PutAsync(Action<WithIdentifierItemRequestBuilderPutRequestConfiguration>? requestConfiguration = default, CancellationToken cancellationToken = default) {
#nullable restore
#else
        public async Task<UpdatedDocument> PutAsync(Action<WithIdentifierItemRequestBuilderPutRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default) {
#endif
            var requestInfo = ToPutRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                {"400", BadRequestFailedResponse.CreateFromDiscriminatorValue},
                {"401", UnauthenticatedFailedResponse.CreateFromDiscriminatorValue},
                {"403", UnauthorizedFailedResponse.CreateFromDiscriminatorValue},
                {"404", NotFoundFailedResponse.CreateFromDiscriminatorValue},
                {"410", GoneFailedResponse.CreateFromDiscriminatorValue},
                {"412", UpdatedDocument412Error.CreateFromDiscriminatorValue},
                {"422", UpdatedDocument422Error.CreateFromDiscriminatorValue},
            };
            return await RequestAdapter.SendAsync<UpdatedDocument>(requestInfo, UpdatedDocument.CreateFromDiscriminatorValue, errorMapping, cancellationToken);
        }
        /// <summary>
        /// If the document has already been deleted, the operation will succeed anyway. Normally, documents are not really deleted from the collection but they are only marked as deleted. For special cases the deletion can be irreversible using `permanent` parameter.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `delete` permission for the API and the collection (e.g. `api:treatments:delete`)
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<WithIdentifierItemRequestBuilderDeleteRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<WithIdentifierItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithIdentifierItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Basically this operation looks for a document matching the `identifier` field returning 200 or 404 HTTP status code.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When `If-Modified-Since` header is used and its value is greater than the timestamp of the document in the collection, 304 HTTP status code with empty response content is returned. It means that the document has not been modified on server since the last retrieval to client side.With `If-Modified-Since` header and less or equal timestamp `srvModified` a normal 200 HTTP status with full response is returned.This operation requires `read` permission for the API and the collection (e.g. `api:treatments:read`)
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<WithIdentifierItemRequestBuilderGetRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<WithIdentifierItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithIdentifierItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Normally the document with the matching `identifier` will be retrieved from the collection and it will be patched by all specified fields from the JSON request body. Finally 200 HTTP status code will be returned.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When no document with `identifier` has been found in the collection, then the operation ends with 404 HTTP status code.You can also specify `If-Unmodified-Since` request header including your timestamp of document&apos;s last modification. If the document has been modified by somebody else on the server afterwards (and you do not know about it), the 412 HTTP status code is returned cancelling the update operation. You can use this feature to prevent race condition problems.`PATCH` operation can save some bandwidth for incremental document updates in comparison with `GET` - `UPDATE` operation sequence.While patching the document, the field `modifiedBy` is automatically set to the authorized subject&apos;s name.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `update` permission for the API and the collection (e.g. `api:treatments:update`)
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPatchRequestInformation(Action<WithIdentifierItemRequestBuilderPatchRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPatchRequestInformation(Action<WithIdentifierItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithIdentifierItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Normally the document with the matching `identifier` will be replaced in the collection by the whole JSON request body and 200 HTTP status code will be returned.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When no document with `identifier` has been found in the collection, then an insert operation takes place instead of updating. Finally 201 HTTP status code is returned with only `Last-Modified` header (`identifier` is already known from the path parameter).You can also specify `If-Unmodified-Since` request header including your timestamp of document&apos;s last modification. If the document has been modified by somebody else on the server afterwards (and you do not know about it), the 412 HTTP status code is returned cancelling the update operation. You can use this feature to prevent race condition problems.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `update` (and/or `create`) permission for the API and the collection (e.g. `api:treatments:update` and `api:treatments:create`)
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPutRequestInformation(Action<WithIdentifierItemRequestBuilderPutRequestConfiguration>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToPutRequestInformation(Action<WithIdentifierItemRequestBuilderPutRequestConfiguration> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PUT,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new WithIdentifierItemRequestBuilderPutRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// If the document has already been deleted, the operation will succeed anyway. Normally, documents are not really deleted from the collection but they are only marked as deleted. For special cases the deletion can be irreversible using `permanent` parameter.This operation provides autopruning of the collection (if autopruning is enabled).This operation requires `delete` permission for the API and the collection (e.g. `api:treatments:delete`)
        /// </summary>
        public class WithIdentifierItemRequestBuilderDeleteQueryParameters {
            public bool? Permanent { get; set; }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithIdentifierItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithIdentifierItemRequestBuilderDeleteQueryParameters QueryParameters { get; set; } = new WithIdentifierItemRequestBuilderDeleteQueryParameters();
            /// <summary>
            /// Instantiates a new WithIdentifierItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public WithIdentifierItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Basically this operation looks for a document matching the `identifier` field returning 200 or 404 HTTP status code.If the document has been found in the collection but it had already been deleted, 410 HTTP status code is to be returned.When `If-Modified-Since` header is used and its value is greater than the timestamp of the document in the collection, 304 HTTP status code with empty response content is returned. It means that the document has not been modified on server since the last retrieval to client side.With `If-Modified-Since` header and less or equal timestamp `srvModified` a normal 200 HTTP status with full response is returned.This operation requires `read` permission for the API and the collection (e.g. `api:treatments:read`)
        /// </summary>
        public class WithIdentifierItemRequestBuilderGetQueryParameters {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            public string? Fields { get; set; }
#nullable restore
#else
            public string Fields { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithIdentifierItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public WithIdentifierItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new WithIdentifierItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new WithIdentifierItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public WithIdentifierItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithIdentifierItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new WithIdentifierItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public WithIdentifierItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        public class WithIdentifierItemRequestBuilderPutRequestConfiguration {
            /// <summary>Request headers</summary>
            public RequestHeaders Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new WithIdentifierItemRequestBuilderPutRequestConfiguration and sets the default values.
            /// </summary>
            public WithIdentifierItemRequestBuilderPutRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new RequestHeaders();
            }
        }
    }
}
