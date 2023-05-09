using System.Text;
using System.Text.Json;
using Customer.MicroService.Models;
using RabbitMQ.Client;

namespace Customer.MicroService.Services.Async;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<MessageBusClient> _logger;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public MessageBusClient(IConfiguration configuration, 
                            ILogger<MessageBusClient> logger)
    {
        _logger = logger;
        _configuration = configuration;
        
        var factory = new ConnectionFactory() {
            HostName = _configuration["RabbitMQHost"],
            Port = int.Parse(_configuration["RabbitMQPort"])
        };

        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

            _connection.ConnectionShutdown += (s, e) => {
                _logger.LogInformation("Connection shut down");
            };

            _logger.LogInformation("Connecting to RabbitMQ");
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception : Could not connect to RabbitMQ");
            _logger.LogError(ex.StackTrace);
        }
    }
    public void CreateNewOrder(OrderCreateModel order)
    {
        var message = JsonSerializer.Serialize(order);
        if (_connection.IsOpen) {
            _logger.LogInformation($"RabbitMQ connection open, sending message {message}...");
            SendMessage(message);
        } else {
            _logger.LogWarning("RabbitMQ connection closed, can not send the message...");
        }
    }

    private void SendMessage(string message) {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "trigger", routingKey:"", basicProperties: null, body: body);
        _logger.LogInformation("Message sent successfully");
    }

    public void Dispose() {
        _logger.LogInformation("Disposing RabbitMQ");
        if (_channel.IsOpen) {
            _channel.Close();
            _connection.Close();
        }
    }
}