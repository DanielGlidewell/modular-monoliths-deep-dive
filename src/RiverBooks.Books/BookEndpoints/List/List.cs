using FastEndpoints;

namespace RiverBooks.Books;

internal class List(IBookService bs) :
  EndpointWithoutRequest<ListBooksResponse> {
  
  private readonly IBookService bookService = bs;

    public override void Configure() {
      Get("/books");
      AllowAnonymous(); 
    }

    public override async Task HandleAsync(
      CancellationToken cancellationToken = default
    ) {
      var books = await bookService.ListBooksAsync();

      await SendAsync(new ListBooksResponse() {
        Books = books 
      }, cancellation: cancellationToken);
    }
}