namespace NetDevExtensions.Generators;

public static class GuidGenerator
{
    public static Guid GenerateGuid()
    {
        return Guid.NewGuid();
    }

    public static string GenerateGuidString()
    {
        return Guid.NewGuid().ToString();
    }

    public static byte[] GenerateGuidBytes()
    {
        return Guid.NewGuid().ToByteArray();
    }

    public static string GenerateGuidBase64()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}