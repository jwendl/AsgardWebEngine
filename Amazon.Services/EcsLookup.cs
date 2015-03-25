using Amazon.Services.ECS;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;

namespace Amazon.Services
{
    /// <summary>
    /// Wrapper class to expose the functionality of an ECS lookup.
    /// </summary>
    public static class EcsLookup
    {
        /// <summary>
        /// Gets a list of <seealso cref="Items"/> objects based on a list of ASIN strings.
        /// </summary>
        /// <param name="asinList">The list of ASIN strings.</param>
        /// <returns>A list of <seealso cref="Items"/> </returns>
        public static IEnumerable<Items> GetItemsFromAsinList(IList<string> asinList)
        {
            var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;

            var associateUrl = ConfigurationManager.AppSettings["AssociateUrl"];
            var accessKeyId = ConfigurationManager.AppSettings["AccessKeyId"];
            var associateSecret = ConfigurationManager.AppSettings["AssociateSecret"];
            var associateTag = ConfigurationManager.AppSettings["AssociateTag"];

            using (var awseCommerceServicePortTypeClient = new AWSECommerceServicePortTypeClient(basicHttpBinding, new EndpointAddress(associateUrl)))
            {
                var amazonEndpointBehavior = new AmazonSigningEndpointBehavior(accessKeyId, associateSecret);
                awseCommerceServicePortTypeClient.ChannelFactory.Endpoint.Behaviors.Add(amazonEndpointBehavior);

                var itemLookupRequest = new ItemLookupRequest();
                itemLookupRequest.ItemId = asinList.ToArray();
                itemLookupRequest.ResponseGroup = new string[] { "ItemAttributes", "Images", "Offers" };

                var itemLookup = new ItemLookup();
                itemLookup.AssociateTag = associateTag;
                itemLookup.AWSAccessKeyId = accessKeyId;
                itemLookup.Request = new ItemLookupRequest[] { itemLookupRequest };

                var itemLookupResponse = awseCommerceServicePortTypeClient.ItemLookup(itemLookup);
                var itemArray = itemLookupResponse.Items;

                return itemArray.Cast<Items>();
            }
        }
    }
}
