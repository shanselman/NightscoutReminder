using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace NightscoutReminder
{
    public class GraphService
    {
        private GraphServiceClient? graphServiceClient;
        private string? clientId;
        private string[]? scopes;
        public GraphService(string clientId, string tenantId, string[] scopes)
        {
            this.clientId = clientId;
            this.scopes = scopes;

            InteractiveBrowserCredential credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions
            {
                ClientId = this.clientId,
                TenantId = tenantId
            });

            this.graphServiceClient = new GraphServiceClient(credential, this.scopes);
        }

        public async Task AddEvent(string subject, string emoji, DateTimeOffset expires)
        {
            var reminderEvent = new Event
            {
                Subject = String.IsNullOrEmpty(emoji) ? $"{subject}" : $"{emoji} {subject}",
                Start = new DateTimeTimeZone
                {
                    DateTime = expires.ToUniversalTime().ToString("o"),
                    TimeZone = TimeZoneInfo.Utc.Id
                },
                End = new DateTimeTimeZone
                {
                    DateTime = expires.ToUniversalTime().AddHours(1).ToString("o"),
                    TimeZone = TimeZoneInfo.Utc.Id
                }
            };

            // Add the event to the user's calendar
            await this.graphServiceClient!.Me.Calendar.Events.PostAsync(reminderEvent);
        }

        public async Task<bool> HasEvent(string subject, DateTimeOffset expires)
        {
            // check if the reminder already exists
            var events = await this.graphServiceClient!.Me.Calendar.Events.GetAsync(r =>
            {
                r.QueryParameters.Filter = $"contains(subject, '{subject}') and start/dateTime eq '{expires.ToUniversalTime().ToString("o")}'";
            });

            return events?.Value?.Count > 0;
        }

        // add a todo item from the nightscout properties to microsoft graph
        public async Task AddTodoItem(string subject, string emoji, DateTimeOffset expires)
        {
            // check if the reminder already exists
            var taskList = await this.GetDefaultTaskList();

            if (taskList != null)
            {
                var reminderTask = new TodoTask
                {
                    Title = String.IsNullOrEmpty(emoji) ? $"{subject}" : $"{emoji} {subject}",
                    DueDateTime = new DateTimeTimeZone
                    {
                        DateTime = expires.Date.ToString("o"),
                        TimeZone = TimeZoneInfo.Utc.Id
                    }
                };

                // Add the event to the user's calendar
                await this.graphServiceClient!.Me.Todo.Lists[taskList.Id].Tasks.PostAsync(reminderTask);
            }
        }

        // Get default task list from graph api
        public async Task<TodoTaskList?> GetDefaultTaskList()
        {
            try
            {
                var taskLists = await this.graphServiceClient!.Me.Todo.Lists.GetAsync(r =>
                {
                    r.QueryParameters.Top = 100;
                });

                if (taskLists?.Value?.Count > 0)
                {
                    // get the first task list that is the default list
                    return taskLists?.Value?.FirstOrDefault(l => l.WellknownListName == WellknownListName.DefaultList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        // check if a todo item already exists
        public async Task<bool> HasTodoItem(string subject, DateTimeOffset expires)
        {
            // check if the reminder already exists
            var taskList = await this.GetDefaultTaskList();

            if (taskList != null)
            {
                var tasks = await this.graphServiceClient!.Me.Todo.Lists[taskList.Id].Tasks.GetAsync(r =>
                {
                    r.QueryParameters.Filter = $"contains(title, '{subject}') and dueDateTime/dateTime eq '{expires.Date.ToString("o")}'";
                });

                return tasks?.Value?.Count > 0;
            }

            return false;
        }

        // get user information from microsoft graph
        public async Task<User?> GetMe()
        {
            return await this.graphServiceClient!.Me.GetAsync();
        }

        // get user's presence information from microsoft graph
        public async Task<Presence?> GetPresence()
        {
            return await this.graphServiceClient!.Me.Presence.GetAsync();
        }
    }
}