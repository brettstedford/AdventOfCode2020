using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge10
{
    public static class Input
    {
        public static List<int> GetSortedAdaptorsFrom(string filename)
        {
            return File
                .ReadAllLines(filename)
                .Select(int.Parse)
                .OrderBy(a => a)
                .ToList();
        }
    }
}