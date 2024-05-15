using FastEndpoints;

namespace RiverBooks.Books;

internal class DeleteBookEndpoint(IBookService bs) :
  Endpoint<DeleteBookRequest> {

  private readonly IBookService bookService = bs;

  public override void Configure() {
    Delete("/books/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteBookRequest request,
    CancellationToken ct = default
  ) {
    // handle not found
    await bookService.DeleteBookAsync(request.Id);

    await SendNoContentAsync(cancellation: ct);
  }
}
