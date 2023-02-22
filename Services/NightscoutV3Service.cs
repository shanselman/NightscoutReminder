using System.Text.Json;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Abstractions.Authentication;
using NightScoutV3;
using NightScoutV3.Models;
using System.Threading.Tasks;

namespace NightscoutReminder
{

    /// <summary>
    /// This class is an example of creating an application specific service class to wrap calling a generated 
    /// Kiota API client (https://microsoft.github.io/kiota/get-started/).  
    /// There are several advantages to using this service class approach:
    /// 1. The usage of the generated client is isolated to this class and makes it easier to maintain the dependency on the service
    /// 2. This service class can be mocked for unit testing
    /// 3. The initialization of the kiota API client can be kept out of your main application code
    /// 4. The methods of this class can be used to simplify the usage of the API client for your specific use cases
    /// 5. Copilot gets good at guessing how to generate methods because all the examples are in this class.
    /// 6. This service can help to isolate the application from API version changes
    /// </summary>
    ///
    /// <remarks>
    /// The Kiota client is generated based of the OpenAPI description here https://github.com/apidescriptions/nightscout/blob/main/spec/cadl-output/%40cadl-lang/openapi3/openapi.yaml
    /// We did not use the official OpenAPI description because it describes the operations to access document collections
    /// in a generic way, however, there is no discriminator in the response to determine which document type is returned.
    /// This makes it difficult to deserialize the response into the correct document type.  The OpenAPI description
    /// used here is generated from a TypeSpec (fka CADL) description that makes it reasonable to describe
    /// the API in a manageable way.  https://github.com/apidescriptions/nightscout/blob/main/spec/main.cadl 
    /// 
    /// The Kiota client can be regenerated using the following command:
    /// 
    /// kiota update -o NightScoutKiotaClient --clean-output
    ///
    /// </remarks>

    public class NightscoutV3Service {

        public NightScoutClient client;
        
        public NightscoutV3Service(string hostUrl, string apiKey) {
            var authProvider = new ApiKeyAuthenticationProvider("token",apiKey,ApiKeyAuthenticationProvider.KeyLocation.QueryParameter);
            var requestAdapter = new HttpClientRequestAdapter(authProvider);
            requestAdapter.BaseUrl = hostUrl + "/api";
            client = new NightScoutClient(requestAdapter);
        }

        // Get a properties for the provided property
        // Currently only supports getting a single "property" as Kiota encodes commas in path parameters
        // and Nightscout does not support this.
        public async Task<Properties?> GetProperties(string property) {
            var response = await client.V2.Properties[property].GetAsync();
            return response;
        }

        // Get all properties
        public async Task<Properties?> GetAllProperties() {
            var response = await client.V2.Properties.GetAsync();
            return response;
        }

        // Get cage and sage properties from all properties
        public async Task<(DateTimeOffset, DateTimeOffset)> GetSageCageExpiry() {
            var response = await client.V2.Properties.GetAsync();
            var sageExpiry = DateTimeOffset.FromUnixTimeMilliseconds(response?.Sage?.SensorChange?.TreatmentDate ?? 0).AddDays(10);
            var cageExpiry = DateTimeOffset.FromUnixTimeMilliseconds(response?.Cage?.TreatmentDate ?? 0).AddDays(3);
            return (sageExpiry, cageExpiry);
        }

        // Get a list of Treatment documents
        public async Task<List<Treatment>> GetTreatments() {
            var response = await client.V3.Treatments.GetAsync();
            return response?.Result ?? new List<Treatment>();
        }

        // Get a Treatment document
        public async Task<Treatment?> GetTreatment(string id) {
            var response = await client.V3.Treatments[id].GetAsync();
            return response?.Result;
        }

        // Get history of Treatment documents
        public async Task<List<Treatment>> GetTreatmentHistory(DateTimeOffset since) {
            var response = await client.V3.Treatments.History[since.ToUnixTimeMilliseconds().ToString()].GetAsync();
            return response?.Result ?? new List<Treatment>();
        }

        // Get Status
        public async Task<StatusResult?> GetStatus() {
            var response = await client.V3.Status.GetAsync();
            return response?.Result;
        }   

        // Get a list of DeviceStatus documents
        public async Task<List<DeviceStatus>> GetDeviceStatuses() {
            var response = await client.V3.Devicestatus.GetAsync();
            return response?.Result ?? new List<DeviceStatus>();
        }
       
        public async Task<List<Treatment>> GetAllTreatmentHistory() {
            var response = await client.V3.Treatments.History.GetAsync();
            return response?.Result ?? new List<Treatment>();
        }
    }

}