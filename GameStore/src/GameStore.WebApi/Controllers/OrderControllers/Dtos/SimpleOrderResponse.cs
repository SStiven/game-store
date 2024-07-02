namespace GameStore.WebApi.Controllers.OrderControllers.Dtos;

public record SimpleOrderResponse(
    Guid Id,
    Guid CustomerId,
    DateTime? Date);