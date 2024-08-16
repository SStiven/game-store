using GameStore.Application.Common.Interfaces;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace GameStore.Persistence.Shippers.MongoDb;

public class MongoDbShippersRepository : IShippersRepository
{
    private const string _databaseName = "northwind";
    private const string _collectionName = "shippers";
    private readonly IMongoCollection<Shipper> _collection;

    public MongoDbShippersRepository(IMongoClient mongoClient)
    {
        ArgumentNullException.ThrowIfNull(mongoClient);
        var mongoDatabase = mongoClient.GetDatabase(_databaseName);
        _collection = mongoDatabase.GetCollection<Shipper>(_collectionName);
    }

    public async Task<IReadOnlyList<Domain.Shippers.Shipper>> GetAllAsync()
    {
        var shippers = await _collection.Find(new BsonDocument()).ToListAsync();
        return shippers
            .Select(s => new Domain.Shippers.Shipper(s.ShipperId, s.CompanyName, s.Phone))
            .ToList();
    }
}
