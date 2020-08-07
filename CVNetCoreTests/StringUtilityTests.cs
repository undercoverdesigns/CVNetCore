using CVNetCore.Utility;
using NUnit.Framework;

namespace CVNetCoreTests
{
    [TestFixture]
    public class StringUtilityTests
    {
        [Test]
        public void TestExtractMonthFailDateWithoutDay()
        {
            Assert.AreNotEqual(10, StringUtilities.ExtractMonth("2014-10"));
        }

        [Test]
        public void TestExtractMonthFailEmptyDate()
        {
            Assert.AreNotEqual(8, StringUtilities.ExtractMonth(""));
        }

        [Test]
        public void TestExtractMonthFailWrongDate()
        {
            Assert.AreNotEqual(8, StringUtilities.ExtractMonth("2014-10-31"));
        }

        [Test]
        public void TestExtractMonthPassDateFullDateTime()
        {
            Assert.AreEqual(10, StringUtilities.ExtractMonth("2014-10-31 10:18:12"));
        }

        [Test]
        public void TestExtractMonthPassFailedToParse()
        {
            Assert.AreEqual(-1, StringUtilities.ExtractMonth("2014-31-10"));
        }

        [Test]
        public void TestExtractMonthPassFullDate()
        {
            Assert.AreEqual(10, StringUtilities.ExtractMonth("2014-10-31"));
        }

        [Test]
        public void TestExtractYearFailEmptyDate()
        {
            Assert.AreNotEqual(2014, StringUtilities.ExtractYear(""));
        }

        [Test]
        public void TestExtractYearFailWrongDate()
        {
            Assert.AreNotEqual(2012, StringUtilities.ExtractYear("2014-10-31"));
        }

        [Test]
        public void TestExtractYearPassDateFullDateTime()
        {
            Assert.AreEqual(2014, StringUtilities.ExtractYear("2014-10-31 10:18:12"));
        }

        [Test]
        public void TestExtractYearPassDateWithoutDay()
        {
            Assert.AreEqual(2014, StringUtilities.ExtractYear("2014-10"));
        }

        [Test]
        public void TestExtractYearPassFullDate()
        {
            Assert.AreEqual(2014, StringUtilities.ExtractYear("2014-10-31"));
        }

        [Test]
        public void TryToParseFailEmptyString()
        {
            Assert.AreEqual(-1, StringUtilities.TryToParse(""));
        }

        [Test]
        public void TryToParseFailFloat()
        {
            Assert.AreEqual(-1, StringUtilities.TryToParse("20.14"));
        }

        [Test]
        public void TryToParseFailNonDigitCharacters()
        {
            Assert.AreEqual(-1, StringUtilities.TryToParse("2O14"));
        }

        [Test]
        public void TryToParsePass()
        {
            Assert.AreEqual(2014, StringUtilities.TryToParse("2014"));
        }

        [Test]
        public void TryToParsePassStringPadded()
        {
            Assert.AreEqual(2014, StringUtilities.TryToParse(" 2014 "));
        }

        [Test]
        public void TryToParsePassZeroPadded()
        {
            Assert.AreEqual(2014, StringUtilities.TryToParse("02014"));
        }
    }
}