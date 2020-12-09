using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge9
{
    public static class Input
    {
        public static IEnumerable<long> GetXmasDataFrom(string fileName)
        {
            return File.ReadAllLines(fileName).Select(long.Parse);
        }
    }
}