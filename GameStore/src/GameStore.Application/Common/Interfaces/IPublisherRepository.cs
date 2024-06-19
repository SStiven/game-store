using GameStore.Domain.Publishers;

namespace GameStore.Application.Common.Interfaces;

public interface IPublisherRepository
{
    Task<Publisher?> GetByIdAsync(Guid id);

    Task<bool> AnyWithCompanyName(string companyName);

    Task AddAsync(Publisher publisher);
}
