using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge7
{
    public static class Input
    {
        public static IEnumerable<string> GetLuggageConditionsFrom(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}