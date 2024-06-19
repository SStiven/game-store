using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Commands.UpdatePublisher;

internal class UpdatePublisherCommandHandler(
    IPublisherRepository publisherRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePublisherCommand, ErrorOr<Publisher>>
{
    private readonly IPublisherRepository _publisherRepository = publisherRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Publisher>> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        var existingPublisher = await _publisherRepository.GetByIdAsync(request.Id);
        if (existingPublisher is null)
        {
            return Error.NotFound(description: "The publisher with the specified ID was not found.");
        }

        existingPublisher.Update(
            request.CompanyName,
            request.HomePage,
            request.Description);

        await _publisherRepository.Update(existingPublisher);
        await _unitOfWork.SaveChangesAsync();

        return existingPublisher;
    }
}
