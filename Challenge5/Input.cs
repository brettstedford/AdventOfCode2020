using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Challenge5
{
    public static class Input
    {
        public static IEnumerable<BoardingPass> GetBoardingPassesFrom(string fileName)
        {
            return File
                .ReadAllLines(fileName)
                .Select(bsp => new BoardingPass(bsp));
        }
    }
}