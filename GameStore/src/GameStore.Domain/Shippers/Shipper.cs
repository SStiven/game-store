namespace GameStore.Domain.Shippers;

public class Shipper(int shipperId, string companyName, string phone)
{
    public int Id { get; private set; } = shipperId;

    public string CompanyName { get; private set; } = companyName;

    public string Phone { get; private set; } = phone;
}
