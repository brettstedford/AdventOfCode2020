using System;
using System.Collections.Generic;

namespace Challenge15
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGame(2020,new[] {0,3,6} );
            NumberGame(2020, new []{20,9,11,0,1,2});
            NumberGame(30000000,new[] {0,3,6} );
            NumberGame(30000000, new []{20,9,11,0,1,2});
        }

        private static void NumberGame(int countUpto, int[] startingNumbers)
        {
            var turn = 1;
            var lastNumber = 0;
            var seenNumbers = new Dictionary<int, (int lastTime, int timeBefore)>();

            while (turn <= countUpto)
            {
                if (turn - 1 < startingNumbers.Length)
                {
                    lastNumber = startingNumbers[turn - 1];
                    seenNumbers[lastNumber] = (turn, turn);
                    turn++;
                    continue;
                }

                if (!seenNumbers.ContainsKey(lastNumber))
                {
                    lastNumber = 0;
                }
                else
                {
                    (int lastTime, int timeBefore) = seenNumbers[lastNumber];
                    lastNumber = lastTime - timeBefore;
                }

                if (seenNumbers.TryGetValue(lastNumber, out (int lastTime, int timeBefore) value))
                    seenNumbers[lastNumber] = (turn, value.lastTime);
                else
                    seenNumbers[lastNumber] = (turn, turn);

                turn++;
            }

            Console.WriteLine($"Number spoken @ {countUpto} for [{string.Join(",", startingNumbers)}]: {lastNumber}");
        }
    }
}