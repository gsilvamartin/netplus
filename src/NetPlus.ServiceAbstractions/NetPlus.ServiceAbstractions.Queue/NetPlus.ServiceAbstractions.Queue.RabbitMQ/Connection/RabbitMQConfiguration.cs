namespace NetPlus.ServiceAbstractions.Queue.RabbitMQ.Connection;

/// <summary>
/// Represents the configuration for a RabbitMQ connection.
/// </summary>
public class RabbitMQConfiguration
{
    /// <summary>
    /// Gets or sets the connection string for the RabbitMQ connection.
    /// </summary>
    public string ConnectionString { get; set; }
}