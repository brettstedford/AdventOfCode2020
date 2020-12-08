using System.Collections.Generic;
using System.Linq;

namespace Challenge8
{
    public static class Extensions
    {
        public static IEnumerable<int> AllIndexesOf(this InstructionSet set, string[] commands)
        {
            int minIndex = set.Instructions.ToList().FindIndex(i => commands.Contains(i.cmd));

            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = set.Instructions.ToList().FindIndex(minIndex + 1, i => commands.Contains(i.cmd));
            }
        }
    }
}