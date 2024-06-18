using GameStore.Domain.Games;

namespace GameStore.Application.Common.Interfaces;

public interface IGameFileRepository
{
    Task SaveGameFileAsync(Game game);

    Task<byte[]> GetLastGameFileBytesAsync(string gameName);
}
