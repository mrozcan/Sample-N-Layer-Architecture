using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace App.Core.Entity.Abstract;

public interface IMongoDocument : IBaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    ObjectId Id { get; init; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    DateTime CreateDate { get; set; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    DateTime? UpdateDate { get; set; }

}

