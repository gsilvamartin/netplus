using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetDevExtensions.ServiceAbstractions.Database.NoSQL.MongoDB.Entity
{
    /// <summary>
    /// Represents the base entity for a MongoDB collection.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
    }
}