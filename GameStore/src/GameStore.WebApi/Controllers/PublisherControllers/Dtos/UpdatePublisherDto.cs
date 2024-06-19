namespace GameStore.WebApi.Controllers.PublisherControllers.Dtos;

public record UpdatePublisherDto(
    Guid Id,
    string CompanyName,
    string? HomePage,
    string? Description);