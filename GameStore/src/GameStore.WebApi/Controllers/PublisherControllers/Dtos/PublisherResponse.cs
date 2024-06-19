namespace GameStore.WebApi.Controllers.PublisherControllers.Dtos;

public record PublisherResponse(
    Guid Id,
    string CompanyName,
    string? HomePage,
    string? Description);
