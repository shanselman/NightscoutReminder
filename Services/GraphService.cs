using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace NightscoutReminder
{
    public class GraphService
    {
        private GraphServiceClient graphServiceClient;

        private static string clientId = "3bf02644-326f-4b34-bf85-ba7ff63fd1e9";
        private static string[] scopes = { "Calendars.ReadWrite" };
        public GraphService()
        {
            DeviceCodeCredentialOptions deviceCodeCredentialOptions = new DeviceCodeCredentialOptions()
            {
                ClientId = clientId
            };

            DeviceCodeCredential deviceCodeCredential = new DeviceCodeCredential(deviceCodeCredentialOptions);

            //create client for calling v1 endpoint and get my info 
            this.graphServiceClient = new GraphServiceClient(deviceCodeCredential, scopes);
        }

        public async Task AddEvent(string subject, DateTime expires)
        {
            // check if the reminder already exists
            var events = await this.graphServiceClient.Me.Calendar.Events.GetAsync(r =>
            {
                r.QueryParameters.Filter = $"subject eq '{subject}'";
            });

            if (events?.Value?.Count > 0)
            {
                return;
            }
            var reminderEvent = new Event
            {
                Subject = subject,
                Start = new DateTimeTimeZone
                {
                    DateTime = expires.ToString("o"),
                    TimeZone = TimeZoneInfo.Local.Id
                },
                End = new DateTimeTimeZone
                {
                    DateTime = expires.AddHours(1).ToString("o"),
                    TimeZone = TimeZoneInfo.Local.Id
                }
            };

            // Add the event to the user's calendar
            await this.graphServiceClient.Me.Calendar.Events.PostAsync(reminderEvent);
        }

        public async Task<bool> HasEvent(string subject, DateTime expires)
        {
            // check if the reminder already exists
            var events = await this.graphServiceClient.Me.Calendar.Events.GetAsync(r =>
            {
                r.QueryParameters.Filter = $"subject eq '{subject}' and start/dateTime eq '{expires.ToString("o")}'";
            });

            return events?.Value?.Count > 0;
        }

        // add a todo item from the nightscout properties to microsoft graph
        public async Task AddTodoItem(string subject, DateTime expires)
        {
            // check if the reminder already exists
            var events = await this.graphServiceClient.Me.Todo.Lists.GetAsync(r =>
            {
                r.QueryParameters.Filter = $"subject eq '{subject}'";
            });

            if (events?.Value?.Count > 0)
            {
                return;
            }
            var reminderTasks = new TodoTask
            {
                Title = subject,
                StartDateTime = new DateTimeTimeZone
                {
                    DateTime = expires.ToString("o"),
                    TimeZone = TimeZoneInfo.Local.Id
                },
                DueDateTime = new DateTimeTimeZone
                {
                    DateTime = expires.AddHours(1).ToString("o"),
                    TimeZone = TimeZoneInfo.Local.Id
                }
            };

            // Add the event to the user's calendar
            await this.graphServiceClient.Me.Todo.Lists[""].Tasks.PostAsync(reminderTasks);
        }

        // get user information from microsoft graph
        public async Task<User?> GetMe()
        {
            return await this.graphServiceClient.Me.GetAsync();
        }

        // get user's presence information from microsoft graph
        public async Task<Presence?> GetPresence()
        {
            return await this.graphServiceClient.Me.Presence.GetAsync();
        }
    }
}