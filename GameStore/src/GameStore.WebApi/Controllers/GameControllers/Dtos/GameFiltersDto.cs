namespace GameStore.WebApi.Controllers.GameControllers.Dtos;

public class GameFiltersDto
{
    public string? Name { get; set; }

    public IReadOnlyList<Guid>? Platforms { get; set; }

    public IReadOnlyList<Guid>? Genres { get; set; }

    public IReadOnlyList<Guid>? Publishers { get; set; }

    public int? MaxPrice { get; set; }

    public int? MinPrice { get; set; }

    public string? Sort { get; set; }

    public int? Page { get; set; }

    public int? PageCount { get; set; }
}
