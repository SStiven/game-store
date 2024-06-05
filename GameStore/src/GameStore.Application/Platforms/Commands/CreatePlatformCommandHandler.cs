using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Platforms;
using GameStore.WebApi.Controllers.PlatformControllers.Dtos;
using MediatR;

namespace GameStore.Application.Platforms.Commands;

public class CreatePlatformCommandHandler(
    IPlatformRepository platformRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePlatformCommand, ErrorOr<Platform>>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Platform>> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _platformRepository.GetByTypeAsync(request.Type);

        if (platform is not null)
        {
            return Error.Validation(description: $"Platform with type:{request.Type} already exists");
        }

        var newPlatform = new Platform(request.Type);
        await _platformRepository.AddAsync(newPlatform);
        await _unitOfWork.SaveChangesAsync();
        return newPlatform;
    }
}