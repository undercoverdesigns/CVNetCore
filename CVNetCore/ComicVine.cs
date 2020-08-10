using System.Collections.Generic;
using System.Web;
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

        /// <summary>
        ///     Retrieves data for a specific Issue
        /// </summary>
        /// <param name="issueId">ID of the Issue to retrieve</param>
        /// <returns>Issue object populated with data for the Issue indicated by the ID</returns>
        public Issue GetIssue(int issueId)
        {
            string query = null;

            query = $"{_comicVineAddress}issue/4000-{issueId}/?api_key={_apiKey}&format=json";

            IssueQuery issueQuery = Connection.ConnectAndRequestIssue(query);

            return issueQuery.Issue;
        }

        /// <summary>
        ///     Retrieves data for a specific Issue
        /// </summary>
        /// <param name="volumeId">ID of the Volume in which the Issue resides</param>
        /// <param name="issueNumber">Number of the Issue for which the retrieval is to be done</param>
        /// <returns>Issue object populated with data for the Issue indicated by the Volume ID and Issue Number</returns>
        public Issue GetIssue(int volumeId, int issueNumber)
        {
            string query =
                $"{_comicVineAddress}issues/?api_key={_apiKey}&format=json&filter=issue_number:{issueNumber},volume:{volumeId}";

            IssueQuery issueQuery = Connection.ConnectAndRequestIssue(query);

            return issueQuery.Issue;
        }

        /// <summary>
        ///     Retrieve a list of Issues contained within a Volume
        /// </summary>
        /// <param name="volumeId">ID of the Volume for which the list of Issues is to be returned</param>
        /// <returns>List containing Issue objects for the given Volume ID</returns>
        public List<Issue> GetIssuesByVolume(int volumeId)
        {
            string query = $"{_comicVineAddress}volume/4050-{volumeId}/?api_key={_apiKey}&format=json";

            VolumeQuery volumeQuery = Connection.ConnectAndRequestVolumeDetails(query);

            return volumeQuery.CvVolume.Issues as List<Issue>;
        }

        /// <summary>
        ///     Retrieve details regarding a Volume
        /// </summary>
        /// <param name="volumeId">ID of the Volume to retrieve</param>
        /// <returns>Volume object populated with details of Volume indicated by the passed ID</returns>
        public CVVolume GetVolumeDetails(int volumeId)
        {
            string query = $"{_comicVineAddress}volume/4050-{volumeId}/?api_key={_apiKey}&format=json";

            VolumeQuery volumeQuery = Connection.ConnectAndRequestVolumeDetails(query);

            return volumeQuery.CvVolume;
        }

        /// <summary>
        ///     Retrieve a list of volumes containing a search term
        /// </summary>
        /// <param name="searchTerm">Term for which to search the Volume set</param>
        /// <returns>List of Volumes containing the search term in their Name field</returns>
        public List<CVVolume> GetVolumesByName(string searchTerm)
        {
            List<CVVolume> result = new List<CVVolume>();

            int offset = 0;
            int resultsThisIteration = 0;

            do
            {
                string query =
                    $"{_comicVineAddress}volumes/?api_key={_apiKey}&format=json&filter=name:{HttpUtility.UrlEncode(searchTerm)}&offset={offset}";

                VolumeSearchQuery searchQueryResult = Connection.ConnectAndRequestVolumeSearch(query);

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