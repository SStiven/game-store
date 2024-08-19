using GameStore.Domain.Games;

namespace GameStore.Application.Common.Interfaces;

public interface IReadOnlyGameRespository
{
    Task<IReadOnlyList<Game>> GetAllAsync();
}
