using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace NightscoutReminder
{
  public class GraphService
  {
    private GraphServiceClient graphServiceClient;
    private string? clientId;
    private string[]? scopes;
    public GraphService(string clientId, string scopes)
    {
      this.clientId = clientId;
      this.scopes = scopes?.Split(',');

      DeviceCodeCredentialOptions deviceCodeCredentialOptions = new DeviceCodeCredentialOptions()
      {
        ClientId = this.clientId
      };

      DeviceCodeCredential deviceCodeCredential = new DeviceCodeCredential(deviceCodeCredentialOptions);

      //create client for calling v1 endpoint and get my info 
      this.graphServiceClient = new GraphServiceClient(deviceCodeCredential, this.scopes);
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
      var taskLists = await this.graphServiceClient.Me.Todo.Lists.GetAsync(r =>
      {
        r.QueryParameters.Filter = $"wellknownListName eq 'defaultList'";
      });

      if (taskLists?.Value?.Count > 0)
      {
        var taskList = taskLists.Value[0];

        var reminderTask = new TodoTask
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
        await this.graphServiceClient.Me.Todo.Lists[taskList.Id].Tasks.PostAsync(reminderTask);
      }
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