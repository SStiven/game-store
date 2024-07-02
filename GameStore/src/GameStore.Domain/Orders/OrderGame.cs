using GameStore.Domain.Games;

namespace GameStore.Domain.Orders;

public class OrderGame
{
    public OrderGame(Guid orderId, Guid productId, double price, int quantity, int? discount)
    {
        OrderId = orderId;
        ProductId = productId;

        if (price < 0)
        {
            throw new ArgumentException("Price can't be negative", nameof(price));
        }

        Price = price;

        if (quantity < 0)
        {
            throw new ArgumentException("Price can't be negative", nameof(quantity));
        }

        Quantity = quantity;

        if (discount is not null)
        {
            var discountValue = discount.Value;
            if (discountValue is < 0 or > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100", nameof(discount));
            }
        }

        Discount = discount;
    }

    private OrderGame()
    {
    }

    public Guid OrderId { get; private set; }

    public Guid ProductId { get; private set; }

    public double Price { get; private set; }

    public int Quantity { get; private set; }

    public int? Discount { get; private set; }

    public Order Order { get; private set; }

    public Game Game { get; private set; }

    public void IncreateQuantity()
    {
        Quantity += 1;
    }
}
