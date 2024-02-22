using System;
using Microsoft.Extensions.DependencyInjection;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Connection;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Entity;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Interfaces;

namespace NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Extensions
{
    /// <summary>
    /// A static class providing extension methods for configuring MongoDB.
    /// </summary>
    public static class MongoRepositoryExtensions
    {
        /// <summary>
        /// Configures the MongoDB connection using the specified configuration.
        ///
        /// This method receives a configuration object and registers it as a singleton in the service collection.
        /// This configuration object is used to connect to the MongoDB database.
        ///
        /// If you don't want to use this configuration method, you can directly create a instance of the
        /// <see cref="MongoDbConfiguration"/> class and register it as a singleton in the service collection.
        ///
        /// Reminder: If you don't call this method, you'll need to specify the configuration when you create a
        /// <see cref="MongoRepository{T}"/> instance using <see cref="AddMongoRepository{T}"/>.
        /// 
        /// </summary>
        /// <param name="service">Service Collection</param>
        /// <param name="configure">MongoDb Configuration</param>
        public static void ConfigureMongoDb(this IServiceCollection service, Action<MongoDbConfiguration> configure)
        {
            var config = new MongoDbConfiguration();
            configure(config);

            if (string.IsNullOrEmpty(config.DatabaseName))
                throw new ArgumentNullException(nameof(config.DatabaseName), "The database name must be specified.");

            if (string.IsNullOrEmpty(config.ConnectionString))
                throw new ArgumentNullException(nameof(config.ConnectionString),
                    "The connection string must be specified.");

            service.AddSingleton(config);
        }

        /// <summary>
        /// Registers the <see cref="IMongoRepository{T}"/> in the service collection.
        ///
        /// This method receives as optional parameter a configuration object to connect to the MongoDB database.
        /// If the configuration object is not specified, the <see cref="MongoRepository{T}"/> will be registered
        /// using the configuration used in the <see cref="ConfigureMongoDb"/> method.
        ///
        /// This method registers the <see cref="IMongoRepository{T}"/> as a transient service.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configure"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddMongoRepository<T>(
            this IServiceCollection service,
            Action<MongoDbConfiguration>? configure = null) where T : BaseEntity
        {
            var config = new MongoDbConfiguration();
            configure?.Invoke(config);

            service.AddTransient<IMongoRepository<T>, MongoRepository<T>>(options =>
            {
                var injectedConfig = options.GetService<MongoDbConfiguration>();

                if (injectedConfig == null)
                    throw new ArgumentNullException(nameof(MongoDbConfiguration),
                        "The MongoDB configuration must be specified.");

                return string.IsNullOrEmpty(config.ConnectionString) || string.IsNullOrEmpty(config.DatabaseName)
                    ? new MongoRepository<T>(injectedConfig)
                    : new MongoRepository<T>(config);
            });
        }
        
        /// <summary>
        /// Registers the <see cref="IMongoRepository{T}"/> in the service collection.
        ///
        /// This method receives as optional parameter a configuration object to connect to the MongoDB database.
        /// If the configuration object is not specified, the <see cref="MongoRepository{T}"/> will be registered
        /// using the configuration used in the <see cref="ConfigureMongoDb"/> method.
        ///
        /// This method registers the <see cref="IMongoRepository{T}"/> as a scoped service.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configure"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddScopedMongoRepository<T>(
            this IServiceCollection service,
            Action<MongoDbConfiguration>? configure = null) where T : BaseEntity
        {
            var config = new MongoDbConfiguration();
            configure?.Invoke(config);

            service.AddScoped<IMongoRepository<T>, MongoRepository<T>>(options =>
            {
                var injectedConfig = options.GetService<MongoDbConfiguration>();

                if (injectedConfig == null)
                    throw new ArgumentNullException(nameof(MongoDbConfiguration),
                        "The MongoDB configuration must be specified.");

                return string.IsNullOrEmpty(config.ConnectionString) || string.IsNullOrEmpty(config.DatabaseName)
                    ? new MongoRepository<T>(injectedConfig)
                    : new MongoRepository<T>(config);
            });
        }
        
        
        /// <summary>
        /// Registers the <see cref="IMongoRepository{T}"/> in the service collection.
        ///
        /// This method receives as optional parameter a configuration object to connect to the MongoDB database.
        /// If the configuration object is not specified, the <see cref="MongoRepository{T}"/> will be registered
        /// using the configuration used in the <see cref="ConfigureMongoDb"/> method.
        ///
        /// This method registers the <see cref="IMongoRepository{T}"/> as a singleton service.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configure"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddSingletonMongoRepository<T>(
            this IServiceCollection service,
            Action<MongoDbConfiguration>? configure = null) where T : BaseEntity
        {
            var config = new MongoDbConfiguration();
            configure?.Invoke(config);

            service.AddSingleton<IMongoRepository<T>, MongoRepository<T>>(options =>
            {
                var injectedConfig = options.GetService<MongoDbConfiguration>();

                if (injectedConfig == null)
                    throw new ArgumentNullException(nameof(MongoDbConfiguration),
                        "The MongoDB configuration must be specified.");

                return string.IsNullOrEmpty(config.ConnectionString) || string.IsNullOrEmpty(config.DatabaseName)
                    ? new MongoRepository<T>(injectedConfig)
                    : new MongoRepository<T>(config);
            });
        }
    }
}