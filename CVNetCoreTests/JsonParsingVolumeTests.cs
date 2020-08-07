#nullable enable
using System.IO;
using System.Reflection;
using CVNetCore.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CVNetCoreTests
{
    [TestFixture]
    public class JsonParsingVolumeTests
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _volumeSearchResults = GetFileContents("volume.search.json");
            _volumeDetailsQueryResult = GetFileContents("volume.details.json");

            _volume = JsonConvert.DeserializeObject<VolumeQuery>(_volumeDetailsQueryResult).Volume;
            _volumeSearchQuery = JsonConvert.DeserializeObject<VolumeSearchQuery>(_volumeSearchResults);
        }

        #endregion

        private string _volumeSearchResults = null!;
        private string _volumeDetailsQueryResult = null!;

        private Volume? _volume;
        private VolumeSearchQuery? _volumeSearchQuery;

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
        public void TestParseVolumeAliases()
        {
            Assert.AreEqual(null, _volume?.Aliases);
        }

        [Test]
        public void TestParseVolumeApiDetailUrl()
        {
            Assert.AreEqual("https://comicvine.gamespot.com/api/volume/4050-77405/", _volume?.ApiDetailUrl);
        }

        [Test]
        public void TestParseVolumeCharacters()
        {
            Assert.AreEqual(13, _volume?.Characters?.Count);
        }

        [Test]
        public void TestParseVolumeConcepts()
        {
            Assert.AreEqual(6, _volume?.Concepts?.Count);
        }

        [Test]
        public void TestParseVolumeCountOfIssues()
        {
            Assert.AreEqual(45, _volume?.CountOfIssues);
        }

        [Test]
        public void TestParseVolumeDateAdded()
        {
            Assert.AreEqual("2014-10-06 07:11:34", _volume?.DateAdded);
        }

        [Test]
        public void TestParseVolumeDateLastUpdated()
        {
            Assert.AreEqual("2019-07-03 08:00:14", _volume?.DateLastUpdated);
        }

        [Test]
        public void TestParseVolumeDeck()
        {
            Assert.AreEqual(null, _volume?.Deck);
        }

        [Test]
        public void TestParseVolumeDescription()
        {
            Assert.AreEqual(
                "<figure data-align=\"right\" data-size=\"small\" data-img-src=\"https://static.comicvine.com/uploads/original/6/67663/6640908-7416313545-26106.jpg\" data-ref-id=\"1300-6640908\" data-ratio=\"1\" data-width=\"600\" data-embed-type=\"image\" style=\"width: 600px\"><a class=\"fluid-height\" style=\"padding-bottom:100.0%\" href=\"https://static.comicvine.com/uploads/original/6/67663/6640908-7416313545-26106.jpg\" data-ref-id=\"1300-6640908\"><img alt=\"No Caption Provided\" src=\"https://comicvine1.cbsistatic.com/uploads/original/6/67663/6640908-7416313545-26106.jpg\" srcset=\"https://comicvine1.cbsistatic.com/uploads/original/6/67663/6640908-7416313545-26106.jpg 600w\" sizes=\"(max-width: 600px) 100vw, 600px\" data-width=\"600\"></a></figure><p>Adventure series from writer <a href=\"/joshua-williamson/4040-56513/\" data-ref-id=\"4040-56513\">Joshua Williamson</a> and artist <a href=\"/andrei-bressan/4040-62091/\" data-ref-id=\"4040-62091\">Andrei Bressan</a>.</p><h4>Collected Editions</h4><ul><li><a href=\"/birthright-homecoming/4050-80468/\" data-ref-id=\"4050-80468\">Birthright: Homecoming</a> (#1-5)</li><li><a href=\"/birthright-call-to-adventure/4050-84574/\" data-ref-id=\"4050-84574\">Birthright: Call To Adventure</a> (#6-10)</li><li><a href=\"https://comicvine.gamespot.com/birthright-allies-and-enemies/4050-90399/\" data-ref-id=\"4050-90399\">Birthright: Allies and Enemies</a> (#11-15)</li><li><a href=\"https://comicvine.gamespot.com/birthright-family-history/4050-96650/\" data-ref-id=\"4050-96650\">Birthright: Family History</a> (#16-20)</li><li><a href=\"https://comicvine.gamespot.com/birthright-belly-of-the-beast/4050-102741/\" data-ref-id=\"4050-102741\">Birthright: Belly of the Beast</a> (#21-25)</li><li><a href=\"/birthright-fatherhood/4050-109596/\" data-ref-id=\"4050-109596\">Birthright: Fatherhood</a> (#26-30)</li><li><a href=\"https://comicvine.gamespot.com/birthright-blood-brothers/4050-117048/\">Birthright: Blood Brothers</a> (#31-35)</li></ul>",
                _volume?.Description);
        }

        [Test]
        public void TestParseVolumeFirstIssue()
        {
            Assert.AreEqual(467608, _volume?.FirstIssue?.Id);
            Assert.AreEqual(1, _volume?.FirstIssue?.IssueNumber);
        }

        [Test]
        public void TestParseVolumeId()
        {
            Assert.AreEqual(77405, _volume?.Id);
        }

        [Test]
        public void TestParseVolumeIssues()
        {
            Assert.AreEqual(45, _volume?.Issues?.Count);
        }

        [Test]
        public void TestParseVolumeLastIssue()
        {
            Assert.AreEqual(781655, _volume?.LastIssue?.Id);
            Assert.AreEqual(45, _volume?.LastIssue?.IssueNumber);
        }

        [Test]
        public void TestParseVolumeLocations()
        {
            Assert.AreEqual(2, _volume?.Locations?.Count);
        }

        [Test]
        public void TestParseVolumeName()
        {
            Assert.AreEqual("Birthright", _volume?.Name);
        }

        [Test]
        public void TestParseVolumeObjects()
        {
            Assert.AreEqual(13, _volume?.Objects?.Count);
        }

        [Test]
        public void TestParseVolumePeople()
        {
            Assert.AreEqual(22, _volume?.People?.Count);
        }

        [Test]
        public void TestParseVolumePublisher()
        {
            Assert.AreEqual("Skybound", _volume?.Publisher?.Name);
            Assert.AreEqual(2861, _volume?.Publisher?.Id);
        }

        [Test]
        public void TestParseVolumeSearchTotalResults()
        {
            Assert.AreEqual(18, _volumeSearchQuery?.NumberOfTotalResults);
            Assert.AreEqual(18, _volumeSearchQuery?.Results.Count);
        }

        [Test]
        public void TestParseVolumeSiteDetailUrl()
        {
            Assert.AreEqual("https://comicvine.gamespot.com/birthright/4050-77405/", _volume?.SiteDetailUrl);
        }

        [Test]
        public void TestParseVolumeStartYear()
        {
            Assert.AreEqual(2014, _volume?.StartYear);
        }
    }
}