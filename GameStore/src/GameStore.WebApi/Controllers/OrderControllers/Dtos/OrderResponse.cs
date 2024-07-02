namespace GameStore.WebApi.Controllers.OrderControllers.Dtos;

public record OrderResponse(
    Guid Id,
    Guid CustomerId,
    DateTime? Date);