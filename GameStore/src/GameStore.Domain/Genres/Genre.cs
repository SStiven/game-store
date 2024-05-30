using GameStore.Domain.Games;

namespace GameStore.Domain.Genres;

public class Genre
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Genre ParentGenre { get; set; }

    public Guid? ParentGenreId { get; set; }

    public List<GameGenre> GameGenres { get; set; }

    public List<Genre> SubGenres { get; set; }
}
