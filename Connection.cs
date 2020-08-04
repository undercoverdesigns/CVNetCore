using System.IO;
using System.Net;
using CVNetCore.Models;
using Newtonsoft.Json;

namespace CVNetCore
{
    internal static class Connection
    {
        #region Methods

        public static IssueQuery ConnectAndRequestIssue(string url)
        {
            IssueQuery result = new IssueQuery();

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            using WebResponse webResponse = httpWebRequest.GetResponse();
            using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()!);
            return JsonConvert.DeserializeObject<IssueQuery>(streamReader.ReadToEnd());
        }

        public static VolumeQuery ConnectAndRequestIssuesByVolume(string url)
        {
            VolumeQuery result = new VolumeQuery();

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            using WebResponse webResponse = httpWebRequest.GetResponse();
            using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()!);
            return JsonConvert.DeserializeObject<VolumeQuery>(streamReader.ReadToEnd());
        }

        public static VolumeSearchQuery ConnectAndRequestVolume(string url)
        {
            VolumeSearchQuery result = new VolumeSearchQuery();

            HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            using WebResponse webResponse = httpWebRequest.GetResponse();
            using StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()!);
            return JsonConvert.DeserializeObject<VolumeSearchQuery>(streamReader.ReadToEnd());
        }

        #endregion
    }
}