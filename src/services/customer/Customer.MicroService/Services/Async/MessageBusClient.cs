using System.Text;
using RabbitMQ.Client;

namespace Customer.MicroService.Services.Async;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConfiguration configuration;
    private readonly ILogger<MessageBusClient> logger;
    private readonly IConnection connection;
    private readonly IModel channel;

    public MessageBusClient(IConfiguration configuration, 
                            ILogger<MessageBusClient> logger)
    {
        this.logger = logger;
        this.configuration = configuration;
        
        var factory = new ConnectionFactory() {
            HostName = this.configuration["RABBITMQ_HOST"],
            Port = int.Parse(this.configuration["RABBITMQ_PORT"])
        };

        try
        {
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "order_exchange", type: ExchangeType.Fanout);

            connection.ConnectionShutdown += (s, e) => {
                this.logger.LogInformation("Connection shut down");
            };

            this.logger.LogInformation("Connecting to RabbitMQ");
        }
        catch (Exception ex)
        {
            this.logger.LogError("Exception : Could not connect to RabbitMQ");
            this.logger.LogError(ex.StackTrace);
        }
    }

    public Task<bool> PublishMessage(string exchangeName, string message)
    {
        try
        {
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: exchangeName, routingKey: "", basicProperties: null, body: body);
            logger.LogInformation($"Message published to RabbitMQ exchange '{exchangeName}'.");
            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            logger.LogError($"Exception while publishing message to RabbitMQ: {ex.Message}");
            return Task.FromResult(false);
        }
    }
   
    public void Dispose() {
        logger.LogInformation("Disposing RabbitMQ");
        if (channel.IsOpen) {
            channel.Close();
            connection.Close();
        }
    }
}
