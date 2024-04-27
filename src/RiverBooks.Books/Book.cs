namespace RiverBooks.Books;

internal class Book {
  public Guid Id { get; private set; } = Guid.NewGuid();
  public string Title { get; private set; } = string.Empty;
  public string Author { get; private set; } = string.Empty; 
  public decimal Price { get; private set; }

  internal Book(Guid id, string title, string author, decimal price) {
    Id = id;
    Title = title;
    Author = author;
    Price = price;
  }

  internal void UpdatePrice(decimal price) {
    Price = price;
  }
}
