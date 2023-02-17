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
            var settings = Settings.LoadSettings();
            nightscoutV2Service = new NightscoutV2Service(settings.NightscoutUrl!);
            graphService = new GraphService(settings.ClientId!, settings.Scopes!);

            var properties = await nightscoutV2Service.GetSageCageProperties();

            foreach (var property in properties)
            {
                var eventName = $"🚨 Your {property.Name?.ToLower()} is about to expire";
                if (!await graphService.HasEvent(eventName, property.Expires))
                {
                    await graphService.AddEvent(eventName, property.Expires);
                    Console.WriteLine($"Reminder for '{property.Name}' on {property.Expires} was added");
                } else {
                    Console.WriteLine($"Reminder for '{property.Name}' on {property.Expires} already exists");
                }
            }
        }
    }
}