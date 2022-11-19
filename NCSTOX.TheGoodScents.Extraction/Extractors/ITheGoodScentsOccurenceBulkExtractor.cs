using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public interface ITheGoodScentsOccurenceBulkExtractor
    {
        void GetOccurrences(string fileMoleculeLocation, string downloadedHTMLDirectoryLocation, string outputFileLocation);
    }
}
