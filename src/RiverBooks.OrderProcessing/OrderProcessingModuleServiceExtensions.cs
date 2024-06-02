using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiverBooks.OrderProcessing.Data;
using Serilog;

namespace RiverBooks.OrderProcessing;

public static class OrderProcessingModuleServiceExtensions
{
  public static IServiceCollection AddOrderProcessingModuleServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger,
    List<System.Reflection.Assembly> mediatRAssemblies)
  {
    string? connection = config.GetConnectionString("OrderProcessingConnectionString");
    
    services.AddDbContext<OrderProcessingDbContext>(options => 
      options.UseSqlServer(connection));

    services.AddScoped<IOrderRepository, EfOrderRepository>();  

    // Because we're using MediatR, add the assembly to the list
    mediatRAssemblies.Add(typeof(OrderProcessingModuleServiceExtensions).Assembly);

    logger.Information("Order Processing module services registered");

    return services;
  }
}
