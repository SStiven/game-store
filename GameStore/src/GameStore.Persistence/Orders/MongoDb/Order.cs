using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameStore.Persistence.Orders.MongoDb;

[BsonIgnoreExtraElements]
public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("OrderID")]
    public int OrderId { get; set; }

    [BsonElement("CustomerID")]
    public string CustomerId { get; set; } = string.Empty;

    [BsonElement("OrderDate")]
    [BsonSerializer(typeof(CustomDateTimeSerializer))]
    public DateTime OrderDate { get; set; }
}
