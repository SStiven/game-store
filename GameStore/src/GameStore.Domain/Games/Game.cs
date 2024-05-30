namespace GameStore.Domain.Games;

public class Game
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Key { get; set; }

    public string? Description { get; set; }

    public List<GamePlatform> GamePlatforms { get; set; }

    public List<GameGenre> GameGenres { get; set; }
}
