using System.Collections.Generic;
using System.Linq;
using CVNetCore.Models;
using CVNetCore.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CVNetCore.Json
{
    public static class JsonReadVolume
    {
        #region Methods

        public static Volume GetVolume(string jsonData)
        {
            Volume volume = new Volume();

            JObject jObject = JObject.Parse(jsonData);

            volume.ApiDetailUrl = jObject["results"]?["api_detail_url"]?.ToString();

            volume.CountOfIssues = StringUtilities.TryToParse(jObject["results"]?["count_of_issues"]?.ToString());

            volume.Description = jObject["results"]?["description"]?.ToString();

            volume.Id = StringUtilities.TryToParse(jObject["results"]?["id"]?.ToString());

            volume.Name = jObject["results"]?["name"]?.ToString();

            volume.StartYear = StringUtilities.TryToParse(jObject["results"]?["start_year"]?.ToString());

            if (!string.IsNullOrEmpty(jObject["results"]?["image"]?.ToString()))
            {
                volume.Image = JsonConvert.DeserializeObject<Image>(jObject["results"]["image"].ToString());
            }

            List<JToken> comicVineIssueList = jObject["results"]?["issues"]?.Children().ToList();

            if (comicVineIssueList != null)
            {
                foreach (JToken issues in comicVineIssueList)
                {
                    volume.Issues.Add(JsonConvert.DeserializeObject<Issue>(issues.ToString()));
                }
            }

            volume.Publisher =
                JsonConvert.DeserializeObject<Publisher>(jObject["results"]?["publisher"]?.ToString()!);

            return volume;
        }

        #endregion
    }
}