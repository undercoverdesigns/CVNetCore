using System.Collections.Generic;
using Newtonsoft.Json;

namespace CVNetCore.Models
{
    public class Issue
    {
        #region Properties

        [JsonProperty("aliases")]
        public object Aliases { get; set; }

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("character_credits")]
        public IList<CharacterCredit> CharacterCredits { get; set; }

        [JsonProperty("character_died_in")]
        public IList<object> CharacterDiedIn { get; set; }

        [JsonProperty("concept_credits")]
        public IList<object> ConceptCredits { get; set; }

        [JsonProperty("cover_date")]
        public string CoverDate { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public object Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("first_appearance_characters")]
        public object FirstAppearanceCharacters { get; set; }

        [JsonProperty("first_appearance_concepts")]
        public object FirstAppearanceConcepts { get; set; }

        [JsonProperty("first_appearance_locations")]
        public object FirstAppearanceLocations { get; set; }

        [JsonProperty("first_appearance_objects")]
        public object FirstAppearanceObjects { get; set; }

        [JsonProperty("first_appearance_storyarcs")]
        public object FirstAppearanceStoryarcs { get; set; }

        [JsonProperty("first_appearance_teams")]
        public object FirstAppearanceTeams { get; set; }

        [JsonProperty("has_staff_review")]
        public HasStaffReview HasStaffReview { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("issue_number")]
        public string IssueNumber { get; set; }

        [JsonProperty("location_credits")]
        public IList<LocationCredit> LocationCredits { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("object_credits")]
        public IList<object> ObjectCredits { get; set; }

        [JsonProperty("person_credits")]
        public IList<PersonCredit> PersonCredits { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("store_date")]
        public string StoreDate { get; set; }

        [JsonProperty("story_arc_credits")]
        public IList<object> StoryArcCredits { get; set; }

        [JsonProperty("team_credits")]
        public IList<object> TeamCredits { get; set; }

        [JsonProperty("team_disbanded_in")]
        public IList<object> TeamDisbandedIn { get; set; }

        [JsonProperty("volume")]
        public Volume Volume { get; set; }

        #endregion
    }
}