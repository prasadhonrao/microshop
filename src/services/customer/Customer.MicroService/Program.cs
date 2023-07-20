using Customer.MicroService.Data;
using Customer.MicroService.Repositories;
using Customer.MicroService.Services;
using Customer.MicroService.Services.Async;
using Customer.MicroService.Services.Sync;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using ILogger = Microsoft.Extensions.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();

ConfigureLogging(builder);

var loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog());

var logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation($"Environment: {builder.Environment.EnvironmentName}");

ConfigureDatabase(builder, logger, isDevelopment);

ConfigureServices(builder);

var app = builder.Build();

ConfigureApp(app);

app.Run();

void ConfigureLogging(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
        .WriteTo.File("logs/customer-microservice.log", rollingInterval: RollingInterval.Day)
        .WriteTo.Seq(builder.Configuration.GetSection("Logging:Seq:ServerUrl").Value)
        .CreateLogger();

    builder.Host.UseSerilog();

    // Log Order Service URL
    var orderServiceUrl = builder.Configuration.GetSection("OrderServiceUrl").Value;
    Log.Information($"Order Service URL: {orderServiceUrl}");
}

void ConfigureDatabase(WebApplicationBuilder builder, ILogger logger, bool isDevelopment)
{
    if (isDevelopment)
    {
        logger.LogInformation($"Using in-memory database");
        builder.Services.AddDbContext<CustomersDbContext>(options =>
        {
            options.UseInMemoryDatabase("CustomerDB"); // Use in-memory database in DEV environment
        });
    }
    else
    {
        var connectionString = builder.Configuration.GetConnectionString("CustomerDBConnectionString");
        var dbPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");
        if (!string.IsNullOrEmpty(dbPassword))
        {
            connectionString = connectionString.Replace("${SA_PASSWORD}", dbPassword);
        }
        logger.LogInformation($"Database Connection string: {connectionString}");

        builder.Services.AddDbContext<CustomersDbContext>(options =>
        {
            options.UseSqlServer(connectionString); // Use SQL Server database in production environment
        });
    }
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddScoped<ICustomerService, CustomerService>();
    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
    builder.Services.AddHttpClient<IOrderService, OrderService>();
    builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

    builder.Services.AddControllers(options =>
    {
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
        options.ReturnHttpNotAcceptable = true; // Return appropriate HTTP status code if client requested format is not supported by the service
    }).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    .AddXmlDataContractSerializerFormatters(); // Add XML support

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHealthChecks();
}

void ConfigureApp(WebApplication app)
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.UseHealthChecks("/api/health");
}
