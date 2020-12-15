using System;
using System.Linq;

namespace Challenge12
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = Input.GetNavigationInstructionsFrom("navigation.txt").ToList();
            var partOneFerry = new PartOneFerry();
            
            instructions.ForEach(i =>
            {
                partOneFerry.Navigate(i);
            });
            
            Console.WriteLine(partOneFerry.ManhattanDistance);
            
            var partTwoFerry = new PartTwoFerry();
            
            instructions.ForEach(i =>
            {
                partTwoFerry.Navigate(i);
            });
            
            Console.WriteLine(partTwoFerry.ManhattanDistance);
        }
    }
}