using Product.MicroService.Data;
using Product.MicroService.Repositories;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Get the current environment
var env = builder.Environment;

// Set up configuration sources
var configuration = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });
    var logger = loggerFactory.CreateLogger("Program");

// Add database context
if (env.IsDevelopment())
{
    // Use an in-memory database for development
    builder.Services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("ProductsInMemDb"));
    logger.LogInformation("Using In Memory Database");
}
else
{
    // Use SQL Server for production
    builder.Services.AddDbContext<ProductContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("products-db-production-connection-string")));
    logger.LogInformation("Using SQL Server database for production.");
}


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Initialize db
ProductContextInitializer.PrepareData(app, env.IsProduction());

app.Run();
