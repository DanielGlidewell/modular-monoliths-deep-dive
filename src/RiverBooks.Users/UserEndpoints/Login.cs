using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.UserEndpoints;

public record UserLoginRequest(string Email, string Password);

internal class Login : Endpoint<UserLoginRequest>
{
  private readonly UserManager<ApplicationUser> _userManager;

  public Login(UserManager<ApplicationUser> userManager) => _userManager = userManager;

  public override void Configure()
  {
    Post("/users/login");
    AllowAnonymous();
  }

  public override async Task HandleAsync(UserLoginRequest request, CancellationToken ct)
  {
    var user = await _userManager.FindByEmailAsync(request.Email);
    if (user == null || user.Email == null)
    {
      await SendUnauthorizedAsync(ct);
      return;
    }

    var result = await _userManager.CheckPasswordAsync(user, request.Password);
    if (!result)
    {
      await SendUnauthorizedAsync(ct);
      return;
    }

    var jwtSecret = Config["Auth:JwtSecret"]!;
    var token = JwtBearer.CreateToken(o => {
      o.SigningKey = jwtSecret;
      o.User.Claims.Add(("EmailAddress", user.Email));
    });

    await SendAsync(new {
      user.Email,
      Token = token
    });
  }
}