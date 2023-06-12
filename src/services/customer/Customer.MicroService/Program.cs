using Customer.MicroService.Data;
using Customer.MicroService.Repositories;
using Customer.MicroService.Services;
//using Customer.MicroService.Services.Async;
using Customer.MicroService.Services.Sync;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure SeriLog
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/customer-microservice.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
builder.Host.UseSerilog();

// Retrieve an instance of ILoggerFactory
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddSerilog(); // Add Serilog to the LoggerFactory
});

// Create a logger instance using ILoggerFactory
var logger = loggerFactory.CreateLogger<Program>();

// Throttle the thread pool 
//Console.WriteLine("ThreadPool limit: " + Environment.ProcessorCount);
//ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);

// Application specific services

// Database configuration
var isDevelopment = builder.Environment.IsDevelopment();
var useInMemoryDb = isDevelopment; 

builder.Services.AddDbContext<CustomerContext>(options =>
{
    if (useInMemoryDb)
    {
        logger.LogInformation("Using in-memory database");
        options.UseInMemoryDatabase("InMemoryDb"); // In-memory database
    }
    else
    {
        logger.LogInformation("Using SQL Server database");
        options.UseSqlServer(builder.Configuration["ConnectionStrings:CustomerDBConnectionString"]); // Real SQL Server database
    }
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddHttpClient<IOrderDataService, OrderDataService>();
//builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; // Return appropriate HTTP status code if client requested format is not supported by the service
}).AddNewtonsoftJson() // Add JSON support
  .AddXmlDataContractSerializerFormatters(); // Add XML support

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Log Order Service URL
// string? orderServiceUrl = builder.Configuration.GetValue<string>("OrderServiceUrl");
// logger.LogInformation("Order Service URL: {orderServiceUrl}", orderServiceUrl);

// Log Rabbit MQ Host URL
// string? RabbitMQHost = builder.Configuration.GetValue<string>("RabbitMQHost");
// string? RabbitMQPort = builder.Configuration.GetValue<string>("RabbitMQPort");
// Console.WriteLine("RabbitMQ URL: " + RabbitMQHost + RabbitMQPort);

var app = builder.Build();

// This is required for Azure App Service
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        logger.LogInformation("Applying EF migrations...");
        var dbContext = services.GetRequiredService<CustomerContext>();
        dbContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while applying EF migrations.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();