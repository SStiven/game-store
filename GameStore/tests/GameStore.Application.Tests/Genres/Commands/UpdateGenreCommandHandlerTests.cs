using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Games.Commands.UpdateGame;
using GameStore.Application.Genres.Commands.UpdateGenre;
using GameStore.Domain.Genres;

using Moq;

namespace GameStore.Application.Tests.Genres.Commands;

public class UpdateGenreCommandHandlerTests
{
    private readonly Mock<IGenreRepository> _mockGenreRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly UpdateGenreCommandHandler _handler;

    public UpdateGenreCommandHandlerTests()
    {
        _mockGenreRepository = new Mock<IGenreRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new UpdateGenreCommandHandler(
            _mockGenreRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenAllInputsAreValidShouldUpdateGenre()
    {
        var genreId = Guid.NewGuid();
        var command = new UpdateGenreCommand(genreId, "Updated Genre", null);
        var genre = new Genre("Original Genre", null);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync(genre);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be("Updated Genre");
        result.Value.ParentGenreId.Should().BeNull();
        _mockGenreRepository.Verify(r => r.Update(It.IsAny<Genre>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task WhenGenreDoesNotExistShouldReturnNotFoundError()
    {
        var genreId = Guid.NewGuid();
        var command = new UpdateGenreCommand(genreId, "Updated Genre", null);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync((Genre)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.NotFound);
        _mockGenreRepository.Verify(r => r.Update(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenParentGenreIdIsProvidedAndParentGenreDoesNotExistShouldReturnNotFoundError()
    {
        var genreId = Guid.NewGuid();
        var parentGenreId = Guid.NewGuid();
        var command = new UpdateGenreCommand(genreId, "Updated Genre", parentGenreId);
        var genre = new Genre("Original Genre", null);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync(genre);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(parentGenreId))
            .ReturnsAsync((Genre)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.NotFound);
        _mockGenreRepository.Verify(r => r.Update(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenParentGenreIdIsSameAsGenreIdShouldReturnValidationError()
    {
        var genreId = Guid.NewGuid();
        var command = new UpdateGenreCommand(genreId, "Updated Genre", genreId);
        var genre = new Genre("Original Genre", null);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync(genre);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGenreRepository.Verify(r => r.Update(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task WhenAllInputsAreValidAndParentGenreExistsShouldUpdateGenreWithParent()
    {
        var genreId = Guid.NewGuid();
        var parentGenre = new Genre("Parent Genre", null);
        var parentGenreId = parentGenre.Id;
        var command = new UpdateGenreCommand(genreId, "Updated Genre", parentGenreId);
        var genre = new Genre("Original Genre", null);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(command.Id))
            .ReturnsAsync(genre);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(parentGenreId))
            .ReturnsAsync(parentGenre);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be("Updated Genre");
        result.Value.ParentGenreId.Should().Be(parentGenreId);
        _mockGenreRepository.Verify(r => r.Update(It.IsAny<Genre>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
