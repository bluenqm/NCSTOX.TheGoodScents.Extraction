using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public interface ITheGoodScentsOccurencesExtractor
    {
        string GetOccurrences(string downloadedHTMLFileLocation);
    }
}
