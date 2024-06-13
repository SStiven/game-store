using ErrorOr;

using FluentAssertions;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.Games.Commands.CreateGame;
using GameStore.Domain.Games;
using Moq;

namespace GameStore.Application.Tests.Games.Commands;

public class CreateGameCommandHandlerTests
{
    private readonly Mock<IGameRepository> _mockGameRepository;
    private readonly Mock<IGenreRepository> _mockGenreRepository;
    private readonly Mock<IPlatformRepository> _mockPlatformRepository;
    private readonly Mock<IGameFileRepository> _mockGameFileRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CreateGameCommandHandler _handler;

    public CreateGameCommandHandlerTests()
    {
        _mockGameRepository = new Mock<IGameRepository>();
        _mockGenreRepository = new Mock<IGenreRepository>();
        _mockPlatformRepository = new Mock<IPlatformRepository>();
        _mockGameFileRepository = new Mock<IGameFileRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new CreateGameCommandHandler(
            _mockGenreRepository.Object,
            _mockGameRepository.Object,
            _mockPlatformRepository.Object,
            _mockGameFileRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenAllInputsAreValidShouldReturnGame()
    {
        var existingGenreIds = new List<Guid> { Guid.NewGuid() };
        var existingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var command = new CreateGameCommand(
            "Test Game",
            "TestKey",
            "Test Description",
            existingGenreIds,
            existingPlatformIds);

        _mockGenreRepository
            .Setup(r => r.AreAllPresentAsync(command.GenreIds))
            .ReturnsAsync(true);

        _mockPlatformRepository
            .Setup(r => r.AreAllPresentAsync(command.PlatformIds))
            .ReturnsAsync(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        _mockGameRepository.Verify(r => r.AddAsync(It.IsAny<Game>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task WhenSomeGenreIdsAreMissingShouldReturnValidationError()
    {
        var noExistingGenreIds = new List<Guid> { Guid.NewGuid() };
        var existingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var command = new CreateGameCommand(
            "Test Game",
            "TestKey",
            "Test Description",
            noExistingGenreIds,
            existingPlatformIds);

        _mockGenreRepository
            .Setup(r => r.AreAllPresentAsync(command.GenreIds))
            .ReturnsAsync(false);

        _mockGenreRepository
            .Setup(r => r.AreAllPresentAsync(command.PlatformIds))
            .ReturnsAsync(true);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().HaveCount(1);
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGameRepository.Verify(r => r.AddAsync(It.IsAny<Game>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenSomePlatformIdsAreMissinShouldReturnValidationError()
    {
        var existingGenreIds = new List<Guid> { Guid.NewGuid() };
        var noExistingPlatformIds = new List<Guid> { Guid.NewGuid() };
        var command = new CreateGameCommand(
            "Test Game",
            "TestKey",
            "Test Description",
            existingGenreIds,
            noExistingPlatformIds);

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
        _mockGameRepository.Verify(r => r.AddAsync(It.IsAny<Game>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }
}
