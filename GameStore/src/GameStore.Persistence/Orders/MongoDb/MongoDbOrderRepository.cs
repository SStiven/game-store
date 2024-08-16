using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using MongoDB.Bson;
using MongoDB.Driver;

namespace GameStore.Persistence.Orders.MongoDb;

public class MongoDbOrderRepository : IReadOnlyOrderRepository
{
    private const string _databaseName = "northwind";
    private const string _collectionName = "orders";

    private readonly IMongoCollection<Order> _collection;

    public MongoDbOrderRepository(IMongoClient mongoClient)
    {
        ArgumentNullException.ThrowIfNull(mongoClient);
        var mongoDatabase = mongoClient.GetDatabase(_databaseName);
        _collection = mongoDatabase.GetCollection<Order>(_collectionName);
    }

    public async Task<IReadOnlyList<Domain.Orders.Order>> GetAllAsync()
    {
        var orders = await _collection.Find(new BsonDocument()).ToListAsync();
        var emptyOrder = new List<OrderGame>();
        return orders
            .Select(o => new Domain.Orders.Order(Guid.NewGuid(), Guid.Empty, o.OrderDate, emptyOrder))
            .ToList();
    }
}
