using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge3
{
    public static class Output
    {
        public static void ToFile(char[,] landscape, string fileName)
        {
            var lines = new List<string>();

            for (int f = 0; f < landscape.GetLength(0); f++)
            {
                var line = string.Empty;
                
                for (int r = 0; r < landscape.GetLength(1); r++)
                {
                    line += landscape[f, r];
                }
                
                lines.Add(line);
            }
            
            File.WriteAllLines(fileName, lines);
        }
    }
    
    public static class Input
    {
        public static char[,] GetLandscapeSection()
        {
            var lines = File.ReadLines("tree-input.txt").ToArray();
            
            if(lines == null || !lines.Any())
                throw new ApplicationException("Could not read file lines");
                
            var ranks = lines.First().Length;
            var files = lines.Length;

            var landscapeSection = new char[files, ranks];

            for (var f = 0; f < files; f++)
            {
                var lineChars = lines[f].ToCharArray();
                
                for (var r = 0; r < ranks; r++)
                {
                    var rankChar = lineChars[r];
                    landscapeSection[f, r] = rankChar;
                }
            }

            return landscapeSection;
        }
    }
}