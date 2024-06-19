using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Commands.CreatePublisher;
internal class CreatePublisherCommandHandler(
    IPublisherRepository publisherRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePublisherCommand, ErrorOr<Publisher>>
{
    private readonly IPublisherRepository _publisherRepository = publisherRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Publisher>> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        if (await _publisherRepository.AnyWithCompanyName(request.CompanyName))
        {
            return Error.Validation(description: "Publisher with this company name already exists");
        }

        var publisher = new Publisher(
            request.CompanyName,
            request.HomePage,
            request.Description);

        await _publisherRepository.AddAsync(publisher);
        await _unitOfWork.SaveChangesAsync();

        return publisher;
    }
}
