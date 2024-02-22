using System;
using Microsoft.Extensions.DependencyInjection;
using NetPlus.ServiceAbstractions.Cache.Redis.Configuration;
using NetPlus.ServiceAbstractions.Cache.Redis.Interfaces;
using StackExchange.Redis;

namespace NetPlus.ServiceAbstractions.Cache.Redis.Extensions
{
    /// <summary>
    /// A static class providing extension methods for configuring Redis.
    /// </summary>
    public static class RedisRepositoryExtensions
    {
        /// <summary>
        /// Configures the Redis connection using the specified configuration.
        ///
        /// This method receives a configuration object and registers it as a singleton in the service collection.
        /// This configuration object is used to connect to the Redis server.
        ///
        /// Reminder: If you don't call this method, you'll need to specify the configuration when you create a
        /// RedisRepository instance using AddRedisRepository.
        ///
        /// </summary>
        /// <param name="service">Service Collection</param>
        /// <param name="configure">MongoDb Configuration</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ConfigureRedis(
            this IServiceCollection service,
            Action<RedisRepositoryOptions> configure)
        {
            var config = new RedisRepositoryOptions();
            configure.Invoke(config);

            if (string.IsNullOrEmpty(config.ConnectionString))
                throw new ArgumentNullException(nameof(config.ConnectionString),
                    "The connection string must be specified.");

            service.AddSingleton(config);
        }

        /// <summary>
        /// Registers the <see cref="IDatabase"/> for Redis in the service collection.
        /// This method allows you to configure and register the Redis database connection options.
        /// It registers the RedisRepository as a transient service.
        /// </summary>
        /// <param name="service">The <see cref="IServiceCollection"/> to register the Redis services.</param>
        /// <param name="configure">
        /// An optional action to configure the Redis connection options using the <see cref="RedisRepositoryOptions"/>.
        /// </param>
        /// <remarks>
        /// You must call the <see cref="ConfigureRedis"/> method before calling this method.
        /// If you don't want to use the <see cref="ConfigureRedis"/> method, you can directly create an instance of the
        /// <see cref="RedisRepositoryOptions"/> class and register it as a singleton in the service collection.
        /// You can send the configuration object directly to this method to override the existing injected connection,
        /// or create a new instance using the configuration.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the Redis configuration is not specified.
        /// </exception>
        public static void AddRedisRepository<T>(
            this IServiceCollection service,
            Action<RedisRepositoryOptions>? configure = null) where T : class
        {
            var config = new RedisRepositoryOptions();
            configure?.Invoke(config);

            service.AddTransient(typeof(IRedisRepository<T>), provider =>
            {
                var injectedConfig = provider.GetService<RedisRepositoryOptions>();

                if (injectedConfig == null)
                    throw new ArgumentNullException(nameof(injectedConfig),
                        "The Redis configuration must be specified.");

                var configurationOptions = new ConfigurationOptions
                {
                    EndPoints = { injectedConfig.ConnectionString },
                    AbortOnConnectFail = injectedConfig.AbortOnConnectFail,
                    AllowAdmin = injectedConfig.AllowAdmin,
                    ConnectTimeout = injectedConfig.ConnectTimeout,
                    KeepAlive = injectedConfig.KeepAlive,
                    SyncTimeout = injectedConfig.SyncTimeout,
                    Ssl = injectedConfig.ConnectionString.Contains("ssl=true"),
                };

                var connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
                var database = connectionMultiplexer.GetDatabase(injectedConfig.DatabaseNumber);

                return new RedisRepository<T>(database);
            });
        }

