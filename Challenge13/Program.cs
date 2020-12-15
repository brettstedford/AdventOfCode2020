using System;
using System.Linq;

namespace Challenge13
{
    class Program
    {
        static void Main(string[] args)
        {
            var sbd = Input.GetFromFile("test-shuttlebuses.txt");
            
            Console.WriteLine(sbd.EarliestEstimatedDepartureTimestamp);
            Console.WriteLine();
            sbd.ShuttleBuses.ToList().ForEach(Console.WriteLine);
            
            Console.WriteLine($"Part one answer: {sbd.GetBusToCatch()}");
            Console.WriteLine($"Part two answer: {sbd.GetEarliestTimestamp_BruteForce()}");
        }
    }
}