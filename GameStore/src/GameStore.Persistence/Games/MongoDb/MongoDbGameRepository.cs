using GameStore.Application.Common.Interfaces;

using MongoDB.Bson;
using MongoDB.Driver;

namespace GameStore.Persistence.Games.MongoDb;

public class MongoDbGameRepository : IReadOnlyGameRespository
{
    private const string _databaseName = "northwind";
    private const string _collectionName = "products";
    private readonly IMongoCollection<Game> _collection;

    public MongoDbGameRepository(IMongoClient mongoClient)
    {
        ArgumentNullException.ThrowIfNull(mongoClient);
        var mongoDatabase = mongoClient.GetDatabase(_databaseName);
        _collection = mongoDatabase.GetCollection<Game>(_collectionName);
    }

    public async Task<IReadOnlyList<Domain.Games.Game>> GetAllAsync()
    {
        var games = await _collection.Find(new BsonDocument()).ToListAsync();
        var emptyGuid = new List<Guid>();

        return games
            .Select(g => new Domain.Games.Game(
                g.ProductName,
                g.ProductName,
                string.Empty,
                (double)g.UnitPrice,
                g.UnitsInStock,
                0,
                emptyGuid,
                emptyGuid,
                null))
            .ToList();
    }
}
