#nullable enable
using System.Collections.Generic;
using CVNetCore.Utility;
using Newtonsoft.Json;

namespace CVNetCore.Models
{
    public class Issue
    {
        #region Fields

        public int IssueMonth => StringUtilities.ExtractMonth(CoverDate);
        public int IssueYear  => StringUtilities.ExtractYear(CoverDate);

        #endregion

        #region Properties

        [JsonProperty("aliases")]
        public IList<CVCredit>? Aliases { get; set; }

        [JsonProperty("api_detail_url")]
        public string? ApiDetailUrl { get; set; }

        [JsonProperty("character_credits")]
        public IList<CVCredit>? CharacterCredits { get; set; }

        [JsonProperty("character_died_in")]
        public IList<CVCredit>? CharacterDiedIn { get; set; }

        [JsonProperty("concept_credits")]
        public IList<CVCredit>? ConceptCredits { get; set; }
        
        [JsonProperty("cover_date")]
        public string? CoverDate { get; set; }

        [JsonProperty("date_added")]
        public string? DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string? DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public string? Deck { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("first_appearance_characters")]
        public IList<CVCredit>? FirstAppearanceCharacters { get; set; }

        [JsonProperty("first_appearance_concepts")]
        public IList<CVCredit>? FirstAppearanceConcepts { get; set; }

        [JsonProperty("first_appearance_locations")]
        public IList<CVCredit>? FirstAppearanceLocations { get; set; }

        [JsonProperty("first_appearance_objects")]
        public IList<CVCredit>? FirstAppearanceObjects { get; set; }

        [JsonProperty("first_appearance_storyarcs")]
        public IList<CVCredit>? FirstAppearanceStoryarcs { get; set; }

        [JsonProperty("first_appearance_teams")]
        public IList<CVCredit>? FirstAppearanceTeams { get; set; }

        // [JsonProperty("has_staff_review")]
        // public HasStaffReview? HasStaffReview { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("image")]
        public CVImage? Image { get; set; }

        [JsonProperty("issue_number")]
        public float IssueNumber { get; set; }

        [JsonProperty("location_credits")]
        public IList<CVCredit>? LocationCredits { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("object_credits")]
        public IList<CVCredit>? ObjectCredits { get; set; }

        [JsonProperty("person_credits")]
        public IList<CVCredit>? PersonCredits { get; set; }

        [JsonProperty("site_detail_url")]
        public string? SiteDetailUrl { get; set; }

        [JsonProperty("store_date")]
        public string? StoreDate { get; set; }

        [JsonProperty("story_arc_credits")]
        public IList<CVCredit>? StoryArcCredits { get; set; }

        [JsonProperty("team_credits")]
        public IList<CVCredit>? TeamCredits { get; set; }

        [JsonProperty("team_disbanded_in")]
        public IList<CVCredit>? TeamDisbandedIn { get; set; }

        [JsonProperty("volume")]
        public CVVolume? Volume { get; set; }

        #endregion
    }
}