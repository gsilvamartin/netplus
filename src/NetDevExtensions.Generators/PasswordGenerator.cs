using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDevExtensions.Generators
{
    public static class PasswordGenerator
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Generates a alphanumeric random password of the specified length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GeneratePassword(int length)
        {
            if (length < 6) throw new ArgumentException("Password length must be at least 6 characters.");

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
            return new string(Enumerable.Repeat(chars, length)
                               .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a random password of the specified length using the specified allowed characters.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="allowedChars"></param>
        /// <returns></returns>
        public static string GeneratePassword(int length, string allowedChars)
        {
            if (length < 6) throw new ArgumentException("Password length must be at least 6 characters.");

            return new string(Enumerable.Repeat(allowedChars, length)
                                              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a random password of the specified length using the specified allowed characters and number of non-alphanumeric characters.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="allowedChars"></param>
        /// <param name="numberOfNonAlphanumericCharacters"></param>
        /// <returns></returns>
        public static string GeneratePassword(int length, string allowedChars, int numberOfNonAlphanumericCharacters)
        {
            if (length < 6) throw new ArgumentException("Password length must be at least 6 characters.");

            var result = new StringBuilder();
            var nonAlphanumericIndex = length - numberOfNonAlphanumericCharacters;

            for (var i = 0; i < nonAlphanumericIndex; i++)
            {
                result.Append(allowedChars[Random.Next(0, allowedChars.Length - 1)]);
            }

            for (var i = 0; i < numberOfNonAlphanumericCharacters; i++)
            {
                result.Append(GenerateNonAlphanumericCharacter());
            }

            return result.ToString();
        }

        /// <summary>
        /// Generate non alphanumeric character.
        /// </summary>
        /// <returns></returns>
        private static char GenerateNonAlphanumericCharacter()
        {
            const string nonAlphanumericChars = "!@#$%^&*()_+";
            return nonAlphanumericChars[Random.Next(0, nonAlphanumericChars.Length - 1)];
        }
    }
}
