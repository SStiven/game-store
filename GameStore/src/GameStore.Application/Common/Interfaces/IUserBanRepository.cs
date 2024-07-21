using GameStore.Domain.Bans;

namespace GameStore.Application.Common.Interfaces;

public interface IUserBanRepository
{
    Task AddAsync(UserBan userBan);

    Task<UserBan?> GetByUserNameAsync(string userName);

    Task UpdateAsync(UserBan userBan);
}
