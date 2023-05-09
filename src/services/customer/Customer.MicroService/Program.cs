using Customer.MicroService.Data;
using Customer.MicroService.Repositories;
using Customer.MicroService.Services.Async;
using Customer.MicroService.Services.Sync;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddHttpClient<IOrderDataService, OrderDataService>();
builder.Services.AddHttpClient<IProductDataService, ProductDataService>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Log Order Service URL
string? OrderServiceUrl = builder.Configuration.GetValue<string>("OrderServiceUrl");
System.Console.WriteLine("Order Service URL: " + OrderServiceUrl);

// Log Product Service URL
string? Product = builder.Configuration.GetValue<string>("ProductServiceUrl");
System.Console.WriteLine("Product Service URL: " + Product);

// Log Product Service URL
string? RabbitMQHost = builder.Configuration.GetValue<string>("RabbitMQHost");
string? RabbitMQPort = builder.Configuration.GetValue<string>("RabbitMQPort");
System.Console.WriteLine("RabbitMQ URL: " + RabbitMQHost + RabbitMQPort);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Initialize db
CustomerContextInitializer.PrepareData(app);

app.Run();
