using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using AsgardWebEngine.Common;
using Amazon.Services;
using System.Net;
using Amazon.Services.ECS;
using Microsoft.WindowsAzure;
using System.Configuration;
using Amazon.Services.Extensions;
using AsgardWebEngine.Business.Extensions;
using AsgardWebEngine.Common.Interfaces;
using CloudStorageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount;
using AsgardWebEngine.Business;
using AsgardWebEngine.Business.Models;

namespace AsgardWebEngine.WebJob.Amazon
{
    /// <summary>
    /// The starting point for this webjob.
    /// <remarks>
    /// To learn more about Microsoft Azure WebJobs, please see http://go.microsoft.com/fwlink/?LinkID=401557
    /// </remarks>
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// <remarks>
        /// Please set the following connectionstring values in app.config
        /// AzureJobsRuntime and AzureJobsData
        /// </remarks>
        /// </summary>
        public static void Main()
        {
            var jobHost = new JobHost();
            jobHost.RunAndBlock();
        }

        /// <summary>
        /// Processes the queue message.
        /// </summary>
        /// <param name="asinList">The asin list.</param>
        public static void ProcessQueueMessage([QueueTrigger("amazonqueue")] IList<string> asinList)
        {
            Args.IsNotNull(() => asinList);

            var itemsQuery = EcsLookup.GetItemsFromAsinList(asinList);
            var items = itemsQuery.FirstOrDefault();

            if (items != null)
            {
                var objectFactory = new ObjectFactory<Post, Guid>();
                var wishListEditCollection = objectFactory .Fetch(asinList);

                foreach (var item in items.Item)
                {
                    var wishListEdit = wishListEditCollection
                        .Where(we => we.Identifier == item.ASIN)
                        .FirstOrDefault();

                    UploadImageToAzure(item, wishListEdit);

                    wishListEdit.Identifier = item.ASIN;
                    wishListEdit.Name = item.ItemAttributes.Title;
                    wishListEdit.ImageUrl = item.MediumImage.URL.ToUri();
                    wishListEdit.Category = item.ItemAttributes.Binding;
                    wishListEdit.SiteUrl = item.DetailPageURL.ToUri();
                    wishListEdit.Description = item.ItemAttributes.Feature.ExplodeList();
                    wishListEdit.Price = item.GetPrice();
                    wishListEdit.SiteName = "Amazon";
                    wishListEdit.SiteUrl = new Uri("http://www.amazon.com/");
                }

                wishListEditCollection.Save();
            }
        }

        private static void UploadImageToAzure(Item item, AmazonWishList amazonWishList)
        {
            if (amazonWishList.ImageUrl.OriginalString != item.MediumImage.URL)
            {
                using (var webClient = new WebClient())
                {
                    var bytes = webClient.DownloadData(item.MediumImage.URL);
                    var cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                    var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                    var cloudBlobContainer = cloudBlobClient.GetContainerReference(ConfigurationManager.AppSettings["CloudContainerName"]);
                    var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(amazonWishList.ImageFileName);
                    cloudBlockBlob.UploadFromByteArray(bytes, 0, bytes.Length);
                }
            }
        }
    }
}