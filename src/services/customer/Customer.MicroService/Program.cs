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


// Throttle the thread pool 
//Console.WriteLine("ThreadPool limit: " + Environment.ProcessorCount);
//ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);


// Application specific services
//#if DEBUG
//Console.WriteLine("Using in memory database");
//builder.Services.AddDbContext<CustomerContext>(opt => opt.UseInMemoryDatabase("customer-microservice-db"));
//#else
var connectionString = builder.Configuration["ConnectionStrings:CustomerDBConnectionString"];
Console.WriteLine($"Connecting string : {connectionString}");
builder.Services.AddDbContext<CustomerContext>(opt => opt.UseSqlServer(connectionString));
//#endif

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
string? OrderServiceUrl = builder.Configuration.GetValue<string>("OrderServiceUrl");
Console.WriteLine("Order Service URL: " + OrderServiceUrl);

// Log Rabbit MQ Host URL
// string? RabbitMQHost = builder.Configuration.GetValue<string>("RabbitMQHost");
// string? RabbitMQPort = builder.Configuration.GetValue<string>("RabbitMQPort");
// Console.WriteLine("RabbitMQ URL: " + RabbitMQHost + RabbitMQPort);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();