        /// <summary>
        /// Registers the <see cref="IDatabase"/> for Redis in the service collection.
        /// This method allows you to configure and register the Redis database connection options.
        /// It registers the RedisRepository as a scoped service.
        /// </summary>
        /// <param name="service">The <see cref="IServiceCollection"/> to register the Redis services.</param>
        /// <param name="configure">
        /// An optional action to configure the Redis connection options using the <see cref="RedisRepositoryOptions"/>.
        /// </param>
        /// <remarks>
        /// You must call the <see cref="ConfigureRedis"/> method before calling this method.
        /// If you don't want to use the <see cref="ConfigureRedis"/> method, you can directly create an instance of the
        /// <see cref="RedisRepositoryOptions"/> class and register it as a singleton in the service collection.
        /// You can send the configuration object directly to this method to override the existing injected connection,
        /// or create a new instance using the configuration.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the Redis configuration is not specified.
        /// </exception>
        public static void AddScopedRedisRepository<T>(
            this IServiceCollection service,
            Action<RedisRepositoryOptions>? configure = null) where T : class
        {
            var config = new RedisRepositoryOptions();
            configure?.Invoke(config);

            service.AddScoped(typeof(IRedisRepository<T>), provider =>
            {
                var injectedConfig = provider.GetService<RedisRepositoryOptions>();

                if (injectedConfig == null)
                    throw new ArgumentNullException(nameof(injectedConfig),
                        "The Redis configuration must be specified.");

                var configurationOptions = new ConfigurationOptions
                {
                    EndPoints = { injectedConfig.ConnectionString },
                    AbortOnConnectFail = injectedConfig.AbortOnConnectFail,
                    AllowAdmin = injectedConfig.AllowAdmin,
                    ConnectTimeout = injectedConfig.ConnectTimeout,
                    KeepAlive = injectedConfig.KeepAlive,
                    SyncTimeout = injectedConfig.SyncTimeout,
                    Ssl = injectedConfig.ConnectionString.Contains("ssl=true"),
                };

                var connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
                var database = connectionMultiplexer.GetDatabase(injectedConfig.DatabaseNumber);

                return new RedisRepository<T>(database);
            });
        }

        /// <summary>
        /// Registers the <see cref="IDatabase"/> for Redis in the service collection.
        /// This method allows you to configure and register the Redis database connection options.
        /// It registers the RedisRepository as a singleton service.
        /// </summary>
        /// <param name="service">The <see cref="IServiceCollection"/> to register the Redis services.</param>
        /// <param name="configure">
        /// An optional action to configure the Redis connection options using the <see cref="RedisRepositoryOptions"/>.
        /// </param>
        /// <remarks>
        /// You must call the <see cref="ConfigureRedis"/> method before calling this method.
        /// If you don't want to use the <see cref="ConfigureRedis"/> method, you can directly create an instance of the
        /// <see cref="RedisRepositoryOptions"/> class and register it as a singleton in the service collection.
        /// You can send the configuration object directly to this method to override the existing injected connection,
        /// or create a new instance using the configuration.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the Redis configuration is not specified.
        /// </exception>
        public static void AddSingletonRedisRepository<T>(
            this IServiceCollection service,
            Action<RedisRepositoryOptions>? configure = null) where T : class
        {
            var config = new RedisRepositoryOptions();
            configure?.Invoke(config);

            service.AddSingleton(typeof(IRedisRepository<T>), provider =>
            {
                var injectedConfig = provider.GetService<RedisRepositoryOptions>();

                if (injectedConfig == null)
                    throw new ArgumentNullException(nameof(injectedConfig),
                        "The Redis configuration must be specified.");

                var configurationOptions = new ConfigurationOptions
                {
                    EndPoints = { injectedConfig.ConnectionString },
                    AbortOnConnectFail = injectedConfig.AbortOnConnectFail,
                    AllowAdmin = injectedConfig.AllowAdmin,
                    ConnectTimeout = injectedConfig.ConnectTimeout,
                    KeepAlive = injectedConfig.KeepAlive,
                    SyncTimeout = injectedConfig.SyncTimeout,
                    Ssl = injectedConfig.ConnectionString.Contains("ssl=true"),
                };

                var connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
                var database = connectionMultiplexer.GetDatabase(injectedConfig.DatabaseNumber);

                return new RedisRepository<T>(database);
            });
        }
    }
}