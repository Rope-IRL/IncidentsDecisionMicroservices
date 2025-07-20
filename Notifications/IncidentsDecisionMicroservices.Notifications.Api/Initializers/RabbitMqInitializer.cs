using IncidentsDecisionMicroservices.Notifications.Application.RabbitMqService;

namespace IncidentsDecisionMicroservices.Notifications.Api.Initializers
{

    public class RabbitMqInitializer(IRabbitMqService rabbitMqService) : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await rabbitMqService.InitializeAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
