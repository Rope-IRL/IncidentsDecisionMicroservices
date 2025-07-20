using IncidentsDecisionMicroservices.Notifications.Api.Hubs;
using IncidentsDecisionMicroservices.Notifications.Application.RabbitMqService;
using IncidentsDecisionMicroservices.Notifications.Core.Models;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace IncidentsDecisionMicroservices.Notifications.Api.BackgroundServices
{
    public class NotResolvedIncidentBackgroundService(
        IRabbitMqService rabbitMqService, 
        IHubContext<NotResolvedIncidentNotificationHub, 
            INotResolvedIncidentNotificationHub> hub) : BackgroundService
    {
        public readonly string QUEUE_NAME = "not_resolved_incident";

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await rabbitMqService.ReceiveMessage(QUEUE_NAME, async message =>
            {
                var incident = JsonSerializer.Deserialize<NotResolvedIncident>(message);

                if(incident != null)
                {
                    await hub.Clients.All.ReceiveMessage(incident);
                }
            });
        }
    }
}
