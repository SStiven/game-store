namespace GameStore.Domain.Payments;

public record VisaCard(
    string Holder,
    string CardNumber,
    int MonthExpire,
    int YearExpire,
    int Cvv2);