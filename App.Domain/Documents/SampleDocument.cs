using App.Core.Entity.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Domain.Documents
{
    public class SampleDocument : IMongoDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; init; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? UpdateDate { get; set; }

        public SampleDocument()
        {
            CreateDate = DateTime.UtcNow;
        }
    }
}
