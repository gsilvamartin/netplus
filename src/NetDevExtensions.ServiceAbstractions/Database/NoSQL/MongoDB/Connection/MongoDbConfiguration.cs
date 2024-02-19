namespace NetDevExtensions.ServiceAbstractions.Database.NoSQL.MongoDB.Connection
{
    /// <summary>
    /// Represents the configuration for a MongoDB connection.
    /// </summary>
    public class MongoDbConfiguration
    {
        /// <summary>
        /// Gets or sets the connection string for the MongoDB connection.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to connect to.
        /// </summary>
        public string DatabaseName { get; set; }
    }
}