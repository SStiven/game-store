using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Queries;

public class ListPublishersQueryHandler(IPublisherRepository publisherRepository)
    : IRequestHandler<ListPublishersQuery, ErrorOr<IReadOnlyList<Publisher>>>
{
    private readonly IPublisherRepository _publisherRepository = publisherRepository;

    public async Task<ErrorOr<IReadOnlyList<Publisher>>> Handle(
        ListPublishersQuery request,
        CancellationToken cancellationToken)
    {
        return await _publisherRepository.GetAllAsync();
    }
}
