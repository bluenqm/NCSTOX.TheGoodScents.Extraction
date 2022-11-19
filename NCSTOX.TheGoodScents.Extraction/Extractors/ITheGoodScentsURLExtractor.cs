using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCSTOX.TheGoodScents.Extraction.Extractors
{
    public interface ITheGoodScentsURLExtractor
    {
        string ExtractURL(string downloadedHTMLFileLocation);
    }
}
