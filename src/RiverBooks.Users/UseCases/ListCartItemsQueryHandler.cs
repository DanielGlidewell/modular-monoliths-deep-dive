using Ardalis.Result;
using MediatR;
using RiverBooks.Users.CartEndpoints;

namespace RiverBooks.Users.UseCases;

internal class ListCartItemsQueryHandler(IApplicationUserRepository userRepository) 
  : IRequestHandler<ListCartItemsQuery, Result<List<CartItemDto>>>
{
  public async Task<Result<List<CartItemDto>>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
  {
    var user = await userRepository.GetByEmailAsync(request.EmailAddress);

    if(user is null)
    {
      return Result.Unauthorized();
    }

    return user.CartItems
      .Select(item => new CartItemDto( 
        item.Id, 
        item.BookId,
        item.Description,
        item.Quantity,
        item.UnitPrice
      ))
      .ToList();
  }
}
