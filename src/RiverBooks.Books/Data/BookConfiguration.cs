using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book> {
  internal static readonly Guid Book1Guid = new("f4b3e3b2-3b9a-4b5d-9b7b-2b0d7b3dcb6d");
  internal static readonly Guid Book2Guid = new("f4b3e3b2-3b9a-4b5d-9b7b-2b0d7b3dcb6e");
  internal static readonly Guid Book3Guid = new("f4b3e3b2-3b9a-4b5d-9b7b-2b0d7b3dcb6f");

  public void Configure(EntityTypeBuilder<Book> builder) {
    builder.Property(p => p.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    
    builder.Property(p => p.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
  
    builder.HasData(GetSampleBookData());
  }

  private IEnumerable<Book> GetSampleBookData() {
    var tolkien = "J.R.R. Tolkien";
    yield return new Book(Book1Guid, "The Fellowship of the Ring", tolkien, 10.99m); 
    yield return new Book(Book2Guid, "The Two Towers", tolkien, 11.99m);
    yield return new Book(Book3Guid, "The Return of the King", tolkien, 12.99m);
  }
}
