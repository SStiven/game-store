using GameStore.Domain.Games;

namespace GameStore.Domain.Genres;

public class Genre
{
    public Genre(string name, Guid? parentGenreId)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name is required", nameof(name));
        }

        if (name.Length > 100)
        {
            throw new ArgumentException("Name is too long, maximum length is 100 characters", nameof(name));
        }

        Name = name;
        ParentGenreId = parentGenreId;
    }

    private Genre()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Genre ParentGenre { get; private set; }

    public Guid? ParentGenreId { get; private set; }

    public List<GameGenre> GameGenres { get; private set; }

    public List<Genre> SubGenres { get; private set; }
}
