using Customer.MicroService.Models;
using Customer.MicroService.Services.Async;
using System.Net;
using System.Text.Json;

namespace Customer.MicroService.Services.Sync;

public class OrderService : IOrderService
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration configuration;
    private readonly ILogger<OrderService> logger;
    private readonly IMessageBusClient messageBusClient;

    public OrderService(HttpClient client, IConfiguration configuration, ILogger<OrderService> logger,
                            IMessageBusClient messageBusClient)
    {
        this.httpClient = client;
        this.configuration = configuration;
        this.logger = logger;
        this.messageBusClient = messageBusClient;
    }

    public async Task<IEnumerable<OrderReadModel>> GetOrders(int customerId) 
    {
        try
        {
            logger.LogInformation("Getting orders for customer " +  customerId);
            var orderServiceUrl = configuration["OrderServiceUrl"] + "/customer/" + customerId;

            var response = await httpClient.GetAsync(orderServiceUrl);
            logger.LogInformation($"Response: {response}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<OrderReadModel>>(
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            // Handle specific error scenarios or throw appropriate exceptions
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // Customer not found, return null or throw a custom exception
                return null;
            }
            else
            {
                // Other error scenarios, return null or throw a custom exception
                return null;
            }
        }
        catch (HttpRequestException ex)
        {
            logger.LogError($"Exception while retrieving orders for customer {customerId}. Message: {ex.Message}");
            throw; // Re-throw the exception to allow higher-level error handling
        }
    }

    public async Task PublishOrder(OrderPublishModel orderPublishModel)
    {
        try
        {
            // Convert OrderPublishModel to JSON string
            string jsonMessage = JsonSerializer.Serialize(orderPublishModel);

            bool isPublished = await messageBusClient.PublishMessage("order_exchange", jsonMessage);
            if (isPublished)
            {
                logger.LogInformation("Order published successfully to the message broker.");
            }
            else
            {
                logger.LogInformation("Failed to publish the order message to the message broker.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Exception while publishing order message to RabbitMQ: {ex.Message}");
            throw; // Re-throw the exception to allow higher-level error handling
        }
    }

}
