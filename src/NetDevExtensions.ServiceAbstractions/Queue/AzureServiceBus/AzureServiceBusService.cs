using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using NetDevExtensions.ServiceAbstractions.Queue.AzureServiceBus.Connection;
using NetDevExtensions.ServiceAbstractions.Queue.AzureServiceBus.Interfaces;
using Newtonsoft.Json;

namespace NetDevExtensions.ServiceAbstractions.Queue.AzureServiceBus
{
    /// <summary>
    /// Service for Azure Service Bus operations.
    /// </summary>
    /// <inheritdoc/>
    public class AzureServiceBusService : IAzureServiceBusService
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusAdministrationClient _administrationClient;

        public AzureServiceBusService(Action<AzureServiceBusConfiguration> sbConfiguration)
        {
            var configuration = new AzureServiceBusConfiguration();
            sbConfiguration.Invoke(configuration);

            var connectionString = configuration.ConnectionString;
            _serviceBusClient = new ServiceBusClient(connectionString);
            _administrationClient = new ServiceBusAdministrationClient(connectionString);
        }

        public async Task SendAsync<T>(T message, string destinationName)
        {
            var sender = _serviceBusClient.CreateSender(destinationName);

            try
            {
                var messageBody = JsonConvert.SerializeObject(message);
                var serviceBusMessage = new ServiceBusMessage(messageBody);
                await sender.SendMessageAsync(serviceBusMessage);
            }
            finally
            {
                await sender.DisposeAsync();
            }
        }

        public async Task SubscribeAsync<T>(
            Func<T, Task> handler,
            string subscriptionName,
            string destinationName,
            int maxConcurrentCalls = 1)
        {
            var processor = _serviceBusClient.CreateProcessor(destinationName, subscriptionName,
                new ServiceBusProcessorOptions
                {
                    MaxConcurrentCalls = maxConcurrentCalls
                });

            processor.ProcessMessageAsync += async args =>
            {
                var messageBody = JsonConvert.DeserializeObject<T>(args.Message.Body.ToString());

                if (messageBody != null)
                    await handler(messageBody);

                await args.CompleteMessageAsync(args.Message);
            };

            processor.ProcessErrorAsync += args => Task.CompletedTask;

            await processor.StartProcessingAsync();
        }

        public async Task DeleteSubscriptionAsync(string topicName, string subscriptionName)
        {
            await _administrationClient.DeleteSubscriptionAsync(topicName, subscriptionName);
        }

        public async Task<bool> TopicExistsAsync(string topicName)
        {
            return await _administrationClient.TopicExistsAsync(topicName);
        }

        public async Task<bool> QueueExistsAsync(string queueName)
        {
            return await _administrationClient.QueueExistsAsync(queueName);
        }

        public async Task CreateTopicAsync(string topicName)
        {
            await _administrationClient.CreateTopicAsync(topicName);
        }

        public async Task CreateSubscriptionAsync(string topicName, string subscriptionName)
        {
            await _administrationClient.CreateSubscriptionAsync(topicName, subscriptionName);
        }

        public async Task DeleteTopicAsync(string topicName)
        {
            await _administrationClient.DeleteTopicAsync(topicName);
        }

        public async Task SendBatchAsync<T>(IEnumerable<T> messages, string destinationName)
        {
            var sender = _serviceBusClient.CreateSender(destinationName);

            var serviceBusMessages = messages
                .Select(message => new ServiceBusMessage(JsonConvert.SerializeObject(message))).ToList();

            var batch = await sender.CreateMessageBatchAsync();

            foreach (var serviceBusMessage in serviceBusMessages.Where(serviceBusMessage =>
                         !batch.TryAddMessage(serviceBusMessage)))
            {
                await sender.SendMessagesAsync(batch);
                batch = await sender.CreateMessageBatchAsync();

                if (!batch.TryAddMessage(serviceBusMessage))
                {
                    throw new InvalidOperationException(
                        $"The message is too big to enter in batch: {serviceBusMessage.Body.ToArray().Length} bytes");
                }
            }

            if (batch.Count > 0) await sender.SendMessagesAsync(batch);
        }
    }
}