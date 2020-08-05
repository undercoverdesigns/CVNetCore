using System.Collections.Generic;
using CVNetCore.Constants;
using CVNetCore.Models;

namespace CVNetCore
{
    public class ComicVine
    {
        #region Fields

        private readonly string _apiKey;
        private readonly string _comicVineAddress;
        private string _searchAddress;

        #endregion

        #region Constructors

        public ComicVine(string apiKey, string baseAddress = null)
        {
            _apiKey = apiKey;
            _comicVineAddress = string.IsNullOrWhiteSpace(baseAddress) ? Strings.COMIC_VINE_API_ADDRESS : baseAddress;
            _searchAddress = $"{_comicVineAddress}{Strings.COMIC_VINE_SEARCH_CONTROLLER}";
        }

        #endregion

        #region Methods

        public Issue GetIssue(int issueId)
        {
            string query = null;

            query = $"{_comicVineAddress}issue/4000-{issueId}/?api_key={_apiKey}&format=json";

            IssueQuery issueQuery = Connection.ConnectAndRequestIssue(query);

            return issueQuery.Issue;
        }

        public Issue GetIssue(int volumeId, int issueNumber)
        {
            string query =
                $"{_comicVineAddress}issues/?api_key={_apiKey}&format=json&filter=issue_number:{issueNumber},volume:{volumeId}";

            IssueQuery issueQuery = Connection.ConnectAndRequestIssue(query);

            return issueQuery.Issue;
        }

        public List<Issue> GetIssuesByVolume(int volumeId)
        {
            string query = $"{_comicVineAddress}volume/4050-{volumeId}/?api_key={_apiKey}&format=json";

            VolumeQuery volumeQuery = Connection.ConnectAndRequestIssuesByVolume(query);

            return volumeQuery.Volume.Issues as List<Issue>;
        }

        public Volume GetVolumeDetails(int volumeId)
        {
            string query = $"{_comicVineAddress}volume/4050-{volumeId}/?api_key={_apiKey}&format=json";

            VolumeQuery volumeQuery = Connection.ConnectAndRequestIssuesByVolume(query);

            return volumeQuery.Volume;
        }

        public List<Volume> GetVolumesByName(string volumeName)
        {
            List<Volume> result = new List<Volume>();

            int offset = 0;
            int resultsThisIteration = 0;

            do
            {
                string query =
                    $"{_comicVineAddress}volumes/?api_key={_apiKey}&format=json&filter=name:{volumeName}&offset={offset}";

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

        #endregion
    }
}