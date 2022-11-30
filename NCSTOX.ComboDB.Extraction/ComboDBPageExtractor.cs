using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NCSTOX.ComboDB.Extraction
{
    public class ComboDBPageExtractor
    {
        const string COMBODB_PAGE_PREFIX = @"https://combodb.ecomole.com/report/?botanic_page=";
        const string COMBODB_URL_PREFIX = @"https://combodb.ecomole.com/";
        const int COMBODB_MAX_PAGE = 28;

        public void GenerateExtractionFile(string fileName)
        {
            List<string> lines = new();
            for (int i = 1; i <= COMBODB_MAX_PAGE; i++)
            {
                Console.Write(".");
                string url = COMBODB_PAGE_PREFIX + i.ToString();
                string htmlString = GetHTMLStringFromURL(url);
                List<string> bonatics = GetExtractedBotanic(htmlString);
                foreach (string bonatic in bonatics)
                    lines.Add(bonatic);
            }
            File.WriteAllLines(fileName, lines.ToArray());
        }

        private List<string> GetExtractedBotanic(string htmlString)
        {
            List<string> botanics = new List<string>();
            Regex rURL = new Regex(@"report\/\d+.*(?=<\/a>)");
            Match mURL = rURL.Match(htmlString);
            while (mURL.Success)
            {
                string[] extractedBotanics = FormatExtractedString(mURL.Value).Split('\n');
                foreach(string extractedBotanic in extractedBotanics) 
                    botanics.Add(extractedBotanic);
                mURL = mURL.NextMatch();
            }
            return botanics;
        }

        private string FormatExtractedString(string extractedString)
        {
            string formatedString = "";

            extractedString = extractedString.TrimEnd('.');
            int firstSplitPos = extractedString.IndexOf("?botanic_page");
            string botanicURL = extractedString.Substring(0, firstSplitPos);
            int seconSplitPos = extractedString.IndexOf("list-group-item\">");
            string botanicName = extractedString.Substring(seconSplitPos + "list-group-item\">".Length);
            string modifiedBotanicName = botanicName.Replace(" // ", "\t");
            string[] names = modifiedBotanicName.Split('\t');
            foreach (string name in names)
            {
                formatedString = formatedString + GetFirstNWords(name, 2) + "\t" + botanicName + "\t" + COMBODB_URL_PREFIX + botanicURL + "\n";
            }

            return formatedString.Trim();
        }

        private string GetFirstNWords(string str, int n)
        {
            IEnumerable<string> words = str.Split().Take(n);
            string firstNWords = "";
            foreach (string word in words)
            {
                if (word.StartsWith("("))
                    continue;
                firstNWords += (word + " ");
            }
            return firstNWords.Trim();
        }

        private string GetHTMLStringFromURL(string url)
        {
            using (WebClient client = new())
            {
                string htmlString = client.DownloadString(url);
                return htmlString;
            }
        }
    }
}
