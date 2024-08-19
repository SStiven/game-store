using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.Persistence.Games.MongoDb;

[BsonIgnoreExtraElements]
public class Game
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("ProductName")]
    public string ProductName { get; set; }

    [BsonElement("SupplierID")]
    public int SupplierId { get; set; }

    [BsonElement("CategoryID")]
    public int CategoryId { get; set; }

    [BsonElement("QuantityPerUnit")]
    public string QuantityPerUnit { get; set; }

    [BsonElement("UnitPrice")]
    public decimal UnitPrice { get; set; }

    [BsonElement("UnitsInStock")]
    public int UnitsInStock { get; set; }

    [BsonElement("ReorderLevel")]
    public int ReorderLevel { get; set; }

    [BsonElement("Discontinued")]
    public bool Discontinued { get; set; }
}