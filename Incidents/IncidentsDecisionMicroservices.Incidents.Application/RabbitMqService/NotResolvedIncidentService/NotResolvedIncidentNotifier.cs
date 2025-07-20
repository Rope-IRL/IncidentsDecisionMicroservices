using IncidentsDecisionMicroservices.Incidents.Core.Models.NotResolvedIncident;
using System.Text.Json;

namespace IncidentsDecisionMicroservices.Incidents.Application.RabbitMqService.NotResolvedIncidentService
{
    public class NotResolvedIncidentNotifier(IRabbitMqService rabbitMqService): INotResolvedIncidentNotifier
    {
        public readonly string QUEUE_NAME = "not_resolved_incident";

        public async Task SendMessageToQueue(NotResolvedIncident incident)
        {
            var jsonMessage = JsonSerializer.Serialize(incident);

            if (jsonMessage != null)
            {
                await rabbitMqService.SendMessage(QUEUE_NAME, jsonMessage);
            }
        }
    }
}
