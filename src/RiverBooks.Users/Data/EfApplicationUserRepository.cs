using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Users.Data;

internal class EfApplicationUserRepository(UsersDbContext dbContext) : IApplicationUserRepository
{
  public async Task<ApplicationUser> GetByEmailAsync(string email)
  {
    return await dbContext.ApplicationUsers
      .Include(u => u.CartItems)
      .SingleAsync(u => u.Email == email);
  }

  public async Task SaveChangesAsync()
  {
    await dbContext.SaveChangesAsync();
  }
}
