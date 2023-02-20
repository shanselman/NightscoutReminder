using System.Text.Json;

namespace NightscoutReminder
{

    /// <summary>
    /// This service class encapsulates the logic to fetch data from the Nightscout v2 API
    /// It uses the native HttpClient class to fetch the data and parses the JSON response using
    /// the System.Text.Json library.
    ///
    /// The NightScoutv3Service is an alterative implementation that uses the Kiota generated client to make calls
    /// to the Nightscout v3 API.  The Kiota generated client is a more robust implementation that supports
    /// authentication, serialization, and deserialization of the API responses. It also handles rate limiting and has 
    /// supports distributed tracing using OpenTelemetry.
    /// </summary>
    public class NightscoutV2Service
    {
        private HttpClient Client;
        private string? url;
        public NightscoutV2Service(string url)
        {
            this.url = url + "/api/v2";
            if (this.Client == null)
            {
                this.Client = new HttpClient();
            }
        }

        public async Task<(DateTimeOffset, DateTimeOffset)> GetSageCageExpiry()
        {
            DateTimeOffset sageExpires = DateTimeOffset.MinValue;
            DateTimeOffset cageExpires = DateTimeOffset.MinValue;
            var response = await this.Client.GetAsync($"{this.url}/properties/sage,cage");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonDocument.Parse(content);
                JsonElement root = json.RootElement;

                //CGM Sensor Expiration
                JsonElement sage = root.GetProperty("sage").GetProperty("Sensor Change");
                string epochSage = sage.GetProperty("treatmentDate").ToString();
                sageExpires = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(epochSage)).DateTime.AddDays(10);
                
                //Pump Expiration
                JsonElement cage = root.GetProperty("cage");
                string epochCage = cage.GetProperty("treatmentDate").ToString();
                cageExpires = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(epochCage)).DateTime.AddDays(3);
            }

            return (sageExpires, cageExpires);
        }
    }
}