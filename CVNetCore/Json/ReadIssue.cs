using System.Collections.Generic;
using System.Linq;
using CVNetCore.Models;
using CVNetCore.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CVNetCore.Json
{
    public static class ReadIssue
    {
        #region Methods

        private static Issue Get(JObject jsonObject, bool b)
        {
            Issue issue = new Issue
                {Id = (int) jsonObject["id"], ApiDetailUrl = jsonObject["api_detail_url"]?.ToString()};

            Image image = new Image();

            if (!string.IsNullOrEmpty(jsonObject["image"]?.ToString()))
            {
                image = JsonConvert.DeserializeObject<Image>(jsonObject["image"].ToString());
            }

            issue.Image = image;
            issue.IssueNumber = jsonObject["issue_number"]?.ToString();
            issue.Name = jsonObject["name"]?.ToString();

            string coverDate = jsonObject["cover_date"]?.ToString();

            issue.issueYear = StringUtilities.TryToExtractYear(coverDate);
            issue.issueMonth = StringUtilities.TryToExtractMonth(coverDate);
            issue.Name = jsonObject["name"]?.ToString();

            Volume volume = new Volume();
            if (!string.IsNullOrEmpty(jsonObject["volume"]?.ToString()))
            {
                volume = JsonConvert.DeserializeObject<Volume>(jsonObject["volume"].ToString());
            }

            issue.Volume = volume;

            issue.Aliases = ParseCredits(jsonObject["aliases"]);
            issue.CharacterCredits = ParseCredits(jsonObject["character_credits"]);
            issue.CharacterDiedIn = ParseCredits(jsonObject["character_died_in"]);
            issue.ConceptCredits = ParseCredits(jsonObject["concept_credits"]);
            issue.FirstAppearanceCharacters = ParseCredits(jsonObject["first_appearance_characters"]);
            issue.FirstAppearanceConcepts = ParseCredits(jsonObject["first_appearance_concepts"]);
            issue.FirstAppearanceLocations = ParseCredits(jsonObject["first_appearance_locations"]);
            issue.FirstAppearanceObjects = ParseCredits(jsonObject["first_appearance_objects"]);
            issue.FirstAppearanceStoryarcs = ParseCredits(jsonObject["first_appearance_storyarcs"]);
            issue.FirstAppearanceTeams = ParseCredits(jsonObject["first_appearance_teams"]);
            issue.LocationCredits = ParseCredits(jsonObject["location_credits"]);
            issue.ObjectCredits = ParseCredits(jsonObject["object_credits"]);
            issue.PersonCredits = ParseCredits(jsonObject["person_credits"]);
            issue.StoryArcCredits = ParseCredits(jsonObject["story_arc_credits"]);
            issue.TeamCredits = ParseCredits(jsonObject["team_credits"]);
            issue.TeamDisbandedIn = ParseCredits(jsonObject["team_disbanded_in"]);

            return issue;
        }

        private static List<Credit> ParseCredits(IEnumerable<JToken> credits)
        {
            IList<JToken> jCredits = credits.Children().ToList();
            return jCredits!.Select(credit => JsonConvert.DeserializeObject<Credit>(credit.ToString()))
                .ToList();
        }

        public static Issue GetIssue(string jsonData)
        {
            JObject jObject = JObject.Parse(jsonData);

            string howManyString = jObject["number_of_total_results"]?.ToString();
            bool found = int.TryParse(howManyString, out int howManyNumber);

            return howManyNumber <= 0 ? null : Get((JObject) jObject["results"], true);
        }

        #endregion
    }
}