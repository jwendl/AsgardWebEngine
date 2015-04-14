using AsgardWebEngine.Business.Interfaces;

namespace AsgardWebEngine.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Quote
        : IBusinessObject
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }
    }
}
