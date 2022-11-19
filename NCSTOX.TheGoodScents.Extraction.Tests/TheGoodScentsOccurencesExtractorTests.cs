using FluentAssertions;
using NCSTOX.TheGoodScents.Extraction.Extractors;

namespace NCSTOX.TheGoodScents.Extraction.Tests
{
    [TestClass]
    public class TheGoodScentsOccurencesExtractorTests
    {
        TheGoodScentsOccurencesExtractor extractor;

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
            extractor.GetOccurrences(downloadedHTMLFile);
        }

        [TestMethod]
        public void DownloadedFileContainsNoURL_ThenReturnEmptyString()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\noURL.html";
            string occurences = extractor.GetOccurrences(downloadedHTMLFile);
            occurences.Should().Be("");
        }

        [TestMethod]
        public void DownloadedFileLeadsToValidOccurences_ThenReturnCorrectOne()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\155.html";
            string occurences = extractor.GetOccurrences(downloadedHTMLFile);
            occurences.Should().Be("chamomile\tfenugreek");
        }

        [TestMethod]
        public void DownloadedFileLeadsToNoOccurence_ThenReturnEmptyString()
        {
            string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\10069.html";
            string occurences = extractor.GetOccurrences(downloadedHTMLFile);
            occurences.Should().Be("");
        }
    }
}