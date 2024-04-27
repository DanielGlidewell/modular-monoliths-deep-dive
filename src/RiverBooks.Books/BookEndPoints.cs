using Microsoft.AspNetCore.Builder;

namespace RiverBooks.Books;

public static class BookEndPoints {
  public static void MapBookEndpoints(this WebApplication app) {
    app.MapGet("/books", (IBookService bookService) => 
      bookService.ListBooks());
  }
}
