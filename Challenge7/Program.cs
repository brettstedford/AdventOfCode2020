using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge7
{
    class Program
    {
        private static readonly Dictionary<string, string> LuggageConditions = new Dictionary<string, string>();
        private static readonly Dictionary<string, int> LuggageCount = new Dictionary<string, int>();
        private static readonly List<string> ValidContainers = new List<string>();
        private const string MyBag = "shiny gold bag";

        static void Main(string[] args)
        {
            var luggageConditions = Input.GetLuggageConditionsFrom("luggage-conditions.txt").ToList();
            
            luggageConditions.ForEach(lc =>
            {
                var conditionParts = lc.Split("s contain");
                var thisBag = conditionParts[0].Trim();
                var conditions = conditionParts[1];
                LuggageConditions.Add(thisBag, conditions);
            });
            
            CalculateValidContainersOf(MyBag);
            ValidContainers.ForEach(Console.WriteLine);
            Console.WriteLine($"Valid container count: {ValidContainers.Count}");

            CalculateBagsInsideOf(MyBag);
            var bagCount = LuggageCount.Select(kvp => kvp.Value).Sum();
            Console.WriteLine($"{MyBag} contains {bagCount} bags");
        }

        private static void CalculateBagsInsideOf(string bag)
        {
            var whatsInsideBag = LuggageConditions[bag].Split(",").ToList();
            
            foreach (var containedBag in whatsInsideBag)
            {
                if (containedBag.Trim() == "no other bags.")
                    return;
                
                var count = int.Parse(Regex.Match(containedBag, "(\\d+)").Value);
                var bagName = Regex.Match(containedBag.Trim(), "[a-z]+").Value.Trim().TrimEnd('s').TrimEnd('.');
                
                if (LuggageCount.ContainsKey(bagName))
                    LuggageCount[bagName] += count;
                else 
                    LuggageCount[bagName] = count;
                
                for(var i = 0; i < count; i++)
                    CalculateBagsInsideOf(bagName);
            }
        }

        private static void CalculateValidContainersOf(string bag)
        {
            var canContainBag = LuggageConditions
                .Where(x => x.Value.Contains(bag))
                .ToList();

            if (!canContainBag.Any())
                return;

            var additions = canContainBag.Select(c => c.Key).Except(ValidContainers);
            ValidContainers.AddRange(additions);
            canContainBag.ForEach(b => CalculateValidContainersOf(b.Key));
        }
    }
}