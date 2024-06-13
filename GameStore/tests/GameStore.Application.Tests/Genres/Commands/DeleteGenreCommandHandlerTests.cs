using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Genres.Commands.DeleteGame;
using GameStore.Domain.Games;
using GameStore.Domain.Genres;
using GameStore.Domain.Platforms;

using Moq;

namespace GameStore.Application.Tests.Genres.Commands;

public class DeleteGenreCommandHandlerTests
{
    private readonly Mock<IGameRepository> _mockGameRepository;
    private readonly Mock<IGenreRepository> _mockGenreRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly DeleteGenreCommandHandler _handler;

    public DeleteGenreCommandHandlerTests()
    {
        _mockGameRepository = new Mock<IGameRepository>();
        _mockGenreRepository = new Mock<IGenreRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new DeleteGenreCommandHandler(
            _mockGameRepository.Object,
            _mockGenreRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenGenreDoesNotExistShouldReturnNotFoundError()
    {
        var genreId = Guid.NewGuid();
        var command = new DeleteGenreCommand(genreId);

        _mockGenreRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync((Genre)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.NotFound);
        _mockGenreRepository.Verify(r => r.RemoveAsync(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenGenreIsUsedInGamesShouldReturnValidationError()
    {
        var genre = new Genre("Genre", null);
        var command = new DeleteGenreCommand(genre.Id);
        var platform = new Platform("PC");
        var games = new List<Game> { new("Game", "Key", "Description", [genre.Id], [platform.Id]) };

        _mockGenreRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(genre);
        _mockGameRepository.Setup(r => r.GetByGenreIdAsync(command.Id)).ReturnsAsync(games);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGenreRepository.Verify(r => r.RemoveAsync(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenGenreHasChildGenresShouldReturnValidationError()
    {
        var genreId = Guid.NewGuid();
        var command = new DeleteGenreCommand(genreId);
        var genre = new Genre("Genre", null);

        _mockGenreRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(genre);
        _mockGenreRepository.Setup(r => r.HasChildGenresAsync(command.Id)).ReturnsAsync(true);
        _mockGameRepository.Setup(r => r.GetByGenreIdAsync(command.Id)).ReturnsAsync([]);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGenreRepository.Verify(r => r.RemoveAsync(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenGenreCanBeDeletedShouldRemoveGenre()
    {
        var genreId = Guid.NewGuid();
        var command = new DeleteGenreCommand(genreId);
        var genre = new Genre("Genre", null);

        _mockGenreRepository.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync(genre);
        _mockGameRepository.Setup(r => r.GetByGenreIdAsync(command.Id)).ReturnsAsync([]);
        _mockGenreRepository.Setup(r => r.HasChildGenresAsync(command.Id)).ReturnsAsync(false);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        _mockGenreRepository.Verify(r => r.RemoveAsync(genre), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
