using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Bans;

using MediatR;

namespace GameStore.Application.Users.Commands.BanUser;

public class BanUserCommandHandler(
    IUserBanRepository userBanRepository,
    IUnitOfWork unitOfWork)
        : IRequestHandler<BanUserCommand, ErrorOr<Success>>
{
    private readonly IUserBanRepository _userBanRepository = userBanRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Success>> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        var existingBan = await _userBanRepository.GetByUserNameAsync(request.UserName);
        var dateTimeNow = DateTime.UtcNow;

        if (existingBan is not null)
        {
            existingBan.AddDuration(request.BanDuration, dateTimeNow);
            await _userBanRepository.UpdateAsync(existingBan);
        }
        else
        {
            var newBan = new UserBan(request.UserName, request.BanDuration, dateTimeNow);
            await _userBanRepository.AddAsync(newBan);
        }

        await _unitOfWork.SaveChangesAsync();
        return Result.Success;
    }
}
