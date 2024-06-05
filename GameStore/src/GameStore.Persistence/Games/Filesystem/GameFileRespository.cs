using System.Text.Json;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;

namespace GameStore.Persistence.Games.Filesystem;

public class GameFileRespository : IGameFileRepository
{
    private readonly string _baseDirectory = Directory.GetCurrentDirectory();
    private readonly string _gamesDirectoryName = "Games";
    private readonly string _gamesDirectoryPath;

    public GameFileRespository()
    {
        var path = Path.Combine(_baseDirectory, _gamesDirectoryName);
        if (Directory.Exists(path))
        {
            _gamesDirectoryPath = path;
            return;
        }

        var directoryInfo = Directory.CreateDirectory(path) ??
                        throw new InvalidOperationException($"Failed to create directory at path: {path}");
        _gamesDirectoryPath = directoryInfo.FullName;
    }

    public async Task SaveGameFileAsync(Game game)
    {
        var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
        var fileName = $"{game.Name}_{timestamp}";
        var path = Path.Combine(_gamesDirectoryPath, fileName);
        var gameJson = JsonSerializer.Serialize(game);

        Console.WriteLine(path);

        await File.WriteAllTextAsync(path, gameJson);
    }

    public void DeleteLastGameFile(string gameName)
    {
        var directoryInfo = new DirectoryInfo(_gamesDirectoryPath);
        var files = directoryInfo.GetFiles($"{gameName}_*.txt");

        var lastFile = files.OrderByDescending(f => f.Name).FirstOrDefault()
            ?? throw new InvalidOperationException("Game file wasn't found");
        File.Delete(lastFile.FullName);
    }
}
