using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetDevExtensions.ServiceAbstractions.Database.NoSQL.MongoDB.Entity
{
    public abstract class BaseEntity
    {
        [BsonElement("_id")] public ObjectId Id { get; set; }
    }
}