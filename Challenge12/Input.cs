using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge12
{
    public static class Input
    {
        public static IEnumerable<NavigationInstruction> GetNavigationInstructionsFrom(string filename)
        {
            return File
                .ReadLines(filename)
                .Select(l => new NavigationInstruction(l));
        }
    }
}