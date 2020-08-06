#nullable enable
using System.IO;
using System.Reflection;
using CVNetCore.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CVNetCoreTests
{
    [TestFixture]
    public class JsonParsingIssueTests
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _issue = JsonConvert.DeserializeObject<IssueQuery>(GetFileContents("issue.details.json")).Issue;
        }

        #endregion

        private Issue? _issue;

        private static string GetFileContents(string sampleFile)
        {
            using Stream? stream = Assembly.GetExecutingAssembly()?.GetEmbeddedResourceStream(sampleFile);

            if (stream == null)
            {
                return string.Empty;
            }

            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        [Test]
        public void TestParseIssueAliases()
        {
            Assert.AreEqual(null, _issue!.Aliases);
        }

        [Test]
        public void TestParseIssueApiDetailUrl()
        {
            Assert.AreEqual("https://comicvine.gamespot.com/api/issue/4000-467608/", _issue?.ApiDetailUrl);
        }

        [Test]
        public void TestParseIssueCharacterCredits()
        {
            Assert.AreEqual(10, _issue?.CharacterCredits?.Count);
        }

        [Test]
        public void TestParseIssueCharacterDiedIn()
        {
            Assert.AreEqual(0, _issue?.CharacterDiedIn?.Count);
        }

        [Test]
        public void TestParseIssueConceptCredits()
        {
            Assert.AreEqual(0, _issue?.ConceptCredits?.Count);
        }

        [Test]
        public void TestParseIssueDateAdded()
        {
            Assert.AreEqual("2014-10-06 20:58:41", _issue?.DateAdded);
        }

        [Test]
        public void TestParseIssueDateLastUpdated()
        {
            Assert.AreEqual("2016-03-27 10:18:12", _issue?.DateLastUpdated);
        }

        [Test]
        public void TestParseIssueDeck()
        {
            Assert.AreEqual(null, _issue?.Deck);
        }

        [Test]
        public void TestParseIssueDescription()
        {
            Assert.AreEqual(
                "<p><em>For the Rhodes family, losing their son was the most devastating thing that could've ever occurred\u2026 but it couldn't prepare them for what happened when he returned. Skybound's newest original series turns fantasy into reality in this EXTRA-SIZED FIRST ISSUE for just $2.99, by creator/writer JOSH WILLIAMSON (GHOSTED, NAILBITER) and artist ANDREI BRESSAN.</em></p>",
                _issue?.Description);
        }

        [Test]
        public void TestParseIssueFirstAppearanceCharacters()
        {
            Assert.AreEqual(null, _issue?.FirstAppearanceCharacters);
        }

        [Test]
        public void TestParseIssueFirstAppearanceConcepts()
        {
            Assert.AreEqual(null, _issue?.FirstAppearanceConcepts);
        }

        [Test]
        public void TestParseIssueFirstAppearanceLocations()
        {
            Assert.AreEqual(null, _issue?.FirstAppearanceLocations);
        }

        [Test]
        public void TestParseIssueFirstAppearanceObjects()
        {
            Assert.AreEqual(null, _issue?.FirstAppearanceObjects);
        }

        [Test]
        public void TestParseIssueFirstAppearanceStoryarcs()
        {
            Assert.AreEqual(null, _issue?.FirstAppearanceStoryarcs);
        }

        [Test]
        public void TestParseIssueFirstAppearanceTeams()
        {
            Assert.AreEqual(null, _issue?.FirstAppearanceTeams);
        }

        [Test]
        public void TestParseIssueId()
        {
            Assert.AreEqual(467608, _issue?.Id);
        }

        [Test]
        public void TestParseIssueIssueNumber()
        {
            Assert.AreEqual(1, _issue?.IssueNumber);
        }

        [Test]
        public void TestParseIssueLocationCredits()
        {
            Assert.AreEqual(1, _issue?.LocationCredits?.Count);
        }

        [Test]
        public void TestParseIssueName()
        {
            Assert.AreEqual(null, _issue?.Name);
        }

        [Test]
        public void TestParseIssueObjectCredits()
        {
            Assert.AreEqual(0, _issue?.ObjectCredits?.Count);
        }

        [Test]
        public void TestParseIssuePersonCredits()
        {
            Assert.AreEqual(8, _issue?.PersonCredits?.Count);
        }

        [Test]
        public void TestParseIssueSiteDetailUrl()
        {
            Assert.AreEqual("https://comicvine.gamespot.com/birthright-1/4000-467608/", _issue?.SiteDetailUrl);
        }

        [Test]
        public void TestParseIssueStoreDate()
        {
            Assert.AreEqual("2014-10-08", _issue?.StoreDate);
        }

        [Test]
        public void TestParseIssueStoryArcCredits()
        {
            Assert.AreEqual(0, _issue?.StoryArcCredits?.Count);
        }

        [Test]
        public void TestParseIssueTeamCredits()
        {
            Assert.AreEqual(0, _issue?.TeamCredits?.Count);
        }

        [Test]
        public void TestParseIssueTeamDisbandedIn()
        {
            Assert.AreEqual(0, _issue?.TeamDisbandedIn?.Count);
        }

        [Test]
        public void TestParseIssueVolume()
        {
            Assert.AreEqual(77405, _issue?.Volume?.Id);
        }
    }
}