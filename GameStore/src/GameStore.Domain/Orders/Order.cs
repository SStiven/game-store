namespace GameStore.Domain.Orders;

public class Order
{
    public Order(
        Guid orderId,
        Guid customerId,
        DateTime date,
        List<OrderGame> orderGames)
    {
        Id = orderId;
        Date = date;
        CustomerId = customerId;
        Status = OrderStatus.Open;
        OrderGames = orderGames ?? throw new ArgumentNullException(nameof(orderGames));
    }

    private Order()
    {
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    public DateTime? Date { get; private set; }

    public Guid CustomerId { get; private set; }

    public OrderStatus Status { get; private set; }

    public ICollection<OrderGame> OrderGames { get; private set; }

    public bool HasGameWithId(Guid gameId) => OrderGames.Any(og => og.ProductId == gameId);

    public void AddOrderGame(OrderGame orderGame)
    {
        ArgumentNullException.ThrowIfNull(orderGame);
        OrderGames.Add(orderGame);
    }

    public void RemoveGame(Guid gameId)
    {
        var existingOrderGame = OrderGames.FirstOrDefault(og => og.ProductId == gameId)
            ?? throw new InvalidOperationException("Game not found in order");

        OrderGames.Remove(existingOrderGame);
    }

    public bool IsEmpty()
    {
        return OrderGames.Count == 0;
    }

    public double GetTotal()
    {
        double total = 0;
        foreach (var orderGame in OrderGames)
        {
            var discount = orderGame.Discount ?? 0;
            total += orderGame.Price * orderGame.Quantity * (1 - (discount / 100d));
        }

        return total;
    }

    public void Pay()
    {
        Status = OrderStatus.Paid;
    }
}
