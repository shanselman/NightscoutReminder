using System.Text.Json;

namespace NightscoutReminder
{
    public class NightscoutV2Service
    {
        // Create an HttpClient instance           
        private HttpClient Client;
        // Define the Nightscout URL
        private readonly string Url = "https://hanselsugar.herokuapp.com/api/v2/properties/cage,sage";
        public NightscoutV2Service()
        {
            if (this.Client == null)
            {
                this.Client = new HttpClient();
            }
        }

        public async Task<List<NightscoutProperty>> GetSageCageProperties()
        {
            var fetchedProperties = new List<NightscoutProperty>();
            var response = await this.Client.GetAsync(this.Url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonDocument.Parse(content);
                JsonElement root = json.RootElement;

                //Pump Expiration
                JsonElement cage = root.GetProperty("cage");
                string epochCage = cage.GetProperty("treatmentDate").ToString();
                DateTime pumpExpires = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(epochCage)).DateTime.AddDays(3);

                fetchedProperties.Add(new NightscoutProperty
                {
                    Name = "Pump",
                    Expires = pumpExpires
                });

                Console.WriteLine($"Pump Expires: {pumpExpires}");

                //CGM Sensor Expiration
                JsonElement sage = root.GetProperty("sage").GetProperty("Sensor Change");
                string epochSage = sage.GetProperty("treatmentDate").ToString();
                DateTime sensorExpires = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(epochSage)).DateTime.AddDays(10);
                Console.WriteLine($"Sensor Expires: {sensorExpires}");

                fetchedProperties.Add(new NightscoutProperty
                {
                    Name = "Sensor",
                    Expires = sensorExpires
                });
            }

            return fetchedProperties;
        }
    }
}