namespace RiverBooks.Books;

internal interface IBookService {
  Task<List<BookDto>> ListBooksAsync();
  Task<BookDto> GetBookByIdAsync(Guid bookId);
  Task CreateBookAsync(BookDto newBook);
  Task DeleteBookAsync(Guid bookId);
  Task UpdateBookPriceAsync(Guid bookId, decimal newPrice);
}
