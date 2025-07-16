using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace IncidentsDecisionMicroservices.Auth.Application.RabbitMqService
{
    public class RabbitMqService: IRabbitMqService, IDisposable
    {
        private IConnection? _connection;
        private IChannel? _channel;
        private readonly ConnectionFactory _factory;

        public RabbitMqService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public async Task InitializeAsync()
        {
            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
        }

        public void EnsureInitialized()
        {
            if (_connection == null || _channel == null)
            {
                throw new InvalidOperationException("Rabbit is not initialized. Call InitializeAsync first");
            }
        }

        public async Task ReceiveMessage(string queueName, Action<string> messageHandler)
        {
            EnsureInitialized();

            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                autoDelete: false,
                arguments: null
                );

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                messageHandler.Invoke(message);

                return Task.CompletedTask;
            };

            await _channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);
        }

        public async Task SendMessage(string queueName, string message)
        {
            EnsureInitialized();

            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                autoDelete: false,
                arguments: null
                );

            var body = Encoding.UTF8.GetBytes(message);
            await _channel.BasicPublishAsync(
                exchange: "",
                routingKey: queueName, 
                body: body);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
