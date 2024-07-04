namespace GameStore.WebApi.Controllers.OrderControllers.Dtos;

public class VisaPaymentRequest : PaymentRequest
{
    public VisaModel Model { get; set; }
}
