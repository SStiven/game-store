using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Commands.UpdatePlatform;

public class UpdatePlatformCommandHandler(
    IPlatformRepository platformRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePlatformCommand, ErrorOr<Platform>>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Platform>> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _platformRepository.GetByTypeAsync(request.Type);
        if (platform is not null)
        {
            return Error.Validation(description: $"Platform with type {request.Type} already exists, it must be unique.");
        }

        var platformToUpdate = await _platformRepository.GetByIdAsync(request.Id);
        platformToUpdate.Update(request.Type);

        await _platformRepository.UpdateAsync(platformToUpdate);
        await _unitOfWork.SaveChangesAsync();

        return platformToUpdate;
    }
}