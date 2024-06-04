using GameStore.Domain.Genres;

namespace GameStore.Application.Common.Interfaces;

public interface IGenreRepository
{
    Task<bool> AreAllPresentAsync(IEnumerable<Guid> genreIds);

    Task<Genre?> GetByIdAsync(Guid parentGenreId);

    Task<Genre> AddAsync(Genre genre);
}
