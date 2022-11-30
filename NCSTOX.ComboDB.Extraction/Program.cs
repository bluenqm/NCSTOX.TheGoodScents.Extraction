using NCSTOX.ComboDB.Extraction;

const string fileExtractionName = @"ecomole.txt";

ComboDBPageExtractor comboDBPageExtractor = new();
comboDBPageExtractor.GenerateExtractionFile(fileExtractionName);
