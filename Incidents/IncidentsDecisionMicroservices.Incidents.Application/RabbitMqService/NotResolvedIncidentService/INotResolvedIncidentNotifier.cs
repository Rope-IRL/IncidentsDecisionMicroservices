using IncidentsDecisionMicroservices.Incidents.Core.Models.NotResolvedIncident;

namespace IncidentsDecisionMicroservices.Incidents.Application.RabbitMqService.NotResolvedIncidentService
{
    public interface INotResolvedIncidentNotifier
    {
        public Task SendMessageToQueue(NotResolvedIncident incident);
    }
}
