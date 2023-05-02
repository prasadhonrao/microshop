using System;
using Customer.MicroService.Data;
using Customer.MicroService.Repositories;
using Customer.MicroService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddHttpClient<IOrderDataService, OrderDataService>();
builder.Services.AddHttpClient<IProductDataService, ProductDataService>();
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
