using System.Collections.Generic;
using Newtonsoft.Json;

namespace CVNetCore.Models
{
    public class Issue
    {
        #region Fields

        public int issueMonth;
        public int issueDay;
        public int issueYear;

        #endregion

        #region Properties

        [JsonProperty("aliases")]
        public IList<Credit> Aliases { get; set; }

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("character_credits")]
        public IList<Credit> CharacterCredits { get; set; }

        [JsonProperty("character_died_in")]
        public IList<Credit> CharacterDiedIn { get; set; }

        [JsonProperty("concept_credits")]
        public IList<Credit> ConceptCredits { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("first_appearance_characters")]
        public IList<Credit> FirstAppearanceCharacters { get; set; }

        [JsonProperty("first_appearance_concepts")]
        public IList<Credit> FirstAppearanceConcepts { get; set; }

        [JsonProperty("first_appearance_locations")]
        public IList<Credit> FirstAppearanceLocations { get; set; }

        [JsonProperty("first_appearance_objects")]
        public IList<Credit> FirstAppearanceObjects { get; set; }

        [JsonProperty("first_appearance_storyarcs")]
        public IList<Credit> FirstAppearanceStoryarcs { get; set; }

        [JsonProperty("first_appearance_teams")]
        public IList<Credit> FirstAppearanceTeams { get; set; }

        [JsonProperty("has_staff_review")]
        public HasStaffReview HasStaffReview { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("issue_number")]
        public float IssueNumber { get; set; }

        [JsonProperty("location_credits")]
        public IList<Credit> LocationCredits { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("object_credits")]
        public IList<Credit> ObjectCredits { get; set; }

        [JsonProperty("person_credits")]
        public IList<Credit> PersonCredits { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("store_date")]
        public string StoreDate { get; set; }

        [JsonProperty("story_arc_credits")]
        public IList<Credit> StoryArcCredits { get; set; }

        [JsonProperty("team_credits")]
        public IList<Credit> TeamCredits { get; set; }

        [JsonProperty("team_disbanded_in")]
        public IList<Credit> TeamDisbandedIn { get; set; }

        [JsonProperty("volume")]
        public Volume Volume { get; set; }

        #endregion
    }
}