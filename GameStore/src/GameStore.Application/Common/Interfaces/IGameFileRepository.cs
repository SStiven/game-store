using GameStore.Domain.Games;

namespace GameStore.Application.Common.Interfaces;

public interface IGameFileRepository
{
    Task SaveGameFileAsync(Game game);

    void DeleteLastGameFile(string gameName);

    Task<byte[]> GetLastGameFileBytesAsync(string gameName);
}
