using GameStore.Domain.Games;

namespace GameStore.Domain.Platforms;

public class Platform
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public List<GamePlatform> GamePlatforms { get; }
}
