using Microsoft.Graph;
using Microsoft.Graph.Models;
using Azure.Identity;

namespace NightscoutReminder
{
    public class NightscoutReminder
    {
        private static GraphService? graphService;
        private static NightscoutV2Service? nightscoutV2Service;
        public static async Task Main(string[] args)
        {
            nightscoutV2Service = new NightscoutV2Service();
            graphService = new GraphService();

            var properties = await nightscoutV2Service.GetSageCageProperties();

            foreach (var property in properties)
            {
                var eventName = $"🧑‍⚕️ Nightscout reminder for your {property.Name?.ToLower()}";
                if (!await graphService.HasEvent(eventName, property.Expires))
                {
                    await graphService.AddEvent(eventName, property.Expires);
                    Console.WriteLine($"Added a new reminder for '{property.Name}' on {property.Expires}");
                }
            }
        }
    }
}