using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RiverBooks.OrderProcessing.Data;

public class OrderProcessingDbContext(DbContextOptions<OrderProcessingDbContext> options) : DbContext(options)
{
  internal DbSet<Order> Orders { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.HasDefaultSchema("OrderProcessing");

    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    base.OnModelCreating(builder);
  }

  protected override void ConfigureConventions(ModelConfigurationBuilder configBuilder)
  {
    configBuilder.Properties<decimal>().HavePrecision(18, 6); 
  }
}
