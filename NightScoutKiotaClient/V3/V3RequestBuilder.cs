using Microsoft.Kiota.Abstractions;
using NightScoutV3.V3.Devicestatus;
using NightScoutV3.V3.Entries;
using NightScoutV3.V3.Food;
using NightScoutV3.V3.Lastmodified;
using NightScoutV3.V3.Profile;
using NightScoutV3.V3.Settings;
using NightScoutV3.V3.Status;
using NightScoutV3.V3.Treatments;
using NightScoutV3.V3.VersionNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace NightScoutV3.V3 {
    /// <summary>
    /// Builds and executes requests for operations under \v3
    /// </summary>
    public class V3RequestBuilder {
        /// <summary>The devicestatus property</summary>
        public DevicestatusRequestBuilder Devicestatus { get =>
            new DevicestatusRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The entries property</summary>
        public EntriesRequestBuilder Entries { get =>
            new EntriesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The food property</summary>
        public FoodRequestBuilder Food { get =>
            new FoodRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The lastmodified property</summary>
        public LastmodifiedRequestBuilder Lastmodified { get =>
            new LastmodifiedRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The profile property</summary>
        public ProfileRequestBuilder Profile { get =>
            new ProfileRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>The settings property</summary>
        public SettingsRequestBuilder Settings { get =>
            new SettingsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The status property</summary>
        public StatusRequestBuilder Status { get =>
            new StatusRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The treatments property</summary>
        public TreatmentsRequestBuilder Treatments { get =>
            new TreatmentsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>The version property</summary>
        public VersionRequestBuilder Version { get =>
            new VersionRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new V3RequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V3RequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Instantiates a new V3RequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public V3RequestBuilder(string rawUrl, IRequestAdapter requestAdapter) {
            if(string.IsNullOrEmpty(rawUrl)) throw new ArgumentNullException(nameof(rawUrl));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/v3";
            var urlTplParams = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(rawUrl)) urlTplParams.Add("request-raw-url", rawUrl);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
    }
}
