using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.Persistence.Shippers.MongoDb;

public class Shipper
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("ShipperID")]
    public int ShipperId { get; set; }

    [BsonElement("CompanyName")]
    public string CompanyName { get; set; } = string.Empty;

    [BsonElement("Phone")]
    public string Phone { get; set; } = string.Empty;
}
