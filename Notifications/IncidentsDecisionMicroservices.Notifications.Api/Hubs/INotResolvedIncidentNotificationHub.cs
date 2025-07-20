using IncidentsDecisionMicroservices.Notifications.Core.Models;

namespace IncidentsDecisionMicroservices.Notifications.Api.Hubs
{
    public interface INotResolvedIncidentNotificationHub
    {
        public Task ReceiveMessage(NotResolvedIncident incident);
    }
}
