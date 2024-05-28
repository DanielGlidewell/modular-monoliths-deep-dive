using System.Security.Claims;
using Ardalis.Result;
using FastEndpoints;
using MediatR;
using RiverBooks.Users.UseCases;

namespace RiverBooks.Users.CartEndpoints;

internal class AddItem(IMediator mediator) : Endpoint<AddCartItemRequest> 
{
  public override void Configure()
  {
    Post("/cart");
    Claims("EmailAddress");
  }

  public override async Task HandleAsync(AddCartItemRequest request, CancellationToken ct)
  {
    var email = User.FindFirstValue("EmailAddress");
    if (string.IsNullOrWhiteSpace(email))
    {
      throw new InvalidOperationException("Email address not found in claims.");
    }

    var command = new AddItemToCartCommand(request.BookId, request.Quantity, email);

    var result = await mediator.Send(command, ct);
    if(result.Status == ResultStatus.Unauthorized)
    {
      await SendUnauthorizedAsync();
    }
    else 
    {
      await SendOkAsync();
    }
  }
}