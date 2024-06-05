using System.Collections.Immutable;
using System.Text;

namespace GameStore.Domain.Games;

public class Game
{
    public Game(
        string name,
        string? key,
        string? description,
        IEnumerable<Guid> genreIds,
        IEnumerable<Guid> platformIds)
    {
        Id = Guid.NewGuid();
        Name = name;
        Key = GenerateKey(name, key);
        Description = description;

        ValidateGenres(genreIds);
        var gameGenres = genreIds.Select(g => new GameGenre { GenreId = g, GameId = Id }).ToList();
        GameGenres = gameGenres;

        ValidaPlatforms(platformIds);
        var gamePlatforms = platformIds.Select(p => new GamePlatform { PlatformId = p, GameId = Id }).ToList();
        GamePlatforms = gamePlatforms;
    }

    private Game()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Key { get; private set; }

    public string? Description { get; private set; }

    public List<GamePlatform> GamePlatforms { get; private set; }

    public List<GameGenre> GameGenres { get; private set; }

    public void Update(string name, string? key, string? description, IEnumerable<Guid> genreIds, IEnumerable<Guid> platformIds)
    {
        Name = name;
        Description = description;

        Key = GenerateKey(name, key);

        ValidateGenres(genreIds);
        var genresToRemove = GameGenres.Where(gg => !genreIds.Contains(gg.GenreId)).ToList();
        foreach (var genre in genresToRemove)
        {
            GameGenres.Remove(genre);
        }

        var genresToAdd = genreIds.Where(id => GameGenres.All(gg => gg.GenreId != id))
            .Select(id => new GameGenre { GenreId = id, GameId = Id })
            .ToList();

        foreach (var genre in genresToAdd)
        {
            GameGenres.Add(genre);
        }

        ValidaPlatforms(platformIds);
        var gamePlatformsToRemove = GamePlatforms.Where(gp => !platformIds.Contains(gp.PlatformId)).ToList();
        foreach (var gamePlatform in gamePlatformsToRemove)
        {
            GamePlatforms.Remove(gamePlatform);
        }

        var gamePlatformsToAdd = platformIds.Where(id => GamePlatforms.All(gp => gp.PlatformId != id))
            .Select(id => new GamePlatform { PlatformId = id, GameId = Id })
            .ToList();

        foreach (var gamePlatform in gamePlatformsToAdd)
        {
            GamePlatforms.Add(gamePlatform);
        }
    }

    private static string GenerateKey(string name, string? key)
    {
        if (!string.IsNullOrEmpty(key))
        {
            return name.Replace(" ", "-")
                .ToLower(System.Globalization.CultureInfo.InvariantCulture);
        }

        string nameWithoutSpaces = name.Replace(" ", "-")
            .ToLower(System.Globalization.CultureInfo.InvariantCulture) + "-";

        int numRandomCharacters = 4;
        var random = new Random();

        var builder = new StringBuilder(nameWithoutSpaces, nameWithoutSpaces.Length + numRandomCharacters);
        for (var i = 0; i < numRandomCharacters; i++)
        {
            builder.Append((char)random.Next('a', 'a' + 26));
        }

        return builder.ToString();
    }

    private static void ValidateGenres(IEnumerable<Guid> genreIds)
    {
        if (genreIds.Count() is < 1 or > 2)
        {
            throw new ArgumentException("A game must have between 1 and 2 genres", nameof(genreIds));
        }
    }

    private static void ValidaPlatforms(IEnumerable<Guid> platformIds)
    {
        if (platformIds.Count() is < 1 or > 3)
        {
            throw new ArgumentException("A game must have between 1 and 3 platforms", nameof(platformIds));
        }
    }
}
