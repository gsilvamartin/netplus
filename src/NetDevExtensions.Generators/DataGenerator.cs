namespace NetDevExtensions.Generators;

public static class DataGenerator
{
    private static readonly string LoremIpsumText =
        @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
            Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure 
            dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur, excepteur sint occaecat cupidatat non
            proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

    private static readonly Random Random = new Random();

    public static T GenerateRandomData<T>()
    {
        var instance = Activator.CreateInstance<T>();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            var randomValue = GenerateRandomValue(property.PropertyType);
            property.SetValue(instance, randomValue);
        }

        return instance;
    }

    private static object? GenerateRandomValue(Type type)
    {
        if (type == typeof(int))
            return Random.Next();

        if (type == typeof(double))
            return Random.NextDouble();

        if (type == typeof(string))
            return GenerateRandomString();

        if (type == typeof(DateTime))
            return GenerateRandomDateTime();

        if (type == typeof(byte))
            return (byte)Random.Next(byte.MinValue, byte.MaxValue + 1);

        if (type == typeof(short))
            return (short)Random.Next(short.MinValue, short.MaxValue + 1);

        if (type == typeof(bool))
            return Random.Next(0, 2) == 1;

        return type.IsClass ? GenerateRandomData<object>() : Activator.CreateInstance(type);
    }

    private static string GenerateRandomString()
    {
        var randomStringLength = Random.Next(1, LoremIpsumText.Length);
        var randomStartPosition = Random.Next(0, LoremIpsumText.Length - randomStringLength);

        return LoremIpsumText.Substring(randomStartPosition, randomStringLength);
    }

    private static DateTime GenerateRandomDateTime()
    {
        var startDateTime = DateTime.MinValue;
        var range = (DateTime.MaxValue - startDateTime).Days;

        return startDateTime.AddDays(Random.Next(range));
    }
}