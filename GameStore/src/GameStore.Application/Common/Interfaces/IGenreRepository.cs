using GameStore.Domain.Genres;

namespace GameStore.Application.Common.Interfaces;

public interface IGenreRepository
{
    Task<bool> AreAllPresentAsync(IEnumerable<Guid> genreIds);

    Task<Genre?> GetByIdAsync(Guid parentGenreId);

    Task<Genre> AddAsync(Genre genre);

    Task<IReadOnlyList<Genre>> GetAllAsync();

    Task<List<Genre>> GetByGameIdAsync(Guid gameId);

    Task<List<Genre>> GetByParentGenreIdAsync(Guid parentGenreId);
}
