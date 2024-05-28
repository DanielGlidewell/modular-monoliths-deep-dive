using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCases;

namespace RiverBooks.Users.CartEndpoints;

internal class ListCartItems(IMediator mediator) : EndpointWithoutRequest<CartResponse>
{
  public override void Configure()
  {
    Get("/cart");
    Claims("EmailAddress"); 
  }

  public override async Task HandleAsync(CancellationToken ct)
  {
    var email = User.FindFirstValue("EmailAddress");
    if (string.IsNullOrWhiteSpace(email))
    {
      throw new InvalidOperationException("Email address not found in claims.");
    }

    var query = new ListCartItemsQuery(email);
    
    var result = await mediator.Send(query, ct);
    if(result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync();
    }
    else 
    {
      await SendOkAsync(new CartResponse { CartItems = result.Value });
    }
  }
}
