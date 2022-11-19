using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public class TheGoodScentsOccurencesExtractor : ITheGoodScentsOccurencesExtractor
    {
        public string GetOccurrences(string downloadedHTMLFileLocation)
        {
            string url = TheGoodScentsURLExtractor.ExtractURL(downloadedHTMLFileLocation);
            if (url.Equals(string.Empty))
                return string.Empty;
            string htmlString = GetHTMLStringFromURL(url);
            string occurences = GetOccurencesFromHTMLString(htmlString);
            return occurences;
        }

        private string GetHTMLStringFromURL(string url)
        {
            using (WebClient client = new())
            {
                string htmlString = client.DownloadString(url);
                return htmlString;
            }
        }

        private string GetOccurencesFromHTMLString(string htmlString)
        {
            Regex rOccurencePattern = new("(?<=<td class=\\\"wrd89\\\">).*?(?=<br)");
            Match mOccurence = rOccurencePattern.Match(htmlString);
            List<string> occurenceList = new List<string>();
            while (mOccurence.Success)
            {
                occurenceList.Add(mOccurence.Value);
                mOccurence = mOccurence.NextMatch();
            }
            return BuildStringFromList(occurenceList);
        }

        private string BuildStringFromList(List<string> occurenceList)
        {
            string occurences = string.Join("\t", occurenceList.ToArray());
            return occurences;
        }
    }
}
