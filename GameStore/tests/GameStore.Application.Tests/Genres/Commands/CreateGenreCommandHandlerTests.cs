using ErrorOr;
using FluentAssertions;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.Genres.Commands.CreateGenre;
using GameStore.Domain.Genres;

using Moq;

namespace GameStore.Application.Tests.Genres.Commands;

public class CreateGenreCommandHandlerTests
{
    private readonly Mock<IGenreRepository> _mockGenreRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CreateGenreCommandHandler _handler;

    public CreateGenreCommandHandlerTests()
    {
        _mockGenreRepository = new Mock<IGenreRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new CreateGenreCommandHandler(
            _mockGenreRepository.Object,
            _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task WhenAllInputsAreValidShouldCreateGenre()
    {
        var command = new CreateGenreCommand("New Genre", null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be("New Genre");
        result.Value.ParentGenreId.Should().BeNull();
        _mockGenreRepository.Verify(r => r.AddAsync(It.IsAny<Genre>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task WhenParentGenreIdIsProvidedAndParentGenreExistsShouldCreateSubGenre()
    {
        var parentGenreId = Guid.NewGuid();
        var parentGenre = new Genre("Parent Genre", null);
        var command = new CreateGenreCommand("Sub Genre", parentGenreId);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(parentGenreId))
            .ReturnsAsync(parentGenre);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Name.Should().Be("Sub Genre");
        result.Value.ParentGenreId.Should().Be(parentGenreId);
        _mockGenreRepository.Verify(r => r.AddAsync(It.IsAny<Genre>()), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task WhenParentGenreIdIsProvidedAndParentGenreDoesNotExistShouldReturnValidationError()
    {
        var parentGenreId = Guid.NewGuid();
        var command = new CreateGenreCommand("Sub Genre", parentGenreId);

        _mockGenreRepository
            .Setup(r => r.GetByIdAsync(parentGenreId))
            .ReturnsAsync((Genre)null);

        var result = await _handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.Errors.Should().ContainSingle(error => error.Type == ErrorType.Validation);
        _mockGenreRepository.Verify(r => r.AddAsync(It.IsAny<Genre>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Never);
    }
}
