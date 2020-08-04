using Newtonsoft.Json;

namespace CVNetCore.Models
{
    // https://comicvine.gamespot.com/api/volume/4050-77405/?api_key=API_KEY&format=json
    // IssuesByVolumeQuery myDeserializedClass = JsonConvert.DeserializeObject<IssuesByVolumeQuery>(myJsonResponse);
    
    public class IssuesByVolumeQuery
    {
        #region Properties

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("number_of_page_results")]
        public int NumberOfPageResults { get; set; }

        [JsonProperty("number_of_total_results")]
        public int NumberOfTotalResults { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("results")]
        public Volume Volume { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        #endregion
    }
}