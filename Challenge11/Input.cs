using System;
using System.IO;
using System.Linq;

namespace Challenge11
{
    public static class Input
    {
        public static char[,] GetSeatingPlanFrom(string filename)
        {
            var lines = File.ReadLines(filename).ToArray();

            if (lines == null || !lines.Any())
                throw new ApplicationException("Could not read file lines");

            var ranks = lines.First().Length;
            var files = lines.Length;

            var seatingPlan = new char[files, ranks];

            for (var f = 0; f < files; f++)
            {
                var lineChars = lines[f].ToCharArray();

                for (var r = 0; r < ranks; r++)
                {
                    var rankChar = lineChars[r];
                    seatingPlan[f, r] = rankChar;
                }
            }

            return seatingPlan;
        }
    }
}