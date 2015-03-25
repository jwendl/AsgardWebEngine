using AsgardWebEngine.Common;
using AsgardWebEngine.WebJob.Steam.Models;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using TinySteamWrapper;

namespace AsgardWebEngine.WebJob.Steam
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
        /// <param name="appIdList">The asin list.</param>
        public static async Task ProcessQueueMessage([QueueTrigger("SteamQueue")] IList<int> appIdList)
        {
            Args.IsNotNull(() => appIdList);

            var userName = ConfigurationManager.AppSettings["SteamUserName"];
            SteamManager.SteamAPIKey = ConfigurationManager.AppSettings["SteamApiKey"];

            var steamId = await SteamManager.GetSteamIDByName(userName);
            if (steamId != 0)
            {
                var profile = await SteamManager.GetSteamProfileByID(steamId);
                if (profile != null)
                {
                    await SteamManager.LoadGamesForProfile(profile);
                }
            }
        }

        private static async Task<IList<SteamGame>> GetWishListGameInformation(IList<int> appIds)
        {
            using (var webClient = new WebClient())
            {
                var appIdString = String.Join(",", appIds);
                var urlString = ConfigurationManager.AppSettings["SteamStoreBaseUri"] + "api/appdetails?appids={0}";
                var gameUri = new Uri(String.Format(urlString, appIdString));
                var jsonGameString = await webClient.DownloadStringTaskAsync(gameUri);
                jsonGameString = jsonGameString.Replace("[]", "{}");
                jsonGameString = jsonGameString.Replace("\"package_groups\":{}", "\"package_groups\":[]");

                var steamGames = new List<SteamGame>();
                var jsonSteamGames = JsonConvert.DeserializeObject<JsonSteamGame>(jsonGameString);
                foreach (var jsonSteamGame in jsonSteamGames)
                {
                    steamGames.Add(new SteamGame(jsonSteamGame.Value.data));
                }

                //var dlcAppIds = String.Join(",", jsonSteamGame[appId].data.dlc);

                //var dlcUri = new Uri(String.Format(urlString, dlcAppIds));
                //var jsonDlcString = await webClient.DownloadStringTaskAsync(dlcUri);
                //jsonDlcString = jsonDlcString.Replace("[]", "{}");
                //jsonDlcString = jsonDlcString.Replace("\"package_groups\":{}", "\"package_groups\":[]");

                //var jsonDlcList = JsonConvert.DeserializeObject<JsonSteamGame>(jsonDlcString);
                //var gameInformation = jsonSteamGame.First().Value;
                //var steamGame = new SteamGame(gameInformation.data);
                //foreach (var downloadableContent in jsonDlcList)
                //{
                //    steamGame.DownloadableContent.Add(new SteamGame(downloadableContent.Value.data));
                //}

                return steamGames;
            }
        }
    }
}