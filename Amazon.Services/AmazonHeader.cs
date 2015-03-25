using System.ServiceModel.Channels;
using System.Xml;

namespace Amazon.Services
{
    /// <summary>
    /// A <seealso cref="MessageHeader"/> object that can be used to help with the security information.
    /// </summary>
    public class AmazonHeader
        : MessageHeader
    {
        private string name;
        private string value;

        /// <summary>
        /// The public constructor for this object.
        /// </summary>
        /// <param name="name">The name of the header item.</param>
        /// <param name="value">The value of the header item.</param>
        public AmazonHeader(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        /// <summary>
        /// Overrides the functionality to write the header contents.
        /// </summary>
        /// <param name="writer">The <seealso cref="XmlDictionaryWriter"/> object to populate the header information.</param>
        /// <param name="messageVersion"></param>
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            if (writer != null)
            {
                writer.WriteString(this.value);
            }
        }

        /// <summary>
        /// Gets or sets the name of this object.
        /// </summary>
        public override string Name { get { return this.name; } }

        /// <summary>
        /// Gets or sets the name of this object.
        /// </summary>
        public override string Namespace { get { return "http://security.amazonaws.com/doc/2007-01-01/"; } }
    }
}
