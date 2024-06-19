using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;

using MediatR;

namespace GameStore.Application.Games.Queries;
public class GetGamesByPublisherQueryHandler(
    IGameRepository gameRepository)
    : IRequestHandler<GetGamesByPublisherQuery, IReadOnlyList<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<IReadOnlyList<Game>> Handle(
        GetGamesByPublisherQuery request,
        CancellationToken cancellationToken)
    {
        return await _gameRepository.GetByPublisherAsync(request.CompanyName);
    }
}
