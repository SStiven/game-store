using ErrorOr;

using GameStore.Domain.Publishers;

namespace GameStore.Application.Common.Interfaces;

public interface IPublisherRepository
{
    Task<Publisher?> GetByIdAsync(Guid id);

    Task<bool> AnyWithCompanyNameAsync(string companyName);

    Task AddAsync(Publisher publisher);

    Task DeleteAsync(Publisher publisher);

    Task<Publisher?> GetByCompanyNameAsync(string companyName);

    Task<ErrorOr<IReadOnlyList<Publisher>>> GetAllAsync();

    Task<Publisher?> GetByGameKeyAsync(string gameKey);

    Task Update(Publisher existingPublisher);
}
