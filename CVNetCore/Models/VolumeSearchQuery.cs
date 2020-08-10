using System.Collections.Generic;
using Newtonsoft.Json;

namespace CVNetCore.Models
{
    // https://comicvine.gamespot.com/api/volumes/?api_key=API_KEY&filter=name:Avengers&resources=volume&format=json&offset=0
    // VolumeQuery myDeserializedClass = JsonConvert.DeserializeObject<VolumeQuery>(myJsonResponse);

    public class VolumeSearchQuery
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
        public IList<CVVolume> Results { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        #endregion
    }
}