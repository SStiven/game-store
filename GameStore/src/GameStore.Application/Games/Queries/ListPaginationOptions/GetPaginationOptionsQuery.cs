using MediatR;

namespace GameStore.Application.Games.Queries.ListPaginationOptions;

public record GetPaginationOptionsQuery() : IRequest<IEnumerable<PaginationOptions>>;