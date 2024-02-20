using System;

namespace NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Entity
{
    /// <summary>
    /// Represents the attribute for a MongoDB collection.
    ///
    /// This attribute is used to specify the name of the collection that the entity represents.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class BsonCollectionAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the collection that the entity represents.
        /// </summary>
        public string CollectionName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BsonCollectionAttribute"/> class.
        /// </summary>
        /// <param name="collectionName"></param>
        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}