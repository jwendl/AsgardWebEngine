using System;
using System.Globalization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;

namespace Amazon.Services
{
    /// <summary>
    /// The amazon signing message inspector.
    /// </summary>
    public class AmazonSigningMessageInspector
        : IClientMessageInspector
    {
        private string accessKeyId = "";
        private string secretKeyId = "";

        /// <summary>
        /// The public constructor of this object.
        /// </summary>
        /// <param name="accessKeyId">Your amazon access key id.</param>
        /// <param name="secretKey">Your amazon secret key.</param>
        public AmazonSigningMessageInspector(string accessKeyId, string secretKey)
        {
            this.accessKeyId = accessKeyId;
            this.secretKeyId = secretKey;
        }

        /// <summary>
        /// The event that fires before the send request.
        /// </summary>
        /// <param name="request">The <seealso cref="Message"/> object that is part of the request.</param>
        /// <param name="channel">The <seealso cref="IClientChannel"/> instance to get the channel.</param>
        /// <returns>An object that describes the request.</returns>
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (request != null)
            {
                // prepare the data to sign
                var operation = Regex.Match(request.Headers.Action, "[^/]+$").ToString();
                var now = DateTime.UtcNow;
                var timestamp = now.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.CurrentCulture);
                var signMe = operation + timestamp;
                var bytesToSign = Encoding.UTF8.GetBytes(signMe);

                // sign the data
                var secretKeyBytes = Encoding.UTF8.GetBytes(secretKeyId);
                using (var hmacSha256 = new HMACSHA256(secretKeyBytes))
                {
                    var hashBytes = hmacSha256.ComputeHash(bytesToSign);
                    var signature = Convert.ToBase64String(hashBytes);

                    // add the signature information to the request headers
                    request.Headers.Add(new AmazonHeader("AWSAccessKeyId", accessKeyId));
                    request.Headers.Add(new AmazonHeader("Timestamp", timestamp));
                    request.Headers.Add(new AmazonHeader("Signature", signature));
                }
            }

            return null;
        }

        /// <summary>
        /// Overrides the functionality after the service recieves the reply.
        /// </summary>
        /// <param name="reply">The <seealso cref="Message"/> object that represents the reply.</param>
        /// <param name="correlationState">An object that represents the correlation state.</param>
        public void AfterReceiveReply(ref Message reply, object correlationState) { }
    }
}
