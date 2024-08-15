using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Shippers;

using MediatR;

namespace GameStore.Application.Shippers.Queries.ListAll;
public class ListAllShippersQueryHandler : IRequestHandler<ListAllShippersQuery, IReadOnlyList<Shipper>>
{
    private readonly IShippersRepository _shippersRepository;

    public ListAllShippersQueryHandler(IShippersRepository shippersRepository)
    {
        ArgumentNullException.ThrowIfNull(shippersRepository);

        _shippersRepository = shippersRepository;
    }

    public async Task<IReadOnlyList<Shipper>> Handle(ListAllShippersQuery request, CancellationToken cancellationToken)
    {
        return await _shippersRepository.GetAllAsync();
    }
}
