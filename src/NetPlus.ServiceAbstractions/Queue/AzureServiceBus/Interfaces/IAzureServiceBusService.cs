using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPlus.ServiceAbstractions.Queue.AzureServiceBus.Interfaces;

/// <summary>
/// Interface for Azure Service Bus operations.
/// </summary>
public interface IAzureServiceBusService
{
    /// <summary>
    /// Sends a message to the specified destination (queue or topic).
    /// </summary>
    /// <typeparam name="T">The type of the message.</typeparam>
    /// <param name="message">The message to be sent.</param>
    /// <param name="destinationName">The name of the destination (queue or topic).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendAsync<T>(T message, string destinationName);

    /// <summary>
    /// Subscribes to a destination (queue or topic) and processes messages with the provided handler.
    /// </summary>
    /// <typeparam name="T">The type of the message.</typeparam>
    /// <param name="handler">The handler for processing messages.</param>
    /// <param name="subscriptionName">The name of the subscription (only applicable for topics).</param>
    /// <param name="destinationName">The name of the destination (queue or topic).</param>
    /// <param name="maxConcurrentCalls">The maximum number of concurrent calls to the handler.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SubscribeAsync<T>(
        Func<T, Task> handler,
        string subscriptionName,
        string destinationName,
        int maxConcurrentCalls = 1);

    /// <summary>
    /// Deletes a subscription for a topic.
    /// </summary>
    /// <param name="topicName">The name of the topic.</param>
    /// <param name="subscriptionName">The name of the subscription to be deleted.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteSubscriptionAsync(string topicName, string subscriptionName);

    /// <summary>
    /// Checks if a topic exists.
    /// </summary>
    /// <param name="topicName">The name of the topic.</param>
    /// <returns>A task representing the asynchronous operation, returning true if the topic exists, false otherwise.</returns>
    Task<bool> TopicExistsAsync(string topicName);

    /// <summary>
    /// Checks if a queue exists.
    /// </summary>
    /// <param name="queueName">The name of the queue.</param>
    /// <returns>A task representing the asynchronous operation, returning true if the queue exists, false otherwise.</returns>
    Task<bool> QueueExistsAsync(string queueName);

    /// <summary>
    /// Creates a new topic.
    /// </summary>
    /// <param name="topicName">The name of the topic to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateTopicAsync(string topicName);

    /// <summary>
    /// Creates a new subscription for a topic.
    /// </summary>
    /// <param name="topicName">The name of the topic.</param>
    /// <param name="subscriptionName">The name of the subscription to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateSubscriptionAsync(string topicName, string subscriptionName);

    /// <summary>
    /// Deletes a topic.
    /// </summary>
    /// <param name="topicName">The name of the topic to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, returning true if the topic is deleted, false otherwise.</returns>
    Task DeleteTopicAsync(string topicName);

    /// <summary>
    /// Sends a batch of messages to the specified destination (queue or topic).
    /// </summary>
    /// <typeparam name="T">The type of the messages in the batch.</typeparam>
    /// <param name="messages">The messages to be sent in the batch.</param>
    /// <param name="destinationName">The name of the destination (queue or topic).</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendBatchAsync<T>(IEnumerable<T> messages, string destinationName);
}