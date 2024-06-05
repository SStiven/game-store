using GameStore.Domain.Games;

namespace GameStore.Domain.Platforms;

public class Platform
{
    public Platform(string type)
    {
        ValidateType(type);

        Id = Guid.NewGuid();
        Type = type;
    }

    private Platform()
    {
    }

    public Guid Id { get; private set; }

    public string Type { get; private set; }

    public List<GamePlatform> GamePlatforms { get; private set; }

    public void Update(string type)
    {
        ValidateType(type);
        Type = type;
    }

    private static void ValidateType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("Type cannot be null or empty", nameof(type));
        }

        if (type.Length > 200)
        {
            throw new ArgumentException("Type cannot be longer than 200 characters", nameof(type));
        }
    }
}
