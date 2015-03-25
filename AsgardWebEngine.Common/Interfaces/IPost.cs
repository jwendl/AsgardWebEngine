using System;

namespace AsgardWebEngine.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPost
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        string Category { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        double? Rating { get; set; }

        /// <summary>
        /// Gets or sets the raters.
        /// </summary>
        /// <value>
        /// The raters.
        /// </value>
        int Raters { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime DateModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable comments].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable comments]; otherwise, <c>false</c>.
        /// </value>
        bool EnableComments { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the excerpt.
        /// </summary>
        /// <value>
        /// The excerpt.
        /// </value>
        string Excerpt { get; set; }

        /// <summary>
        /// Gets or sets the post slug.
        /// </summary>
        /// <value>
        /// The post slug.
        /// </value>
        string PostSlug { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        string Content { get; set; }
    }
}
