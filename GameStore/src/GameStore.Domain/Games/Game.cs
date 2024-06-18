using System.Collections.Immutable;
using System.Text;

using GameStore.Domain.Publishers;

namespace GameStore.Domain.Games;

public class Game
{
    private const int MaxNameLength = 100;
    private const int MaxKeyLength = MaxNameLength + 5;

    public Game(
        string name,
        string? key,
        string? description,
        double price,
        int unitInStock,
        int discount,
        IEnumerable<Guid> genreIds,
        IEnumerable<Guid> platformIds,
        Publisher publisher)
    {
        Id = Guid.NewGuid();
        Name = ValidateName(name);
        Key = GenerateKey(name, key);

        if (!string.IsNullOrEmpty(description) && description.Length > 500)
        {
            throw new ArgumentException("Description must be less than 500 characters", nameof(description));
        }

        Description = description;

        if (price < 0)
        {
            throw new ArgumentException("Price must be greater than 0", nameof(price));
        }

        Price = price;

        if (unitInStock < 0)
        {
            throw new ArgumentException("Unit in stock must be greater than 0", nameof(unitInStock));
        }

        UnitInStock = unitInStock;

        if (discount is <= 0 or > 100)
        {
            throw new ArgumentException("Discount must be greater than 0 and less or equal to 100", nameof(discount));
        }

        Discount = discount;

        ValidateGenres(genreIds);
        var gameGenres = genreIds.Select(g => new GameGenre { GenreId = g, GameId = Id }).ToList();
        GameGenres = gameGenres;

        ValidaPlatforms(platformIds);
        var gamePlatforms = platformIds.Select(p => new GamePlatform { PlatformId = p, GameId = Id }).ToList();
        GamePlatforms = gamePlatforms;

        Publisher = publisher;
    }

    private Game()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Key { get; private set; }

    public string? Description { get; private set; }

    public double Price { get; private set; }

    public int UnitInStock { get; private set; }

    public int Discount { get; private set; }

    public Publisher Publisher { get; private set; }

    public Guid PublisherId { get; private set; }

    public List<GamePlatform> GamePlatforms { get; private set; }

    public List<GameGenre> GameGenres { get; private set; }

    public void Update(
        string name,
        string? key,
        string? description,
        double price,
        int unitInStock,
        int discount,
        IEnumerable<Guid> genreIds,
        IEnumerable<Guid> platformIds,
        Publisher publisher)
    {
        Name = name;

        if (!string.IsNullOrEmpty(description) && description.Length > 500)
        {
            throw new ArgumentException("Description must be less than 500 characters", nameof(description));
        }

        Description = description;

        Key = GenerateKey(name, key);

        if (price < 0)
        {
            throw new ArgumentException("Price must be greater than 0", nameof(price));
        }

        Price = price;

        if (unitInStock < 0)
        {
            throw new ArgumentException("Unit in stock must be greater than 0", nameof(unitInStock));
        }

        UnitInStock = unitInStock;

        if (discount is <= 0 or > 100)
        {
            throw new ArgumentException("Discount must be greater than 0 and less or equal to 100", nameof(discount));
        }

        Discount = discount;

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

        Publisher = publisher;
    }

    private static string ValidateName(string name)
    {
        return string.IsNullOrEmpty(name)
            ? throw new ArgumentNullException(nameof(name), "Name is required")
            : name.Length > MaxNameLength
            ? throw new ArgumentException($"Name must be less than {MaxNameLength} characters", nameof(name))
            : name;
    }

    private static string GenerateKey(string name, string? key)
    {
        if (key?.Length > MaxKeyLength)
        {
            throw new ArgumentException($"Key must be less than {MaxKeyLength} characters", nameof(key));
        }

        if (!string.IsNullOrEmpty(key))
        {
            return key.Replace(" ", "-")
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
        if (genreIds is null)
        {
            throw new ArgumentNullException(nameof(genreIds), "Genres are required");
        }

        if (genreIds.Count() is < 1 or > 2)
        {
            throw new ArgumentException("A game must have between 1 and 2 genres", nameof(genreIds));
        }
    }

    private static void ValidaPlatforms(IEnumerable<Guid> platformIds)
    {
        if (platformIds is null)
        {
            throw new ArgumentNullException(nameof(platformIds), "Genres are required");
        }

        if (platformIds.Count() is < 1 or > 3)
        {
            throw new ArgumentException("A game must have between 1 and 3 platforms", nameof(platformIds));
        }
    }
}
