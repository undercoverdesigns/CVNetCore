using Newtonsoft.Json;

namespace CVNetCore.Models
{
    public class CVLastIssue
    {
        #region Properties

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("issue_number")]
        public float? IssueNumber { get; set; }

        #endregion
    }
}