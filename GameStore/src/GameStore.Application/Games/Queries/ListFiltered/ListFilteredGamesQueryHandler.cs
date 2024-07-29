using GameStore.Application.Common.Interfaces;
using GameStore.Application.Games.Queries.ListPaginationOptions;
using GameStore.Application.Games.Queries.ListSortingOptions;
using GameStore.Domain.Games;

using MediatR;

namespace GameStore.Application.Games.Queries.ListFiltered;
public class ListFilteredGamesQueryHandler(
    IGameRepository gameRepository) : IRequestHandler<ListFilteredGamesQuery, IEnumerable<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<IEnumerable<Game>> Handle(ListFilteredGamesQuery request, CancellationToken cancellationToken)
    {
        var expression = new GameFilterBuilder()
            .ByName(request.Name)
            .ByMinPrice(request.MinPrice)
            .ByMaxPrice(request.MaxPrice)
            .ByPlatforms(request.Platforms)
            .ByGenres(request.Genres)
            .ByPublishers(request.Publishers)
            .Build();

        var sortingOption = SortingOptionsExtensions.FromString(request.Sort);
        var pageCount = PaginationOptionExtensions.FromInt(request.PageCount);
        var page = request.Page ?? 1;

        return await _gameRepository.GetFilteredAsyncBy(
            expression,
            sortingOption,
            page,
            pageCount.ToInt());
    }
}
