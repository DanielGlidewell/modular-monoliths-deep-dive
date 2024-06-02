namespace RiverBooks.OrderProcessing;

internal class Order 
{
  private readonly List<OrderItem> _orderItems = new(); 
  public Guid Id { get; private set; } = Guid.NewGuid();
  public Guid UserId {  get; private set; }
  public Address ShippingAddress { get; private set; } = default!;
  public Address BillingAddress { get; private set; } = default!;
  public IReadOnlyCollection<OrderItem> orderItems => _orderItems.AsReadOnly();
  public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.Now;

  private void AddOrderItem(OrderItem item) => _orderItems.Add(item);
}
