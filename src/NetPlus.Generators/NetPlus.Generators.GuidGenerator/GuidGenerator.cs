using System;

namespace NetPlus.Generators.GuidGenerator
{
    /// <summary>
    /// A static class providing extension methods for generating GUIDs.
    /// </summary>
    public static class GuidGenerator
    {
        /// <summary>
        /// Generates a new GUID.
        /// </summary>
        /// <returns>A new GUID.</returns>
        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Generates a new GUID as a string.
        /// </summary>
        /// <returns>A new GUID as a string.</returns>
        public static string GenerateGuidString()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Generates a new GUID as a byte array.
        /// </summary>
        /// <returns>A new GUID as a byte array.</returns>
        public static byte[] GenerateGuidBytes()
        {
            return Guid.NewGuid().ToByteArray();
        }

        /// <summary>
        /// Generates a new GUID as a Base64 string.
        /// </summary>
        /// <returns>A new GUID as a Base64 string.</returns>
        public static string GenerateGuidBase64()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}