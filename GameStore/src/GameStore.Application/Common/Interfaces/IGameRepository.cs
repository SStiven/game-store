using GameStore.Domain.Games;

namespace GameStore.Application.Common.Interfaces;

public interface IGameRepository
{
    Task<IReadOnlyList<Game>> GetAllAsync();

    Task AddAsync(Game game);
}
