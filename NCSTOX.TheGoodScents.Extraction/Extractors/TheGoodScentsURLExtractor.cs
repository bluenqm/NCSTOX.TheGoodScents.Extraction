using System.Text.RegularExpressions;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public class TheGoodScentsURLExtractor : ITheGoodScentsURLExtractor
    {
        private const string URL_PREFIX = "http://www.thegoodscentscompany.com/";

        public string ExtractURL(string downloadedHTMLFileLocation)
        {
            string textFromdownloadedHTMLFile = string.Empty;
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

        private string BuildFullURL(string partURL)
        {
            return URL_PREFIX + partURL;
        }
    }
}
