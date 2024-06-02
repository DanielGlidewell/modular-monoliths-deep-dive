using Microsoft.EntityFrameworkCore;

namespace RiverBooks.OrderProcessing.Data;

internal class EfOrderRepository(OrderProcessingDbContext dbContext) : IOrderRepository
{

  public async Task AddAsync(Order order)
  {
    await dbContext.Orders.AddAsync(order);
  }

  public async Task<List<Order>> ListAsync()
  {
    return await dbContext.Orders.ToListAsync();
  }

  public async Task SaveChangesAsync()
  {
    await dbContext.SaveChangesAsync();
  }
}
