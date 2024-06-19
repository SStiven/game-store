namespace GameStore.WebApi.Controllers.PublisherControllers.Dtos;

public record CreatePublisherDto(
    string CompanyName,
    string? HomePage,
    string? Description);
