using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Queries;
public class GetPublisherByGameKeyQueryHandler(IPublisherRepository publisherRepository)
    : IRequestHandler<GetPublisherByGameKeyQuery, ErrorOr<Publisher>>
{
    private readonly IPublisherRepository _publisherRepository = publisherRepository;

    public async Task<ErrorOr<Publisher>> Handle(GetPublisherByGameKeyQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByGameKeyAsync(request.GameKey);
        return publisher is null
            ? Error.NotFound(description: "Publisher not found")
            : publisher;
    }
}
