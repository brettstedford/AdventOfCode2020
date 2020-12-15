using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge14
{
    public static class Input
    {
        public static IEnumerable<IInstruction> GetFromFile(string filename)
        {
            var lines = File.ReadAllLines(filename).ToList();

            return lines.Select(l =>
            {
                if (l.StartsWith("mask"))
                {
                    return (IInstruction)new UpdateMask(l);
                }

                if (l.StartsWith("mem"))
                {
                    return (IInstruction)new UpdateMemoryAddress(l); 
                }
                
                throw new ArgumentOutOfRangeException("line", l, "Unknown instruction text");
            });
        }
    }
}