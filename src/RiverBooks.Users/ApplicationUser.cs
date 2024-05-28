using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users;

public class ApplicationUser : IdentityUser
{
  public string FullName { get; set; } = string.Empty;

  private readonly List<CartItem> _cartItems = new();

  public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

  public void AddItemToCart(CartItem item)
  {
    Guard.Against.Null(item, nameof(item));

    var existingItem = _cartItems.FirstOrDefault(ci => ci.BookId == item.BookId);
    if (existingItem != null)
    {
      existingItem.UpdateQuantity(existingItem.Quantity + item.Quantity);
    }
    else
    {
      _cartItems.Add(item);
    }
  }
}
