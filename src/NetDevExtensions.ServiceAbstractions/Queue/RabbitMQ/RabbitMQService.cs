using System;
using System.Text;
using System.Threading.Tasks;
using NetDevExtensions.ServiceAbstractions.Queue.RabbitMQ.Connection;
using NetDevExtensions.ServiceAbstractions.Queue.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NetDevExtensions.ServiceAbstractions.Queue.RabbitMQ;

/// <summary>
/// Provides a service for interacting with RabbitMQ message queues.
/// </summary>
/// <inheritdoc/>
public class RabbitMqService : IRabbitMqService
{
    private readonly IModel _channel;

    public RabbitMqService(Action<RabbitMQConfiguration> rabbitMqConfig)
    {
        var configuration = new RabbitMQConfiguration();
        rabbitMqConfig.Invoke(configuration);

        var factory = new ConnectionFactory
        {
            Uri = new Uri(configuration.ConnectionString)
        };

        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    public async Task PublishAsync<T>(
        T message,
        string exchangeName,
        string routingKey = "") where T : class
    {
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;

        await Task.Run(() => _channel.BasicPublish(exchange: exchangeName,
            routingKey: routingKey,
            basicProperties: properties,
            body: body));
    }

    public async Task SubscribeAsync<T>(
        Func<T, Task> handler,
        string queueName,
        string exchangeName,
        string routingKey = "") where T : class
    {
        _channel.QueueDeclare(queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        _channel.QueueBind(queue: queueName,
            exchange: exchangeName,
            routingKey: routingKey);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));

            if (message != null)
                await handler.Invoke(message);
        };

        await Task.Run(() =>
        {
            _channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);
        });
    }

    public async Task<TResponse> RequestAsync<TRequest, TResponse>(
        TRequest request,
        string exchangeName,
        string routingKey = "")
        where TRequest : class
        where TResponse : class
    {
        var tcs = new TaskCompletionSource<TResponse>();

        var replyQueueName = _channel.QueueDeclare().QueueName;
        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            if (ea.BasicProperties.CorrelationId != request.ToString()) return Task.CompletedTask;

            var body = ea.Body.ToArray();
            var response = JsonConvert.DeserializeObject<TResponse>(Encoding.UTF8.GetString(body));
            if (response != null)
                tcs.SetResult(response);

            return Task.CompletedTask;
        };

        _channel.BasicConsume(consumer: consumer,
            queue: replyQueueName,
            autoAck: true);

        var props = _channel.CreateBasicProperties();
        var correlationId = Guid.NewGuid().ToString();
        props.CorrelationId = correlationId;
        props.ReplyTo = replyQueueName;

        var message = JsonConvert.SerializeObject(request);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: exchangeName,
            routingKey: routingKey,
            basicProperties: props,
            body: body);

        return await tcs.Task;
    }

    public async Task RespondAsync<TRequest, TResponse>(
        Func<TRequest, Task<TResponse>> handler,
        string queueName,
        string exchangeName,
        string routingKey = "")
        where TRequest : class
        where TResponse : class
    {
        _channel.QueueDeclare(queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            await Task.Run(async () =>
            {
                var body = ea.Body.ToArray();
                var request = JsonConvert.DeserializeObject<TRequest>(Encoding.UTF8.GetString(body));

                if (request != null)
                {
                    var response = await handler.Invoke(request);

                    var replyProps = _channel.CreateBasicProperties();
                    replyProps.CorrelationId = ea.BasicProperties.CorrelationId;

                    var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));
                    _channel.BasicPublish(
                        exchange: exchangeName,
                        routingKey: ea.BasicProperties.ReplyTo,
                        basicProperties: replyProps,
                        body: responseBytes);
                }
            });
        };

        _channel.BasicConsume(queue: queueName,
            autoAck: true,
            consumer: consumer);

        await Task.CompletedTask;
    }

    public async Task<bool> QueueExistsAsync(string queueName)
    {
        await Task.Run(() => { _channel.QueueDeclarePassive(queueName); }).ConfigureAwait(false);
        return true;
    }

    public async Task<bool> ExchangeExistsAsync(string exchangeName)
    {
        await Task.Run(() => { _channel.ExchangeDeclarePassive(exchangeName); }).ConfigureAwait(false);
        return true;
    }

    public async Task BindQueueAsync(string queueName, string exchangeName, string routingKey = "")
    {
        await Task.Run(() => _channel.QueueBind(queueName, exchangeName, routingKey));
    }

    public async Task UnbindQueueAsync(string queueName, string exchangeName, string routingKey = "")
    {
        await Task.Run(() => _channel.QueueUnbind(queueName, exchangeName, routingKey));
    }

    public async Task DeleteQueueAsync(string queueName)
    {
        await Task.Run(() => _channel.QueueDelete(queueName));
    }

    public async Task DeleteExchangeAsync(string exchangeName)
    {
        await Task.Run(() => _channel.ExchangeDelete(exchangeName));
    }

    public async Task PurgeQueueAsync(string queueName)
    {
        await Task.Run(() => _channel.QueuePurge(queueName));
    }

    public async Task DeclareQueueAsync(
        string queueName,
        bool durable = true,
        bool exclusive = false,
        bool autoDelete = false)
    {
        await Task.Run(() => _channel.QueueDeclare(queueName, durable, exclusive, autoDelete));
    }

    public async Task DeclareExchangeAsync(
        string exchangeName,
        string type = ExchangeType.Direct,
        bool durable = true,
        bool autoDelete = false)
    {
        await Task.Run(() => _channel.ExchangeDeclare(exchangeName, type, durable, autoDelete));
    }

    public async Task<string> CreateTemporaryQueueAsync()
    {
        return await Task.Run(() => _channel.QueueDeclare().QueueName);
    }

    public async Task BindExchangeAsync(string sourceExchange, string destinationExchange, string routingKey = "")
    {
        await Task.Run(() => _channel.ExchangeBind(destinationExchange, sourceExchange, routingKey));
    }

    public async Task UnbindExchangeAsync(string sourceExchange, string destinationExchange, string routingKey = "")
    {
        await Task.Run(() => _channel.ExchangeUnbind(destinationExchange, sourceExchange, routingKey));
    }
}