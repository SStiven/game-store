using GameStore.Domain.Shippers;

using MediatR;

namespace GameStore.Application.Shippers.Queries.ListAll;

public record ListAllShippersQuery : IRequest<IReadOnlyList<Shipper>>;