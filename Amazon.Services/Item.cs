using Amazon.Services.Extensions;

namespace Amazon.Services.ECS
{
    public partial class Item
    {
        /// <summary>
        /// The title of the <seealso cref="Item"/>.
        /// </summary>
        public string Title { get { return ItemAttributes.Title; } }

        /// <summary>
        /// The description of the <seealso cref="Item"/>.
        /// </summary>
        public string Description { get { return ItemAttributes.Feature.ExplodeList(); } }
    }
}
