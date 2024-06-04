using GameStore.Domain.Games;

namespace GameStore.Application.Common.Interfaces;

public interface IGameRepository
{
    Task AddAsync(Game game);

    Task<Game?> GetByKeyAsync(string key);

    Task<Game?> GetByIdAsync(Guid id);

    Task<Game?> GetByIdWithGenresAndPlatformsAsync(Guid id);

    Task<List<Game>> GetAllWithPlatformIdAsync(Guid platformId);

    Task<List<Game>> GetAllWithGenreIdAsync(Guid genreId);

    Task Update(Game game);
}
