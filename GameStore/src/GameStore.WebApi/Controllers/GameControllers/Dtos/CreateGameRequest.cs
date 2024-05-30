namespace GameStore.WebApi.Controllers.GameController.Dtos;

public class CreateGameRequest
{
    public CreateGameDto Game { get; set; }

    public IEnumerable<Guid> Genres { get; set; }

    public IEnumerable<Guid> Platforms { get; set; }
}
