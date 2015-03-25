using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Amazon.Services.ECS;

namespace Amazon.Services.Extensions
{
    /// <summary>
    /// Extensions that operate on the <seealso cref="Item"/> object.
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// This gets a currency value based on an <seealso cref="Item"/> object.
        /// </summary>
        /// <param name="item">The <seealso cref="Item"/> object that you wish to get the price value from.</param>
        /// <returns>A <seealso cref="Decimal"/> object that returns the value.</returns>
        public static decimal GetPrice(this Item item)
        {
            var outputPrice = 0M;

            if (item != null)
            {
                var price = item.ItemAttributes.ListPrice;
                if (price == null)
                {
                    price = item.OfferSummary.LowestNewPrice;
                }

                if (price == null)
                {
                    price = item.OfferSummary.LowestUsedPrice;
                }

                if (price != null)
                {
                    if (!Decimal.TryParse(price.FormattedPrice.Replace("$", String.Empty), out outputPrice))
                    {
                        outputPrice = 0M;
                    }
                }
            }

            return outputPrice;
        }

        /// <summary>
        /// Takes an enumerable and returns it in a sentence format.
        /// </summary>
        /// <param name="stringArray">The enumerable object list.</param>
        /// <returns>A paragraph form of the description.</returns>
        public static string ExplodeList(this IEnumerable<string> stringArray)
        {
            var stringBuilder = new StringBuilder();
            if (stringArray != null)
            {
                foreach (var item in stringArray)
                {
                    stringBuilder.AppendLine(String.Format(CultureInfo.CurrentCulture, "{0}. ", item));
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Returns the creator of the amazon object.
        /// </summary>
        /// <param name="itemAttributes">The <seealso cref="ItemAttributes"/> object.</param>
        /// <returns>The creator of the amazon object.</returns>
        public static string GetCreator(this ItemAttributes itemAttributes)
        {
            if (itemAttributes != null)
            {
                if (!String.IsNullOrEmpty(GetSafeFirstValue(itemAttributes.Author)))
                {
                    return GetSafeFirstValue(itemAttributes.Author);
                }

                if (!String.IsNullOrEmpty(GetSafeFirstValue(itemAttributes.Artist)))
                {
                    return GetSafeFirstValue(itemAttributes.Artist);
                }

                if (!String.IsNullOrEmpty(itemAttributes.Publisher))
                {
                    return itemAttributes.Publisher;
                }
            }

            return String.Empty;
        }

        private static string GetSafeFirstValue(string[] array)
        {
            if (array != null)
            {
                return array.FirstOrDefault();
            }

            return String.Empty;
        }
    }
}
