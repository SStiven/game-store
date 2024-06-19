using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Queries;
public class GetPublisherByCompanyNameQueryHandler(IPublisherRepository publisherRepository)
    : IRequestHandler<GetPublisherByCompanyNameQuery, ErrorOr<Publisher>>
{
    private readonly IPublisherRepository _publisherRepository = publisherRepository;

    public async Task<ErrorOr<Publisher>> Handle(
        GetPublisherByCompanyNameQuery request,
        CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByCompanyNameAsync(request.CompanyName);
        return publisher is null
            ? Error.NotFound(description: "Publisher not found")
            : publisher;
    }
}
