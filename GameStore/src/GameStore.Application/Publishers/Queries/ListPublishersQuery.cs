using ErrorOr;

using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Queries;
public record ListPublishersQuery : IRequest<ErrorOr<IReadOnlyList<Publisher>>>;