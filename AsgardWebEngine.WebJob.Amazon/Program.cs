using Amazon.Services;
using Amazon.Services.ECS;
using Amazon.Services.Extensions;
using AsgardWebEngine.Business.Extensions;
using AsgardWebEngine.Business.Framework;
using AsgardWebEngine.Business.Interfaces;
using AsgardWebEngine.Business.Models;
using AsgardWebEngine.Common;
using Castle.Windsor;
using Microsoft.Azure;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using CloudStorageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount;

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
            using (var windsorContainer = new WindsorContainer())
            {
                var containerWrapper = new WindsorContainerWrapper(windsorContainer);
                containerWrapper.RegisterAllInstances();

                if (items != null)
                {
                    var amazonWishListCollection = containerWrapper.Resolve<IBusinessObjectCollection<AmazonWishList>>();
                    var wishListEditCollection = amazonWishListCollection.Query(awl => asinList.Contains(awl.Identifier));

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