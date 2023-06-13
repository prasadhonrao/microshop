using Microsoft.AspNetCore.Mvc;

namespace Customer.MicroService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IConfiguration configuration;
    private readonly ILogger<HomeController> logger;

    public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
    {
        this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public IActionResult Get()
    {
        logger.LogInformation("Getting API version and environment");

        return Ok(new
        {
            Version = configuration["Version"],
            Environment = configuration["Environment"]
        });
    }
}
