using System;

namespace AsgardWebEngine.Business.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Safely represents a string as a <seealso cref="Uri"/>.
        /// </summary>
        /// <param name="text">The string representation of a uri.</param>
        /// <returns></returns>
        public static Uri ToUri(this string text)
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                return new Uri(text);
            }

            return null;
        }
    }
}
