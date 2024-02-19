using System;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace NetPlus.ServiceAbstractions.Queue.RabbitMQ.Interfaces
{
    /// <summary>
    /// RabbitMQ service interface
    /// </summary>
    public interface IRabbitMqService
    {
        /// <summary>
        /// Publishes a message to a RabbitMQ exchange.
        /// </summary>
        /// <typeparam name="T">The type of the message.</typeparam>
        /// <param name="message">The message to be published.</param>
        /// <param name="exchangeName">The name of the exchange.</param>
        /// <param name="routingKey">The routing key for the message.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task PublishAsync<T>(T message, string exchangeName, string routingKey = "") where T : class;

        /// <summary>
        /// Subscribes to messages from a RabbitMQ queue.
        /// </summary>
        /// <typeparam name="T">The type of the message.</typeparam>
        /// <param name="handler">The asynchronous handler for processing received messages.</param>
        /// <param name="queueName">The name of the queue to subscribe to.</param>
        /// <param name="exchangeName">The name of the exchange to bind the queue to.</param>
        /// <param name="routingKey">The routing key for the binding.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SubscribeAsync<T>(Func<T, Task> handler, string queueName, string exchangeName, string routingKey = "")
            where T : class;

        /// <summary>
        /// Sends a request to a RabbitMQ exchange and awaits a response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request message.</typeparam>
        /// <typeparam name="TResponse">The type of the response message.</typeparam>
        /// <param name="request">The request message to be sent.</param>
        /// <param name="exchangeName">The name of the exchange.</param>
        /// <param name="routingKey">The routing key for the message.</param>
        /// <returns>A task representing the asynchronous operation with the response message.</returns>
        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request, string exchangeName, string routingKey = "")
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// Responds to a RabbitMQ request with a generated response.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request message.</typeparam>
        /// <typeparam name="TResponse">The type of the response message.</typeparam>
        /// <param name="handler">The asynchronous handler for processing the request and generating the response.</param>
        /// <param name="queueName">The name of the queue to listen for requests.</param>
        /// <param name="exchangeName">The name of the exchange to bind the queue to.</param>
        /// <param name="routingKey">The routing key for the binding.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> handler, string queueName,
            string exchangeName, string routingKey = "")
            where TRequest : class
            where TResponse : class;

        /// <summary>
        /// Checks if a RabbitMQ queue exists.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A task representing the asynchronous operation with a boolean indicating the existence of the queue.</returns>
        Task<bool> QueueExistsAsync(string queueName);

        /// <summary>
        /// Checks if a RabbitMQ exchange exists.
        /// </summary>
        /// <param name="exchangeName">The name of the exchange.</param>
        /// <returns>A task representing the asynchronous operation with a boolean indicating the existence of the exchange.</returns>
        Task<bool> ExchangeExistsAsync(string exchangeName);

        /// <summary>
        /// Binds a RabbitMQ queue to an exchange with a routing key.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="exchangeName">The name of the exchange.</param>
        /// <param name="routingKey">The routing key for the binding.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task BindQueueAsync(string queueName, string exchangeName, string routingKey = "");

        /// <summary>
        /// Unbinds a RabbitMQ queue from an exchange with a routing key.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="exchangeName">The name of the exchange.</param>
        /// <param name="routingKey">The routing key for the unbinding.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UnbindQueueAsync(string queueName, string exchangeName, string routingKey = "");

        /// <summary>
        /// Deletes a RabbitMQ queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteQueueAsync(string queueName);

        /// <summary>
        /// Deletes a RabbitMQ exchange.
        /// </summary>
        /// <param name="exchangeName">The name of the exchange.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteExchangeAsync(string exchangeName);

        /// <summary>
        /// Purges all messages from a RabbitMQ queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task PurgeQueueAsync(string queueName);

        /// <summary>
        /// Declares a RabbitMQ queue with specified options.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="durable">Whether the queue should survive a broker restart.</param>
        /// <param name="exclusive">Whether the queue should only be used by the connection that created it.</param>
        /// <param name="autoDelete">Whether the queue should be deleted when no consumers are connected.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeclareQueueAsync(string queueName, bool durable = true, bool exclusive = false, bool autoDelete = false);

        /// <summary>
        /// Declares a RabbitMQ exchange.
        /// </summary>
        /// <param name="exchangeName">The name of the exchange to be declared.</param>
        /// <param name="type">The type of the exchange (e.g., Direct, Fanout).</param>
        /// <param name="durable">Indicates if the exchange should survive a broker restart.</param>
        /// <param name="autoDelete">Indicates if the exchange will be deleted when no queues are bound to it.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeclareExchangeAsync(string exchangeName, string type = ExchangeType.Direct, bool durable = true,
            bool autoDelete = false);

        /// <summary>
        /// Creates a temporary RabbitMQ queue.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with the name of the created queue.</returns>
        Task<string> CreateTemporaryQueueAsync();

        /// <summary>
        /// Binds a RabbitMQ exchange to another exchange.
        /// </summary>
        /// <param name="sourceExchange">The name of the source exchange.</param>
        /// <param name="destinationExchange">The name of the destination exchange.</param>
        /// <param name="routingKey">The routing key for the binding.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task BindExchangeAsync(string sourceExchange, string destinationExchange, string routingKey = "");

        /// <summary>
        /// Unbinds a RabbitMQ exchange from another exchange.
        /// </summary>
        /// <param name="sourceExchange">The name of the source exchange.</param>
        /// <param name="destinationExchange">The name of the destination exchange.</param>
        /// <param name="routingKey">The routing key for the unbinding.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UnbindExchangeAsync(string sourceExchange, string destinationExchange, string routingKey = "");
    }
}