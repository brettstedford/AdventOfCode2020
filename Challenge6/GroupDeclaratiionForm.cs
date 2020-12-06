using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge6
{
    public class GroupDeclaratiionForm
    {
        public IEnumerable<char[]> IndividualResults { get; }
        public IEnumerable<char> ResultsAllAnswered { get; }

        public GroupDeclaratiionForm(string resultsAsString)
        {
            IndividualResults = resultsAsString
                .Split("\n")
                .Select(l => l.ToCharArray())
                .ToList();

            var distinctAnswers = IndividualResults
                .SelectMany(a => a).Distinct();

            var answerGroups = distinctAnswers
                .ToDictionary(a => a, a => IndividualResults.Count(r => r.Contains(a)));

            ResultsAllAnswered = answerGroups
                .Where(g => g.Value == IndividualResults.Count())
                .Select(g => g.Key)
                .ToList();
            
            Console.WriteLine();
            Console.WriteLine(resultsAsString);
            Console.WriteLine();
            Console.WriteLine($"All Answered: {string.Join(" ", ResultsAllAnswered)}");
            Console.WriteLine(ResultsAllAnswered.Count());
            Console.WriteLine();
        }
    }
}