
namespace AsgardWebEngine.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAmazonWishList
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        string Category { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the name of the site.
        /// </summary>
        /// <value>
        /// The name of the site.
        /// </value>
        string SiteName { get; set; }

        /// <summary>
        /// Gets or sets the site URL.
        /// </summary>
        /// <value>
        /// The site URL.
        /// </value>
        string SiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the site URL.
        /// </summary>
        /// <value>
        /// The site URL.
        /// </value>
        string ItemUrl { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
    }
}
