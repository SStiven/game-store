namespace Payments.Visa.Dtos;

public record VisaCard(
    string Holder,
    string CardNumber,
    int MonthExpire,
    int YearExpire,
    int Cvv2);
