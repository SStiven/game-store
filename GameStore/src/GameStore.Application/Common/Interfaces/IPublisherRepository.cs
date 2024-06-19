using GameStore.Domain.Publishers;

namespace GameStore.Application.Common.Interfaces;

public interface IPublisherRepository
{
    Task<Publisher?> GetByIdAsync(Guid id);

    Task<bool> AnyWithCompanyNameAsync(string companyName);

    Task AddAsync(Publisher publisher);

    Task DeleteAsync(Publisher publisher);
}
