// See https://aka.ms/new-console-template for more information
using NCSTOX.TheGoodScents.Extraction.Extractors;

Console.WriteLine("Hello, World!");

TheGoodScentsOccurenceBulkExtractor extractor = new();
string downloadedHTMLFolder = @"D:\Working\NACTEM\NCSTOX\Data\";
string moleculeFile = @"C:\Users\nqminh\Documents\NCSTOX-master\ncstoxII25k.csv";
string outputFile = @"C:\Users\nqminh\Documents\NCSTOX-master\TheGoodScentsResults.txt";
extractor.GetOccurrences(moleculeFile, downloadedHTMLFolder, outputFile);