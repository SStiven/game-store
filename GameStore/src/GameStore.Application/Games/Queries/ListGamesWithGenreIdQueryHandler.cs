using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public class ListGamesWithGenreIdQueryHandler(IGameRepository gameRepository)
    : IRequestHandler<ListGamesWithGenreIdQuery, ErrorOr<IList<Game>>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<ErrorOr<IList<Game>>> Handle(ListGamesWithGenreIdQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetAllWithGenreIdAsync(request.GenreId);
    }
}