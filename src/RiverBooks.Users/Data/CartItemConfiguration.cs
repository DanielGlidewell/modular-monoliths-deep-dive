using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Users.Data;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
  public void Configure(EntityTypeBuilder<CartItem> builder)
  {
    builder.HasKey(ci => ci.Id);
    builder.Property(ci => ci.Id).ValueGeneratedNever();
    builder.Property(ci => ci.BookId).IsRequired();
    builder.Property(ci => ci.Description).IsRequired();
    builder.Property(ci => ci.Quantity).IsRequired();
    builder.Property(ci => ci.UnitPrice).IsRequired();
  }
}
