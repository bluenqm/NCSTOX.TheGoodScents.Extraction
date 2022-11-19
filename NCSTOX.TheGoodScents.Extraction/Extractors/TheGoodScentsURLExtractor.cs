using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public static class TheGoodScentsURLExtractor
    {
        private const string URL_PREFIX = "http://www.thegoodscentscompany.com/";

        public static string ExtractURL(string downloadedHTMLFileLocation)
        {
            string textFromdownloadedHTMLFile;
            try
            {
                textFromdownloadedHTMLFile = File.ReadAllText(downloadedHTMLFileLocation);
            }
            catch(Exception)
            {
                throw;
            }
            Regex rURLPattern = new("(?<=onclick=\"openMainWindow\\(\\&\\#39\\;).*?(?=\\&\\#39\\;)");
            Match mURL = rURLPattern.Match(textFromdownloadedHTMLFile);
            if (mURL.Success)
                return BuildFullURL(mURL.Value);
            else
                return string.Empty;
        }

        private static string BuildFullURL(string partURL)
        {
            return URL_PREFIX + partURL;
        }
    }
}
