﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge10
{
    class Program
    {
        private static readonly List<int> TestedAdaptors = new List<int>();
        private static readonly Dictionary<int, int> Differences = new Dictionary<int, int>();
        private static readonly Dictionary<int, long> CalculatedSteps = new Dictionary<int, long>();
        private const int OutletJolts = 0;
        private const int JoltRatingThreshold = 3;

        static void Main(string[] args)
        {
            var adaptors = Input.GetSortedAdaptorsFrom("adaptors-list.txt");
            adaptors.ForEach(Console.WriteLine);
            
            var minTestRating = OutletJolts;
            var maxTestRating = JoltRatingThreshold;
            
            Differences[JoltRatingThreshold] = 1; // my device
            TestAdaptorsDifferences(adaptors, minTestRating, maxTestRating);

            Console.WriteLine($"Differences of 1: {Differences[1]}");
            Console.WriteLine($"Differences of 3: {Differences[3]}");
            Console.WriteLine($"Multiplied: {Differences[1]*Differences[3]}");
           
            adaptors.Insert(0,0); // outlet
            adaptors.Add(adaptors.Last() + 3); // my device
            var combinations = CalculateStepsFrom(0, adaptors);
            Console.WriteLine($"Combinations: {combinations}");
        }
        
        private static void TestAdaptorsDifferences(List<int> adaptors, int minTestRating, int maxTestRating)
        {
            var adaptorsUnderTest = adaptors
                .Where(a => a >= minTestRating && a <= maxTestRating)
                .Except(TestedAdaptors);

            foreach (var adaptor in adaptorsUnderTest)
            {
                if (TestedAdaptors.Contains(adaptor))
                    continue;

                TestedAdaptors.Add(adaptor);
                var difference = Math.Abs(minTestRating - adaptor);

                if (Differences.ContainsKey(difference))
                    Differences[difference]++;
                else
                    Differences.Add(difference, 1);

                TestAdaptorsDifferences(adaptors, adaptor, adaptor + JoltRatingThreshold);
            }
        }
        
        public static long CalculateStepsFrom(int adaptorIndex, List<int> adaptors)
        {
            if (adaptorIndex == adaptors.Count-1)
                return 1;

            if (CalculatedSteps.ContainsKey(adaptorIndex))
                return CalculatedSteps[adaptorIndex];
            
            long steps = 0;
            
            for(var nextAdaptorIndex = adaptorIndex+1; nextAdaptorIndex < adaptors.Count; nextAdaptorIndex++)
            {
                if (adaptors[nextAdaptorIndex] - adaptors[adaptorIndex] <= 3)
                {
                    steps += CalculateStepsFrom(nextAdaptorIndex, adaptors);
                }
            }

            CalculatedSteps[adaptorIndex] = steps;

            return steps;
        }
    }
}