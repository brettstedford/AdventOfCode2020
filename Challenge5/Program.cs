using System;
using System.Linq;

namespace Challenge5
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardingPasses = Input
                .GetBoardingPassesFrom("boarding-passes.txt")
                .OrderBy(bp => bp.SeatNumber)
                .ToList();
            
            Console.WriteLine($"Highest Seat Number: {boardingPasses.Max(bp => bp.SeatNumber)}");

            for (var i = 1; i < boardingPasses.Count - 1; i++)
            {
                if (boardingPasses[i].SeatNumber + 1 == boardingPasses[i + 1].SeatNumber) 
                    continue;
                
                Console.WriteLine($"My Seat Number: {boardingPasses[i].SeatNumber + 1}");
                break;
            }
        }
    }
}