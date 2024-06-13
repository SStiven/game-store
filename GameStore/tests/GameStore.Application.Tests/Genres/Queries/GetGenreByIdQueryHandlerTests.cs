using ErrorOr;

using FluentAssertions;

using GameStore.Application.Common.Interfaces;
using GameStore.Application.Genres.Queries;
using GameStore.Domain.Genres;

using Moq;

namespace GameStore.Application.Tests.Genres.Queries;

public class GetGenreByIdQueryHandlerTests
{
    private readonly Mock<IGenreRepository> _genreRepositoryMock;
    private readonly GetGenreByIdQueryHandler _handler;

    public GetGenreByIdQueryHandlerTests()
    {
        _genreRepositoryMock = new Mock<IGenreRepository>();
        _handler = new GetGenreByIdQueryHandler(_genreRepositoryMock.Object);
    }

    [Fact]
    public async Task ShouldReturnNotFoundErrorWhenGenreDoesNotExist()
    {
        var request = new GetGenreByIdQuery(Guid.NewGuid());
        _genreRepositoryMock.Setup(repo => repo.GetByIdAsync(request.Id))
                            .ReturnsAsync((Genre)null);

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
    }

    [Fact]
    public async Task ShouldReturnGenreWhenGenreExists()
    {
        var genre = new Genre("Genre Name", null);
        var request = new GetGenreByIdQuery(genre.Id);

        _genreRepositoryMock.Setup(repo => repo.GetByIdAsync(request.Id))
                            .ReturnsAsync(genre);

        var result = await _handler.Handle(request, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Should().Be(genre);
    }
}
