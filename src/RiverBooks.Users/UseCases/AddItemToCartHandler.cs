using Ardalis.Result;
using MediatR;
using RiverBooks.Books.Contracts;

namespace RiverBooks.Users.UseCases;

public class AddItemToCartHandler(IApplicationUserRepository userRepository, IMediator mediator) : IRequestHandler<AddItemToCartCommand, Result>
{
  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken ct)
  {
    var user = await userRepository.GetByEmailAsync(request.Email);
    if(user is null)
    {
      return Result.Unauthorized();
    }
    
    var query = new BookDetailsQuery(request.BookId);
    var result = await mediator.Send(query, ct);
    if(result.Status == ResultStatus.NotFound)
    {
      return Result.NotFound();
    }

    var newCartItem = new CartItem(
      result.Value.BookId,
      $"{result.Value.Title} by {result.Value.Author}",
      request.Quantity,
      result.Value.Price 
    );

    user.AddItemToCart(newCartItem);
    await userRepository.SaveChangesAsync();
    return Result.Success();
  }
}
