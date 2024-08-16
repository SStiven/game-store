using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GameStore.Persistence.Orders.MongoDb;
public class CustomDateTimeSerializer : SerializerBase<DateTime>
{
    private const string Format = "yyyy-MM-dd HH:mm:ss.fff";

    public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
#pragma warning disable IDE0300
        string[] formats = { Format };
#pragma warning restore IDE0300
        var bsonValue = context.Reader.ReadString();
        return DateTime.ParseExact(bsonValue, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
    {
        context.Writer.WriteString(value.ToString("yyyy-MM-dd HH:mm:ss.fff"));
    }
}
