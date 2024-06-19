using ErrorOr;

using GameStore.Application.Common.Interfaces;

using MediatR;

namespace GameStore.Application.Publishers.Commands.DeletePublisher;

public class DeletePublisherCommandHandler(
    IPublisherRepository publisherRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePublisherCommand, ErrorOr<Deleted>>
{
    private readonly IPublisherRepository _publisherRepository = publisherRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Deleted>> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByIdAsync(request.Id);
        if (publisher is null)
        {
            return Error.Validation(description: "Publisher not found");
        }

        if (await _gameRepository.AnyWithPublisherIdAsync(publisher.Id))
        {
            return Error.Validation(description: "Cannot delete a Publisher with games");
        }

        await _publisherRepository.DeleteAsync(publisher);
        await _unitOfWork.SaveChangesAsync();

        return Result.Deleted;
    }
}
