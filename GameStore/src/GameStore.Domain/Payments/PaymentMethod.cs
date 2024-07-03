namespace GameStore.Domain.Payments;

public class PaymentMethod
{
    public static readonly PaymentMethod Visa = new(
        "Visa",
        "https://www.pexels.com/photo/open-door-to-greenhouse-21854305/",
        "Visa description");

    public static readonly PaymentMethod IBoxTerminal = new(
        "IBox terminal",
        "https://www.pexels.com/photo/historic-wooden-church-in-the-ethnographic-park-in-tokarnia-21802129/",
        "Box terminal description");

    public static readonly PaymentMethod Bank = new(
        "Bank",
        "https://www.pexels.com/photo/yellow-sky-over-ocean-at-sunset-21832675/",
        "Bank description");

    private PaymentMethod(string name, string imageUrl, string description)
    {
        Name = name;
        ImageUrl = imageUrl;
        Description = description;
    }

    public string Name { get; }

    public string ImageUrl { get; }

    public string Description { get; }

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