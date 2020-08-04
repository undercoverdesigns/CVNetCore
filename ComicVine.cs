using System.Collections.Generic;
using CVNetCore.Constants;
using CVNetCore.Models;

namespace CVNetCore
{
    public class ComicVine
    {
        #region Properties

        public string ApiKey { get; set; }

        public string SearchAddress { get; private set; }

        public string ComicVineAddress { get; private set; }

        #endregion

        #region Constructors

        public ComicVine(string baseAddress = null)
        {
            Initialize(baseAddress);
        }

        #endregion

        #region Methods

        private void Initialize(string baseAddress = null)
        {
            ComicVineAddress = string.IsNullOrWhiteSpace(baseAddress) ? Strings.COMIC_VINE_API_ADDRESS : baseAddress;

            SearchAddress = $"{ComicVineAddress}{Strings.COMIC_VINE_SEARCH_CONTROLLER}";
        }

        public List<Volume> GetVolumesByName(string volumeName)
        {
            List<Volume> result = new List<Volume>();

            int offset = 0;
            int resultsThisIteration = 0;

            do
            {
                string query =
                    $"{ComicVineAddress}volumes/?api_key={ApiKey}&format=json&filter=name:{volumeName}&offset={offset}";

                VolumeSearchQuery searchQueryResult = Connection.ConnectAndRequestVolume(query);

                if (searchQueryResult.StatusCode != 1)
                {
                    continue;
                }

                result.AddRange(searchQueryResult.Results);

                resultsThisIteration = searchQueryResult.NumberOfPageResults;
                offset += searchQueryResult.NumberOfPageResults;
            } while (resultsThisIteration == Integers.RESULTS_PER_PAGE);

            return result;
        }

        public Issue GetIssue(int issueId)
        {
            string query = null;

            query = $"{ComicVineAddress}issue/4000-{issueId}/?api_key={ApiKey}&format=json";

            IssueQuery issueQuery = Connection.ConnectAndRequestIssue(query);

            return issueQuery.Issue;
        }

        #endregion

        public Issue GetIssue(int volumeId, int issueNumber)
        {
            string query =
                $"{ComicVineAddress}issues/?api_key={ApiKey}&format=json&filter=issue_number:{issueNumber},volume:{volumeId}";

            IssueQuery issueQuery = Connection.ConnectAndRequestIssue(query);

            return issueQuery.Issue;
        }
        
        public List<Issue> GetIssuesByVolume(int volumeId)
        {
            string query  = $"{ComicVineAddress}volume/4050-{volumeId}/?api_key={ApiKey}&format=json";

            VolumeQuery volumeQuery = Connection.ConnectAndRequestIssuesByVolume(query);

            return volumeQuery.Volume.Issues as List<Issue>;
        }

    }
}