using System.IO;
using System.Net;
using CVNetCore.Models;
using Newtonsoft.Json;

namespace CVNetCore
{
    internal static class Connection
    {
        #region Methods

        private static string Sanitize(string contents)
        {
            string result = contents;

            result = result.Replace(@"\u00bc", "0.25");
            result = result.Replace(@"\u00bd", "0.5");
            result = result.Replace(@"\u00b3", "0.75");

            return result;
        }

        /// <summary>
        ///     Connect to the ComicVine API and retrieve the results of a query based on an Issue
        /// </summary>
        /// <param name="url">URL to the Issue object within the API</param>
        /// <returns>IssueQuery object populated with search results</returns>
        public static IssueQuery ConnectAndRequestIssue(string url)
        {
            IssueQuery result = new IssueQuery();

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            using WebResponse webResponse = httpWebRequest.GetResponse();
            using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()!);
            return JsonConvert.DeserializeObject<IssueQuery>(Sanitize(streamReader.ReadToEnd()));
        }

        /// <summary>
        ///     Connect to the ComicVine API and retrieve the details for a Volume
        /// </summary>
        /// <param name="url">URL to the Volume object within the API</param>
        /// <returns>VolumeQuery object populated with details of Volume</returns>
        public static VolumeQuery ConnectAndRequestVolumeDetails(string url)
        {
            VolumeQuery result = new VolumeQuery();

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            using WebResponse webResponse = httpWebRequest.GetResponse();
            using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()!);
            return JsonConvert.DeserializeObject<VolumeQuery>(Sanitize(streamReader.ReadToEnd()));
        }

        /// <summary>
        ///     Connect to the ComicVine API and retrieve a list of Volume object
        /// </summary>
        /// <param name="url">URL to the Volume search within the API</param>
        /// <returns>VolumeSearchQuery object populated with Volumes matching a given query</returns>
        public static VolumeSearchQuery ConnectAndRequestVolumeSearch(string url)
        {
            VolumeSearchQuery result = new VolumeSearchQuery();

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            using WebResponse webResponse = httpWebRequest.GetResponse();
            using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()!);
            return JsonConvert.DeserializeObject<VolumeSearchQuery>(Sanitize(streamReader.ReadToEnd()));
        }

        #endregion
    }
}