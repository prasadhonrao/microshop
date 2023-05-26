using Customer.MicroService.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;

namespace Customer.MicroService.Services.Sync;

public class OrderDataService : IOrderDataService
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration configuration;
    private readonly ILogger<OrderDataService> logger;

    public OrderDataService(HttpClient client, IConfiguration configuration, ILogger<OrderDataService> logger)
    {
        this.httpClient = client;
        this.configuration = configuration;
        this.logger = logger;
    }

    public async Task<IEnumerable<OrderReadModel>?> GetOrders(int customerId) 
    {
        try
        {
            logger.LogInformation("Getting orders for customer " +  customerId);
            var orderServiceUrl = configuration["OrderServiceUrl"] + "/" + customerId + "/orders" ;

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
}