// See https://aka.ms/new-console-template for more information
using NCSTOX.TheGoodScents.Extraction.Extractors;

Console.WriteLine("Hello, World!");

TheGoodScentsURLExtractor extractor = new();
string downloadedHTMLFile = @"D:\Working\NACTEM\NCSTOX\Data\10069.html";
string url = extractor.ExtractURL(downloadedHTMLFile);
Console.WriteLine(url);