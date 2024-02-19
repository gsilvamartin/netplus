namespace NetDevExtensions.ServiceAbstractions.Cache.Redis.Configuration;

/// <summary>
/// Options for configuring the Redis repository.
/// </summary>
public class RedisRepositoryOptions
{
    /// <summary>
    /// Gets or sets the Redis server connection string.
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets the number of the database to be used (default is 0).
    /// </summary>
    public int DatabaseNumber { get; set; } = 0;

    /// <summary>
    /// Gets or sets the synchronous timeout for Redis operations in milliseconds (default is 5000 milliseconds).
    /// </summary>
    public int SyncTimeout { get; set; } = 5000;

    /// <summary>
    /// Gets or sets a value indicating whether to allow administrative operations on the Redis server (default is false).
    /// </summary>
    public bool AllowAdmin { get; set; } = false;

    /// <summary>
    /// Gets or sets the connection timeout in milliseconds (default is 5000 milliseconds).
    /// </summary>
    public int ConnectTimeout { get; set; } = 5000;

    /// <summary>
    /// Gets or sets the time in seconds between pings sent to a Redis server to keep the connection alive (default is 180 seconds).
    /// </summary>
    public int KeepAlive { get; set; } = 180;

    /// <summary>
    /// Gets or sets a value indicating whether to abort the connection if the connection fails (default is false).
    /// </summary>
    public bool AbortOnConnectFail { get; set; } = false;
}