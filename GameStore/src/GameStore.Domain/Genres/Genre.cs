using GameStore.Domain.Games;

namespace GameStore.Domain.Genres;

public class Genre
{
    public Genre(
        string name,
        Guid? parentGenreId,
        string? description = null,
        byte[]? picture = null)
    {
        Id = Guid.NewGuid();

        Name = ValidateName(name);
        ParentGenreId = parentGenreId;

        Picture = picture;
        Description = description;
    }

    private Genre()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public byte[]? Picture { get; private set; }

    public Genre? ParentGenre { get; private set; }

    public Guid? ParentGenreId { get; private set; }

    public List<GameGenre> GameGenres { get; private set; }

    public List<Genre> SubGenres { get; private set; }

    public void Update(
        string name,
        Genre? parentGenre,
        string? description = null,
        byte[]? picture = null)
    {
        Name = ValidateName(name);

        if (parentGenre != null && parentGenre.Id == Id)
        {
            throw new ArgumentException("A genre can't be its own parent", nameof(parentGenre));
        }

        ParentGenre = parentGenre;
        ParentGenreId = parentGenre?.Id;

        if (picture != null)
        {
            Picture = picture;
        }

        if (description != null)
        {
            Description = description;
        }
    }

    private static string ValidateName(string name)
    {
        return string.IsNullOrEmpty(name)
            ? throw new ArgumentException("Name is required", nameof(name))
            : name.Length > 100 ?
                throw new ArgumentException("Name is too long, maximum length is 100 characters", nameof(name)) : name;
    }
}
