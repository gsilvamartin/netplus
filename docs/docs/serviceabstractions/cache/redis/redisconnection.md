# Redis Connection

The `NetPlus.ServiceAbstractions.Cache.Redis` library provides a set of extension methods for `IServiceCollection` to easily configure and register a Redis repository in the .NET Core dependency injection container.

## Installation

To install the `NetPlus.ServiceAbstractions.Cache.Redis` library, you can use the NuGet package manager. In the Visual Studio terminal, run the following command:

```shell
Install-Package NetPlus.ServiceAbstractions.Cache.Redis
```

Or, if you're using the .NET Core command-line interface:

```shell
dotnet add package NetPlus.ServiceAbstractions.Cache.Redis
```

> [!NOTE]
> The `NetPlus.ServiceAbstractions.Cache.Redis` library is designed to work with .NET Core's built-in dependency injection. If you're using a different dependency injection framework, you may need to adapt the code accordingly.

## Configuration

The `ConfigureRedis` extension method is used to set up the Redis connection. This method accepts a `RedisRepositoryOptions` object where the Redis connection string and other settings can be specified.

```csharp
services.ConfigureRedis(options =>
{
    options.ConnectionString = "your_redis_connection_string";
    // other settings...
});
```

This method registers the `RedisRepositoryOptions` object as a singleton in the service collection. This means that the same instance of `RedisRepositoryOptions` will be used every time it is requested from the service collection.

> [!TIP]
> The `RedisRepositoryOptions` object can be configured with various settings such as connection timeout, database number, etc. Refer to the `RedisRepositoryOptions` documentation for more details.

## Registering the Redis Repository

The Redis repository can be registered in the service collection as a transient, scoped, or singleton service using the `AddRedisRepository`, `AddScopedRedisRepository`, or `AddSingletonRedisRepository` methods respectively.

```csharp
services.AddRedisRepository<MyClass>();
services.AddScopedRedisRepository<MyClass>();
services.AddSingletonRedisRepository<MyClass>();
```

These methods accept a generic parameter `T` which is the type of the objects to be stored in the Redis cache. They also accept an optional `Action<RedisRepositoryOptions>` parameter that can be used to override the existing injected connection or create a new instance using the configuration.

The `AddRedisRepository` method registers the `IRedisRepository<T>` as a transient service, meaning a new instance will be created each time it is requested.

The `AddScopedRedisRepository` method registers the `IRedisRepository<T>` as a scoped service, meaning a new instance will be created once per request.

The `AddSingletonRedisRepository` method registers the `IRedisRepository<T>` as a singleton service, meaning the same instance will be used every time it is requested.

> [!IMPORTANT]
> The choice between transient, scoped, and singleton services depends on the specific needs of your application. Transient services can be useful when each consumer needs a unique instance, while scoped services are useful for per-request data. Singleton services are useful when a single instance should be shared across the entire application.

Once the Redis repository is registered, `IRedisRepository<T>` can be injected into classes and used to interact with the Redis server.

The `NetPlus.ServiceAbstractions.Cache.Redis` library provides a set of extension methods for `IServiceCollection` to easily configure and register a Redis repository in the .NET Core dependency injection container.

> [!NOTE]
> The `NetPlus.ServiceAbstractions.Cache.Redis` library is designed to work with .NET Core's built-in dependency injection. If you're using a different dependency injection framework, you may need to adapt the code accordingly.

## Configuration

The `ConfigureRedis` extension method is used to set up the Redis connection. This method accepts a `RedisRepositoryOptions` object where the Redis connection string and other settings can be specified.

```csharp
services.ConfigureRedis(options =>
{
    options.ConnectionString = "your_redis_connection_string";
    // other settings...
});
```

This method registers the `RedisRepositoryOptions` object as a singleton in the service collection. This means that the same instance of `RedisRepositoryOptions` will be used every time it is requested from the service collection.

> [!TIP]
> The `RedisRepositoryOptions` object can be configured with various settings such as connection timeout, database number, etc. Refer to the `RedisRepositoryOptions` documentation for more details.

## Registering the Redis Repository

The Redis repository can be registered in the service collection as a transient, scoped, or singleton service using the `AddRedisRepository`, `AddScopedRedisRepository`, or `AddSingletonRedisRepository` methods respectively.

```csharp
services.AddRedisRepository<MyClass>();
services.AddScopedRedisRepository<MyClass>();
services.AddSingletonRedisRepository<MyClass>();
```

These methods accept a generic parameter `T` which is the type of the objects to be stored in the Redis cache. They also accept an optional `Action<RedisRepositoryOptions>` parameter that can be used to override the existing injected connection or create a new instance using the configuration.

The `AddRedisRepository` method registers the `IRedisRepository<T>` as a transient service, meaning a new instance will be created each time it is requested.

The `AddScopedRedisRepository` method registers the `IRedisRepository<T>` as a scoped service, meaning a new instance will be created once per request.

The `AddSingletonRedisRepository` method registers the `IRedisRepository<T>` as a singleton service, meaning the same instance will be used every time it is requested.

> [!IMPORTANT]
> The choice between transient, scoped, and singleton services depends on the specific needs of your application. Transient services can be useful when each consumer needs a unique instance, while scoped services are useful for per-request data. Singleton services are useful when a single instance should be shared across the entire application.

Once the Redis repository is registered, `IRedisRepository<T>` can be injected into classes and used to interact with the Redis server.
