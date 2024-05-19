using FastEndpoints;

namespace RiverBooks.Books;

internal class Create(IBookService bs) :
  Endpoint<CreateBookRequest, BookDto> {

  private readonly IBookService bookService = bs;

  public override void Configure() {
    Post("/books");
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    CreateBookRequest request,
    CancellationToken cancellationToken = default
  ) {
    var dto = new BookDto(
      Id: request.Id ?? Guid.NewGuid(),
      Title: request.Title,
      Author: request.Author,
      Price: request.Price
    );  

    await bookService.CreateBookAsync(dto);
    
    await SendCreatedAtAsync<GetById>(
      new { dto.Id }, 
      dto, 
      cancellation: cancellationToken
    );
  }
}
