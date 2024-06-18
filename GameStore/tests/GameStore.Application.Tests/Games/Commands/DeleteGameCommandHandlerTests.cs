using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Games.Commands.DeleteGame;
using GameStore.Domain.Games;
using GameStore.Domain.Publishers;

using Moq;

namespace GameStore.Application.Tests.Games.Commands;

public class DeleteGameCommandHandlerTests
{
    private readonly Mock<IGameRepository> _mockGameRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly DeleteGameCommandHandler _handler;

    public DeleteGameCommandHandlerTests()
    {
        _mockGameRepository = new Mock<IGameRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new DeleteGameCommandHandler(
            _mockGameRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenGameExistsShouldDeleteGame()
    {
        var existingGenreIds = new List<Guid> { Guid.NewGuid() };
        var existingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var publisher = new Publisher("Company Name 1", "localhost", "description 1");
        var game = new Game(
            "Test Game",
            "TestKey",
            "Test Description",
            1000,
            10,
            2,
            existingGenreIds,
            existingPlatformIds,
            publisher);

        _mockGameRepository
            .Setup(r => r.GetByIdWithGenresAndPlatformsAsync(game.Id))
            .ReturnsAsync(game);

        var command = new DeleteGameCommand(game.Id);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().Be(Result.Deleted);
        _mockGameRepository.Verify(r => r.RemoveAsync(It.IsAny<Game>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task WhenGameDoesNotExistShouldReturnNotFoundError()
    {
        var gameId = Guid.NewGuid();
        _mockGameRepository
            .Setup(r => r.GetByIdWithGenresAndPlatformsAsync(gameId))
            .ReturnsAsync((Game)null);

        var command = new DeleteGameCommand(gameId);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.NotFound);
        _mockGameRepository.Verify(r => r.RemoveAsync(It.IsAny<Game>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }
}
