using FluentAssertions;

using GameStore.Domain.Games;

namespace GameStore.Domain.Tests.Games;

public class GameTests
{
    [Fact]
    public void CreateGameWithTooLongNameShouldFail()
    {
        var excedingByOneTheLength = 101;
        var tooLongName = new string('a', excedingByOneTheLength);
        IEnumerable<Guid> genreIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());
        IEnumerable<Guid> platformIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());

        Action createGame = () => { var game = new Game(tooLongName, null, null, genreIds, platformIds); };

        createGame.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateGameWithoutNameShouldFail()
    {
        IEnumerable<Guid> genreIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());
        IEnumerable<Guid> platformIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());

        Action createGame = () => { var game = new Game(null, null, null, genreIds, platformIds); };

        createGame.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CreateGameWithoutGenresShouldFail()
    {
        IEnumerable<Guid> genreIds = [];
        IEnumerable<Guid> platformIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());

        Action createGame = () => { var game = new Game("Game 1", null, null, genreIds, platformIds); };

        createGame.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateGameWithoutPlatformsShouldFail()
    {
        var genreIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());
        IEnumerable<Guid> platformIds = [];

        Action createGame = () => { var game = new Game("Game 1", null, null, genreIds, platformIds); };

        createGame.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateGameWithTooLongDescriptionShouldFail()
    {
        var excedingByOneTheLength = 501;
        var tooLongDescription = new string('d', excedingByOneTheLength);
        IEnumerable<Guid> genreIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());
        IEnumerable<Guid> platformIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());

        Action createGame = () => { var game = new Game("Game 1", null, tooLongDescription, genreIds, platformIds); };

        createGame.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CreateGameWithValidKeyReplaceSpacesWithHyphensSuccessfully()
    {
        string keyWithSpaces = "Key with Spaces";
        IEnumerable<Guid> genreIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());
        IEnumerable<Guid> platformIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());

        var game = new Game("Game 1", keyWithSpaces, null, genreIds, platformIds);

        game.Key.Should().Be("key-with-spaces");
        game.Key.Should().NotContain(" ");
        game.Name.Should().Be("Game 1");
    }

    [Fact]
    public void CreateGameWithoutKeyUseNameReplaceSpacesWithHyphensSuccessfully()
    {
        IEnumerable<Guid> genreIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());
        IEnumerable<Guid> platformIds = Enumerable.Range(0, 1).Select(_ => Guid.NewGuid());

        var game = new Game("Game 1", null, null, genreIds, platformIds);

        game.Key.Should().StartWith("game-1");
        game.Key.Should().NotContain(" ");
        game.Name.Should().Be("Game 1");
    }
}
