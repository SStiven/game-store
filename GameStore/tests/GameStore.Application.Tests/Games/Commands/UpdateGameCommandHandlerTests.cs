using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Games.Commands.UpdateGame;
using GameStore.Domain.Games;

using Moq;

namespace GameStore.Application.Tests.Games.Commands;

public class UpdateGameCommandHandlerTests
{
    private readonly Mock<IGameRepository> _mockGameRepository;
    private readonly Mock<IGenreRepository> _mockGenreRepository;
    private readonly Mock<IPlatformRepository> _mockPlatformRepository;
    private readonly Mock<IGameFileRepository> _mockGameFileRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly UpdateGameCommandHandler _handler;

    public UpdateGameCommandHandlerTests()
    {
        _mockGameRepository = new Mock<IGameRepository>();
        _mockGenreRepository = new Mock<IGenreRepository>();
        _mockPlatformRepository = new Mock<IPlatformRepository>();
        _mockGameFileRepository = new Mock<IGameFileRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new UpdateGameCommandHandler(
            _mockGameRepository.Object,
            _mockGenreRepository.Object,
            _mockPlatformRepository.Object,
            _mockGameFileRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenAllInputsAreValidShouldUpdateGame()
    {
        var gameId = Guid.NewGuid();
        var existingGenreIds = new List<Guid> { Guid.NewGuid() };
        var existingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var command = new UpdateGameCommand(
            gameId,
            "Updated Game",
            "Updated Key",
            "Updated Description",
            existingGenreIds,
            existingPlatformIds);

        var game = new Game(
            "Original Game",
            "OriginalKey",
            "Original Description",
            existingGenreIds,
            existingPlatformIds);

        _mockGameRepository
            .Setup(r => r.GetByIdWithGenresAndPlatformsAsync(command.Id))
            .ReturnsAsync(game);

        _mockGenreRepository
            .Setup(r => r.AreAllPresentAsync(command.GenreIds))
            .ReturnsAsync(true);

        _mockPlatformRepository
            .Setup(r => r.AreAllPresentAsync(command.PlatformIds))
            .ReturnsAsync(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be("Updated Game");
        result.Value.Key.Should().Be("updated-key");
        result.Value.Description.Should().Be("Updated Description");
        _mockGameRepository.Verify(r => r.Update(It.IsAny<Game>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task WhenGameDoesNotExistShouldReturnNotFoundError()
    {
        var gameId = Guid.NewGuid();
        var genreIds = new List<Guid> { Guid.NewGuid() };
        var platformIds = new List<Guid> { Guid.NewGuid() };
        var command = new UpdateGameCommand(
            gameId,
            "Updated Game",
            "UpdatedKey",
            "Updated Description",
            genreIds,
            platformIds);

        _mockGameRepository
            .Setup(r => r.GetByIdWithGenresAndPlatformsAsync(command.Id))
            .ReturnsAsync((Game)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.NotFound);
        _mockGameRepository.Verify(r => r.Update(It.IsAny<Game>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenSomeGenreIdsAreMissingShouldReturnValidationError()
    {
        var gameId = Guid.NewGuid();
        var noExistingGenreIds = new List<Guid> { Guid.NewGuid() };
        var existingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var command = new UpdateGameCommand(
            gameId,
            "Updated Game",
            "UpdatedKey",
            "Updated Description",
            noExistingGenreIds,
            existingPlatformIds);

        var game = new Game("Original Game", "OriginalKey", "Original Description", noExistingGenreIds, existingPlatformIds);
        _mockGameRepository
            .Setup(r => r.GetByIdWithGenresAndPlatformsAsync(command.Id))
            .ReturnsAsync(game);

        _mockGenreRepository
            .Setup(r => r.AreAllPresentAsync(command.GenreIds))
            .ReturnsAsync(false);

        _mockPlatformRepository
            .Setup(r => r.AreAllPresentAsync(command.PlatformIds))
            .ReturnsAsync(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGameRepository.Verify(r => r.Update(It.IsAny<Game>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenSomePlatformIdsAreMissingShouldReturnValidationError()
    {
        var gameId = Guid.NewGuid();
        var existingGenreIds = new List<Guid> { Guid.NewGuid() };
        var noExistingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var command = new UpdateGameCommand(
            gameId,
            "Updated Game",
            "UpdatedKey",
            "Updated Description",
            existingGenreIds,
            noExistingPlatformIds);

        var game = new Game(
            "Original Game",
            "OriginalKey",
            "Original Description",
            existingGenreIds,
            noExistingPlatformIds);

        _mockGameRepository
            .Setup(r => r.GetByIdWithGenresAndPlatformsAsync(command.Id))
            .ReturnsAsync(game);

        _mockGenreRepository
            .Setup(r => r.AreAllPresentAsync(command.GenreIds))
            .ReturnsAsync(true);

        _mockPlatformRepository
            .Setup(r => r.AreAllPresentAsync(command.PlatformIds))
            .ReturnsAsync(false);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGameRepository.Verify(r => r.Update(It.IsAny<Game>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }
}
