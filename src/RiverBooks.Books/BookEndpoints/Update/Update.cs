using FastEndpoints;

namespace RiverBooks.Books;

internal class Update(IBookService bs) : 
  Endpoint<UpdatePriceRequest> {

  private readonly IBookService bookService = bs;

  public override void Configure() {
    Patch("/books/{Id}/price");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdatePriceRequest request,
    CancellationToken ct = default
  ) {
    // handle not found
    await bookService.UpdateBookPriceAsync(request.Id, request.Price);

    var updatedBook = await bookService.GetBookByIdAsync(request.Id);

    await SendAsync(updatedBook, cancellation: ct); 
  }
}
