using Ardalis.Result;
using MediatR;

namespace RiverBooks.Users.UseCases;

public class AddItemToCartHandler(IApplicationUserRepository userRepository) : IRequestHandler<AddItemToCartCommand, Result>
{
  public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
  {
    var user = await userRepository.GetByEmailAsync(request.Email);

    if(user is null)
    {
      return Result.Unauthorized();
    }
    
    // TODO: Get description and price from Books module
    var newCartItem = new CartItem(
      request.BookId,
      "description",
      request.Quantity,
      1.00m
    );

    user.AddItemToCart(newCartItem);

    await userRepository.SaveChangesAsync();

    return Result.Success();
  }
}
