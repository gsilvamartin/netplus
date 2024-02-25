# MongoDB Connection Documentation

## Installation

To install the library via NuGet, you can use the following command in the Package Manager Console:

```shell
Install-Package NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB
```

Or through the .NET CLI:

```shell
dotnet add package NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB
```

## Configuration

To configure the MongoDB connection, you can use the `ConfigureMongoDb` extension method on `IServiceCollection`. This method takes a configuration object that is used to connect to the MongoDB database.

```csharp
services.ConfigureMongoDb(config =>
{
    config.DatabaseName = "myDatabase";
    config.ConnectionString = "mongodb://localhost:27017";
});
```

## Usage

To use the MongoDB repository, you can register the `IMongoRepository<T>` in the `IServiceCollection` using one of the extension methods `AddMongoRepository<T>`, `AddScopedMongoRepository<T>` or `AddSingletonMongoRepository<T>`. These methods take an optional configuration object to connect to the MongoDB database. If the configuration object is not specified, the `MongoRepository<T>` will be registered using the configuration used in the `ConfigureMongoDb` method.

```csharp
services.AddMongoRepository<MyEntity>();
```

Where `MyEntity` is a class that inherits from `BaseEntity` and has the `BsonCollectionAttribute`.

Note: All MongoDB entities should inherit from the `BaseEntity` class and have the `BsonCollectionAttribute` to specify the name of the collection that the entity represents.

Once the `IMongoRepository<T>` is registered, you can use it in your services by injecting it into the constructor. Here is an example:

```csharp
public class MyService
{
    private readonly IMongoRepository<MyEntity> _repository;

    public MyService(IMongoRepository<MyEntity> repository)
    {
        _repository = repository;
    }

    public async Task DoSomething()
    {
        var entity = await _repository.FindByIdAsync("some-id");
        // Do something with the entity
    }
}
```

## Remarks

The `IMongoRepository<T>` provides a set of methods for interacting with the MongoDB database. These methods include `FindByIdAsync`, `FindAllAsync`, `AddAsync`, `UpdateAsync`, and `DeleteAsync`. Each of these methods provides a way to perform CRUD operations on the MongoDB collection represented by the entity class `T`.

Remember to always call `ConfigureMongoDb` before registering any `IMongoRepository<T>`. This ensures that the MongoDB client is properly configured before it is used.
