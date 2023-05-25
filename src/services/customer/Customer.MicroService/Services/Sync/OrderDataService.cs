using Customer.MicroService.Models;
using Microsoft.Extensions.Configuration;
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
            Console.WriteLine("Response : " + response);

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<IEnumerable<OrderReadModel>>(
                    await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
            }
            return null;
        }
        catch (HttpRequestException e)
        {
            logger.LogError("\nException Caught!");
            logger.LogError("Message :{0} ", e.Message);
            return null;
        }
    }
}