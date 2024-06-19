using GameStore.Domain.Games;

namespace GameStore.Application.Common.Interfaces;

public interface IGameRepository
{
    Task AddAsync(Game game);

    Task<Game?> GetByKeyAsync(string key);

    Task<Game?> GetByIdAsync(Guid id);

    Task<Game?> GetByIdWithGenresAndPlatformsAsync(Guid id);

    Task<List<Game>> GetByPlatformIdAsync(Guid platformId);

    Task<List<Game>> GetByGenreIdAsync(Guid genreId);

    Task Update(Game game);

    Task RemoveAsync(Game game);

    Task<IReadOnlyList<Game>> GetAllAsync();

    Task<bool> HasGamesWithPlatformIdAsync(Guid platformId);

    Task<int> GetCountAsync();

    Task<bool> AnyWithPublisherIdAsync(Guid publisherId);
}
