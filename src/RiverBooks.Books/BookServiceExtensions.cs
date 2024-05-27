using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace RiverBooks.Books;

public static class BookServiceExtensions {
  public static IServiceCollection AddBookService(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger) 
  {
    string? connectionString = config.GetConnectionString("BooksConnectionString");
    services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));
    services.AddScoped<IBookRepository, EfBookRepository>();  
    services.AddScoped<IBookService, BookService>();

    logger.Information("Book module services registered");

    return services;
  }
}