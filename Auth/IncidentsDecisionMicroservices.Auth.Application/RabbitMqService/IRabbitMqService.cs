namespace IncidentsDecisionMicroservices.Auth.Application.RabbitMqService
{
    public interface IRabbitMqService
    {
        public Task SendMessage(string queueName, string message);
        public Task ReceiveMessage(string queueName, Action<string> messageHandler);
        public Task InitializeAsync();
    }
}
