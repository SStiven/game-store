namespace GameStore.Domain.Payments;

public class PaymentMethod
{
    public static readonly PaymentMethod Visa = new("Visa");
    public static readonly PaymentMethod IBoxTerminal = new("IBox terminal");
    public static readonly PaymentMethod Bank = new("Bank");

    private PaymentMethod(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override string ToString() => Name;

    public static PaymentMethod FromString(string method)
    {
        return method switch
        {
            "Visa" => Visa,
            "IBox terminal" => IBoxTerminal,
            "Bank" => Bank,
            _ => throw new ArgumentException("Invalid payment method", nameof(method)),
        };
    }
}
