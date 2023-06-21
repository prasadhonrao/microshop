using Customer.MicroService.Data;
using Customer.MicroService.Repositories;
using Customer.MicroService.Services;
//using Customer.MicroService.Services.Async;
using Customer.MicroService.Services.Sync;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();

// Configure SeriLog
#pragma warning disable CS8604 // Possible null reference argument.
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
            .WriteTo.File("logs/customer-microservice.log", rollingInterval: RollingInterval.Day)
            .WriteTo.Seq(builder.Configuration.GetSection("Logging:Seq:ServerUrl").Value)
            .CreateLogger();
#pragma warning restore CS8604 // Possible null reference argument.

builder.Host.UseSerilog();

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSerilog(); // Add Serilog to the LoggerFactory
});

// Create a logger instance using ILoggerFactory
var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation($"Environment: {builder.Environment.EnvironmentName}");

var seqURL = builder.Configuration.GetSection("Logging:Seq:ServerUrl").Value;
logger.LogInformation($"Seq URL: {seqURL}");

var connectionString = builder.Configuration.GetConnectionString("CustomerDBConnectionString");
logger.LogInformation($"Database Connection string: {connectionString}");

// Database configuration
builder.Services.AddDbContext<CustomersDbContext>(options =>
{
    options.UseSqlServer(connectionString); 
});

// Application specific services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddHttpClient<IOrderDataService, OrderDataService>();
//builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

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

//if (!isDevelopment)
//{
//    builder.Services.AddDiscoveryClient(builder.Configuration);
//}

// Log Order Service URL
// string? orderServiceUrl = builder.Configuration.GetValue<string>("OrderServiceUrl");
// logger.LogInformation("Order Service URL: {orderServiceUrl}", orderServiceUrl);

// Log Rabbit MQ Host URL
// string? RabbitMQHost = builder.Configuration.GetValue<string>("RabbitMQHost");
// string? RabbitMQPort = builder.Configuration.GetValue<string>("RabbitMQPort");
// Console.WriteLine("RabbitMQ URL: " + RabbitMQHost + RabbitMQPort);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// if (!isDevelopment)
// {
//    app.UseDiscoveryClient();
// }

app.UseHealthChecks("/api/health");

app.Run();