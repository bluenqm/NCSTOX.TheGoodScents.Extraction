using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public class TheGoodScentsOccurenceBulkExtractor : ITheGoodScentsOccurenceBulkExtractor
    {
        public const string FILE_HTML_DIR = @"D:\Working\NACTEM\NCSTOX\Data\";
        public void GetOccurrences(string fileMoleculeLocation, string downloadedHTMLDirectoryLocation, string outputFileLocation)
        {
            Console.WriteLine("Extracting ...");
            TheGoodScentsOccurencesExtractor extractor = new();
            using (var reader = new StreamReader(fileMoleculeLocation))
            {
                using (var writer = new StreamWriter(outputFileLocation))
                {
                    int count = 0;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        count++;
                        if (count % 100 == 0)
                        {
                            Console.Write(".");
                            if (count % 5000 == 0)
                                Console.WriteLine();
                        }
                        string downloadedHTMLFileName = FILE_HTML_DIR + count.ToString() + ".html";
                        if (File.Exists(downloadedHTMLFileName))
                        {
                            string occurences = extractor.GetOccurrences(downloadedHTMLFileName);
                            string result = line + "\t" + TheGoodScentsURLExtractor.ExtractURL(downloadedHTMLFileName) + "\t" + occurences;
                            writer.WriteLine(result);
                        }
                    }
                    writer.Close();
                }
                reader.Close();
            }
            Console.WriteLine("Extraction Finished!");
        }
    }
}
