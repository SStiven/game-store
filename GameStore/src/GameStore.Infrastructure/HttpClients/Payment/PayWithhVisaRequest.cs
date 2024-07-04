using GameStore.Domain.Payments;

namespace GameStore.Infrastructure.HttpClients.Payment;

public record PayWithhVisaRequest(VisaCard Model, double Amount);
