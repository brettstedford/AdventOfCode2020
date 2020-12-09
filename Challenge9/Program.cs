using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge9
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PreambleLength = 25;
            var xmasData = Input.GetXmasDataFrom("xmas-data.txt").ToList();
            
            bool foundBrokenNumber = false;
            long checkValue = 0;
            int index = PreambleLength;

            while (!foundBrokenNumber)
            {
                checkValue = xmasData[index];

                var skipFrom = index - PreambleLength;

                var applicablePreamble = xmasData.Skip(skipFrom).Take(PreambleLength).ToArray();

                bool next = false;
                
                for (var j = 0; j <= applicablePreamble.Length && !next; j++)
                {
                    if (j == applicablePreamble.Length)
                    {
                        foundBrokenNumber = true;
                        break;
                    }
                    
                    for (var n = j + 1; n < applicablePreamble.Length; n++)
                    {
                        if (applicablePreamble[j] + applicablePreamble[n] == checkValue)
                        {
                            index++;
                            next = true;
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine($"{checkValue} does not compute based on a preamble of {PreambleLength}");

            bool weaknessFound = false;

            List<long> contiguousNumbers = new List<long>();

            for (var i = 0; i < index && !weaknessFound; i++)
            {
                contiguousNumbers.Clear();
                contiguousNumbers.Add(xmasData[i]);
                var count = xmasData[i];

                for (var j = i + 1; j < index; j++)
                {
                    contiguousNumbers.Add(xmasData[j]);
                    count += xmasData[j];

                    if (count > checkValue)
                    {
                        break;
                    }

                    if (count == checkValue)
                    {
                        weaknessFound = true;
                        break;
                    }
                }
            }
            
            Console.WriteLine("Contiguos Numbers:");
            contiguousNumbers.ForEach(Console.WriteLine);
            Console.WriteLine($"Lowest Number: {contiguousNumbers.Min()}");
            Console.WriteLine($"Highest Number: {contiguousNumbers.Max()}");
            Console.WriteLine($"Summed: {contiguousNumbers.Min() + contiguousNumbers.Max()}");
        }
    }
}