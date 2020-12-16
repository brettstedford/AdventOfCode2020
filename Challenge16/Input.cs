using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge16
{
    public static class Input
    {
        private static IEnumerable<string> GetFileLines(string filename) => File.ReadAllLines(filename);
        
        public static IEnumerable<Rule> GetRulesFrom(string filename)
        {
            var lines = GetFileLines(filename);
            
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    yield break;
                
                yield return new Rule(line);
            }
        }

        public static IEnumerable<Ticket> GetNearbyTicketsFrom(string filename)
        {
            var lines = GetFileLines(filename).ToList();

            var sI = lines.FindIndex(l => l == "nearby tickets:");

            for (var i = sI + 1; i < lines.Count; i++)
            {
                yield return new Ticket(lines[i]);   
            }
        }
    }
}