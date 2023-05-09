using AutoMapper;
using Customer.MicroService.Models;
using Microsoft.Extensions.Configuration;

namespace Customer.MicroService.Services.Sync;

public class ProductDataService : IProductDataService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ProductDataService> _logger;

    public ProductDataService(HttpClient client, 
    IConfiguration configuration, 
    IMapper mapper,
    ILogger<ProductDataService> logger)
    {
        this._httpClient = client;
        this._configuration = configuration;
        this._logger = logger;
    }

    public async Task<IEnumerable<ProductReadModel>?> GetProducts()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<ProductReadModel>>(_configuration["ProductServiceUrl"]);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError("\nException Caught!");
            _logger.LogError("Message :{0} ", e.Message);
            return null;
        }
    }

}