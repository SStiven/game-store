namespace GameStore.WebApi.Controllers.GameController.Dtos;
public class CreateGameDto
{
    public string Name { get; set; }

    public string Key { get; set; }

    public string? Description { get; set; }
}