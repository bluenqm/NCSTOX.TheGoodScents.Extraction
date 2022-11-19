using FluentAssertions;
using NCSTOX.TheGoodScents.Extraction.Extractors;

namespace NCSTOX.TheGoodScents.Extraction.Tests
{
    [TestClass]
    public class TheGoodScentsURLExtractorTests
    {
        TheGoodScentsURLExtractor extractor;

        [TestInitialize]
        public void Setup()
        {
            extractor = new();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void DownloadedFileNotExisting_ThenThrowException()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\154.html";
            string url = extractor.ExtractURL(downloadedHTMLFile);
        }

        [TestMethod]
        public void DownloadedFileContainsNoURL_ThenReturnEmptyString()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\noURL.html";
            string url = extractor.ExtractURL(downloadedHTMLFile);
            url.Should().Be("");
        }

        [TestMethod]
        public void DownloadedFileContainsSingleURL_ThenReturnOne()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\155.html";
            string url = extractor.ExtractURL(downloadedHTMLFile);
            url.Should().Be("http://www.thegoodscentscompany.com/data/rw1560811.html");
        }

        [TestMethod]
        public void DownloadedFileContainsMultipleURLs_ThenReturnFirstOne()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\10069.html";
            string url = extractor.ExtractURL(downloadedHTMLFile);
            url.Should().Be("http://www.thegoodscentscompany.com/data/rw1004532.html");
        }
    }
}