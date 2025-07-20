using IncidentsDecisionMicroservices.Notifications.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace IncidentsDecisionMicroservices.Notifications.Api.Hubs
{
    public class NotResolvedIncidentNotificationHub : Hub<INotResolvedIncidentNotificationHub>
    {
        public async Task ReceiveMessage(NotResolvedIncident incident)
        {
            Console.WriteLine("Message receive called");
            await Clients.All.ReceiveMessage(incident);
        }
    }
}
