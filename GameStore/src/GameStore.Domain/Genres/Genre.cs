using GameStore.Domain.Games;

namespace GameStore.Domain.Genres;

public class Genre
{
    public Genre(string name, Guid? parentGenreId)
    {
        Id = Guid.NewGuid();

        Name = ValidateName(name);
        ParentGenreId = parentGenreId;
    }

    private Genre()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Genre? ParentGenre { get; private set; }

    public Guid? ParentGenreId { get; private set; }

    public List<GameGenre> GameGenres { get; private set; }

    public List<Genre> SubGenres { get; private set; }

    public void Update(string name, Genre? parentGenre)
    {
        Name = ValidateName(name);

        if (parentGenre != null && parentGenre.Id == Id)
        {
            throw new ArgumentException("A genre can't be its own parent", nameof(parentGenre));
        }

        ParentGenre = parentGenre;
        ParentGenreId = parentGenre?.Id;
    }

    private static string ValidateName(string name)
    {
        return string.IsNullOrEmpty(name)
            ? throw new ArgumentException("Name is required", nameof(name))
            : name.Length > 100 ?
                throw new ArgumentException("Name is too long, maximum length is 100 characters", nameof(name)) : name;
    }
}
