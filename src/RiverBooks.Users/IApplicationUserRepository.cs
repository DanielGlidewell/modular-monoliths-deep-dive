namespace RiverBooks.Users;

public interface IApplicationUserRepository
{
  Task<ApplicationUser> GetByEmailAsync(string email);
  Task SaveChangesAsync();
}
