using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public class ListGenresByGameKeyQueryHandler(
    IGenreRepository genreRepository,
    IGameRepository gameRepository) : IRequestHandler<ListGenresByGameKeyQuery, ErrorOr<IReadOnlyList<Genre>>>
{
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<ErrorOr<IReadOnlyList<Genre>>> Handle(ListGenresByGameKeyQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);

        return game is null
            ? Error.Validation(description: "Game with provided key not found")
            : await _genreRepository.GetByGameIdAsync(game.Id);
    }
}