namespace NightscoutReminder
{
    public class NightscoutReminder
    {
        private static GraphService? graphService;
        private static NightscoutV2Service? nightscoutV2Service;
        private static NightscoutV3Service? nightscoutV3Service;
        public static async Task Main(string[] args)
        {
            var settings = Settings.LoadSettings();
            nightscoutV2Service = new NightscoutV2Service(settings.NightscoutUrl!);
            nightscoutV3Service = new NightscoutV3Service(settings.NightscoutUrl!, settings.ApiKey!);
            graphService = new GraphService(settings.ClientId!, settings.TenantId!, settings.Scopes!);

            var (sageExpiry, cageExpiry) = await nightscoutV3Service!.GetSageCageExpiry();

            await AddCalendarEvent(graphService, "Your Glucose Sensor is about to expire", "🚨", sageExpiry);
            await AddCalendarEvent(graphService, "Your Insulin Pump is about to expire", "🚨", cageExpiry);
            
            await AddTodoItem(graphService, "Your Glucose Sensor is about to expire", "🚨", sageExpiry);
            await AddTodoItem(graphService, "Your Insulin Pump is about to expire", "🚨", cageExpiry);
        }

        private static async Task AddCalendarEvent(GraphService graphService, string subject, string emoji, DateTimeOffset expires)
        {
            if(!await graphService.HasEvent(subject, expires))
            {          
                await graphService.AddEvent(subject, emoji, expires);      
                Console.WriteLine($"Reminder '{subject}' on {expires} was added");
            }
            else
            {
                Console.WriteLine($"Reminder '{subject}' on {expires} already exists");
            }
        }

        private static async Task AddTodoItem(GraphService graphService, string subject, string emoji, DateTimeOffset expires)
        {
            if (!await graphService.HasTodoItem(subject, expires))
            {
                await graphService.AddTodoItem(subject, emoji, expires);
                Console.WriteLine($"Task '{subject}' on {expires} was added");
            }
            else
            {
                Console.WriteLine($"Task '{subject}' on {expires} already exists");
            }
        }
    }
}