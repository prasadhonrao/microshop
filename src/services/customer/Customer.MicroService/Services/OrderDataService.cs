using Microsoft.Extensions.Configuration;

namespace Customer.MicroService.Services;

public class OrderDataService : IOrderDataService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OrderDataService> _logger;

    public OrderDataService(HttpClient client, IConfiguration configuration, ILogger<OrderDataService> logger)
    {
        this._httpClient = client;
        this._configuration = configuration;
        this._logger = logger;
    }

    public async Task<string> GetOrders() 
    {
        try
        {
            string responseBody = await _httpClient.GetStringAsync(_configuration["OrderServiceUrl"]);
            _logger.LogInformation(responseBody);
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError("\nException Caught!");
            _logger.LogError("Message :{0} ", e.Message);
            return null;
        }
    }
}