namespace GameStore.WebApi.Controllers.OrderControllers.Dtos;

public record OrderDetailResponse(Guid ProductId, double Price, int Quantity, int Discount);