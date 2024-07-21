using MediatR;

namespace GameStore.Application.Games.Queries.ListPaginationOptions;
public class GetPaginationOptionsQueryHandler : IRequestHandler<GetPaginationOptionsQuery, IEnumerable<PaginationOptions>>
{
    public Task<IEnumerable<PaginationOptions>> Handle(GetPaginationOptionsQuery request, CancellationToken cancellationToken)
    {
        var paginationOptions = Enum.GetValues(typeof(PaginationOptions)).Cast<PaginationOptions>().ToArray();
        return Task.FromResult<IEnumerable<PaginationOptions>>(paginationOptions);
    }
}
