using Newtonsoft.Json;

namespace CVNetCore.Models
{
    public class CVCredit
    {
        #region Properties

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        #endregion
    }
}