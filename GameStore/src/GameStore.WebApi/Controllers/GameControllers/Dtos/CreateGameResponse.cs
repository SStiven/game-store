namespace GameStore.WebApi.Controllers.GameControllers.Dtos;

public class CreateGameResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Key { get; set; }

    public string? Description { get; set; }
}
