using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Amazon.Services
{
    /// <summary>
    /// A class to handle the signing endpoint for the amazon service.
    /// </summary>
    public class AmazonSigningEndpointBehavior
        : IEndpointBehavior
    {
        private string accessKeyId = "";
        private string secretKey = "";

        /// <summary>
        /// The public constructor for this class.
        /// </summary>
        /// <param name="accessKeyId">Your amazon access key id.</param>
        /// <param name="secretKey">Your amazon secret key.</param>
        public AmazonSigningEndpointBehavior(string accessKeyId, string secretKey)
        {
            this.accessKeyId = accessKeyId;
            this.secretKey = secretKey;
        }

        /// <summary>
        /// Applies the client behavior to the request.
        /// </summary>
        /// <param name="endpoint">The <seealso cref="ServiceEndpoint"/> object.</param>
        /// <param name="clientRuntime">The <seealso cref="ClientRuntime"/> object.</param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            if (clientRuntime != null)
            {
                clientRuntime.MessageInspectors.Add(new AmazonSigningMessageInspector(this.accessKeyId, this.secretKey));
            }
        }

        /// <summary>
        /// Overrides functionality for ApplyDispatchBehavior.
        /// </summary>
        /// <param name="endpoint">The <seealso cref="ServiceEndpoint"/> object.</param>
        /// <param name="endpointDispatcher">The <seealso cref="EndpointDispatcher"/> object.</param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { return; }

        /// <summary>
        /// Overrides functionality for the Validate function.
        /// </summary>
        /// <param name="endpoint">The <seealso cref="ServiceEndpoint"/> object.</param>
        public void Validate(ServiceEndpoint endpoint) { return; }

        /// <summary>
        /// Overrides functionality for the AddBindingParameters function.
        /// </summary>
        /// <param name="endpoint">The <seealso cref="ServiceEndpoint"/> object.</param>
        /// <param name="bindingParameters">The <seealso cref="BindingParameterCollection"/> object.</param>
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { return; }
    }
}
