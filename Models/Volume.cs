using System.Collections.Generic;
using Newtonsoft.Json;

namespace CVNetCore.Models
{
    public class Volume
    {
        #region Properties

        [JsonProperty("aliases")]
        public object Aliases { get; set; }

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("count_of_issues")]
        public int CountOfIssues { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("first_issue")]
        public FirstIssue FirstIssue { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("last_issue")]
        public LastIssue LastIssue { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("start_year")]
        public string StartYear { get; set; }
        
        [JsonProperty("characters")]
        public IList<CharacterCredit> Characters { get; set; }

        [JsonProperty("concepts")]
        public IList<ConceptCredit> Concepts { get; set; }

        [JsonProperty("issues")]
        public IList<Issue> Issues { get; set; }

        [JsonProperty("locations")]
        public IList<LocationCredit> Locations { get; set; }

        [JsonProperty("objects")]
        public IList<Credit> Objects { get; set; }

        [JsonProperty("people")]
        public IList<PersonCredit> People { get; set; }

        #endregion
    }
}