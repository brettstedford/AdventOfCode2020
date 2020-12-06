using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge6
{
    public static class Input
    {
        public static IEnumerable<GroupDeclaratiionForm> GetDeclarationFormsFrom(string fileName)
        {
            return File
                .ReadAllText(fileName)
                .Split($"\n\n")
                .Select(df => new GroupDeclaratiionForm(df));
        }
    }
}