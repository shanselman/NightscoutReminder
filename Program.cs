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
                var subject = $"🚨 Your {property.Name?.ToLower()} is about to expire";
                await AddCalendarEvent(graphService, subject, property.Expires);
                await AddTodoItem(graphService, subject, property.Expires);
            }
        }

        private static async Task AddCalendarEvent(GraphService graphService, string subject, DateTime expires)
        {
            if (!await graphService.HasEvent(subject, expires))
            {
                await graphService.AddEvent(subject, expires);
                Console.WriteLine($"Reminder '{subject}' on {expires} was added");
            }
            else
            {
                Console.WriteLine($"Reminder '{subject}' on {expires} already exists");
            }
        }

        private static async Task AddTodoItem(GraphService graphService, string subject, DateTime expires)
        {
            if (!await graphService.HasTodoItem(subject, expires))
            {
                await graphService.AddTodoItem(subject, expires);
                Console.WriteLine($"Task '{subject}' on {expires} was added");
            }
            else
            {
                Console.WriteLine($"Task '{subject}' on {expires} already exists");
            }
        }
    }
}