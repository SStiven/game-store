using GameStore.Domain.Shippers;

namespace GameStore.Application.Common.Interfaces;

public interface IShippersRepository
{
    Task<IReadOnlyList<Shipper>> GetAllAsync();
}
