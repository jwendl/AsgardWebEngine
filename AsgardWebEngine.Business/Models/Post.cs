﻿using AsgardWebEngine.Framework.Models;
using System;

namespace AsgardWebEngine.Business.Models
{
    /// <summary>
    /// A business object that represents a Post object
    /// </summary>
    public class Post
        : BaseBusinessObject
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double? Rating { get; set; }

        /// <summary>
        /// Gets or sets the raters.
        /// </summary>
        /// <value>
        /// The raters.
        /// </value>
        public int Raters { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is published.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable comments].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable comments]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableComments { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the excerpt.
        /// </summary>
        /// <value>
        /// The excerpt.
        /// </value>
        public string Excerpt { get; set; }

        /// <summary>
        /// Gets or sets the post slug.
        /// </summary>
        /// <value>
        /// The post slug.
        /// </value>
        public string PostSlug { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}
