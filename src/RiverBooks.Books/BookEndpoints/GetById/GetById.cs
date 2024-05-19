using FastEndpoints;

namespace RiverBooks.Books;

internal class GetById(IBookService bs) :
  Endpoint<GetBookByIdRequest, BookDto> {

  private readonly IBookService bookService = bs;

  public override void Configure() {
    Get("/books/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    GetBookByIdRequest request,
    CancellationToken cancellationToken = default
  ) {
    var book = await bookService.GetBookByIdAsync(request.Id); 

    if (book is null) {
      await SendNotFoundAsync(cancellation: cancellationToken); 
      return; 
    }

    await SendAsync(book, cancellation: cancellationToken);
  }
}
