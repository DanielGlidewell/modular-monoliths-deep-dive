using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.OrderProcessing.Data;

internal static class Constants
{
  public const int STREET_MAXLENGTH = 50;
  public const int CITY_MAXLENGTH = 50;
  public const int STATE_MAXLENGTH = 50;
  public const int POSTALCODE_MAXLENGTH = 20;
  public const int COUNTRY_MAXLENGTH = 50;
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
  void IEntityTypeConfiguration<Order>.Configure(EntityTypeBuilder<Order> builder)
  {
    builder
      .Property(o => o.Id)
      .ValueGeneratedNever();

    builder.ComplexProperty(o => o.ShippingAddress, address =>
    {
      address.Property(a => a.Street1)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.Street2)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.City)
        .HasMaxLength(Constants.CITY_MAXLENGTH);
      address.Property(a => a.State)
        .HasMaxLength(Constants.STATE_MAXLENGTH);
      address.Property(a => a.PostalCode)
        .HasMaxLength(Constants.POSTALCODE_MAXLENGTH);
      address.Property(a => a.Country)
        .HasMaxLength(Constants.COUNTRY_MAXLENGTH);
    });

    builder.ComplexProperty(o => o.BillingAddress, address =>
    {
      address.Property(a => a.Street1)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.Street2)
        .HasMaxLength(Constants.STREET_MAXLENGTH);
      address.Property(a => a.City)
        .HasMaxLength(Constants.CITY_MAXLENGTH);
      address.Property(a => a.State)
        .HasMaxLength(Constants.STATE_MAXLENGTH);
      address.Property(a => a.PostalCode)
        .HasMaxLength(Constants.POSTALCODE_MAXLENGTH);
      address.Property(a => a.Country)
        .HasMaxLength(Constants.COUNTRY_MAXLENGTH);
    });
  }
}

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
  void IEntityTypeConfiguration<OrderItem>.Configure(EntityTypeBuilder<OrderItem> builder)
  {
    builder
      .Property(oi => oi.Id)
      .ValueGeneratedNever();

    builder.Property(oi => oi.Description)
      .HasMaxLength(100)
      .IsRequired();
  }
}
