using AsgardWebEngine.Common;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace AsgardWebEngine.WebJob.Steam.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SteamGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SteamGame"/> class.
        /// </summary>
        public SteamGame()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SteamGame"/> class.
        /// </summary>
        /// <param name="gameData">The game data.</param>
        public SteamGame(Data gameData)
        {
            Args.IsNotNull(() => gameData);

            Id = gameData.steam_appid;
            Name = gameData.name;
            Website = gameData.website;
            ImageLink = gameData.header_image;

            var priceOverview = gameData.price_overview;
            if (priceOverview != null)
            {
                Pricing = new PriceInformation()
                {
                    Final = FormatCurrency(priceOverview.final, priceOverview.currency),
                    Initial = FormatCurrency(priceOverview.initial, priceOverview.currency),
                    Discount = Convert.ToString(priceOverview.discount_percent, CultureInfo.CurrentCulture),
                };
            }

            DownloadableContent = new List<SteamGame>();
        }

        // Based on http://stackoverflow.com/questions/13364984/format-decimal-as-currency-based-on-currency-code
        private static string FormatCurrency(int value, string countryCode)
        {
            var symbols = GetCurrencySymbols();
            var decimalValue = (decimal)value / 100;
            return String.Format(CultureInfo.CurrentCulture, "{0}{1:0.00}", symbols[countryCode], decimalValue);
        }

        private static IDictionary<string, string> GetCurrencySymbols()
        {
            var result = new Dictionary<string, string>();
            var cultureStrings = new List<string>() { "en-US" };
            foreach (var cultureString in cultureStrings)
            {
                var cultureInfo = new CultureInfo(cultureString);
                var regionInfo = new RegionInfo(cultureInfo.Name);
                result[regionInfo.ISOCurrencySymbol] = regionInfo.CurrencySymbol;
            }

            return result;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the image link.
        /// </summary>
        /// <value>
        /// The image link.
        /// </value>
        public string ImageLink { get; set; }

        /// <summary>
        /// Gets or sets the pricing.
        /// </summary>
        /// <value>
        /// The pricing.
        /// </value>
        public PriceInformation Pricing { get; set; }

        /// <summary>
        /// Gets or sets the content of the downloadable.
        /// </summary>
        /// <value>
        /// The content of the downloadable.
        /// </value>
        public IList<SteamGame> DownloadableContent { get; private set; }
    }
}