using System;
using System.Collections.Generic;

namespace Challenge3
{
    class Program
    {
        private static (int x, int y) _startPoint = (0, 0);
        private static int _rightSteps = 3;
        private static int _downSteps = 1;

        // static void Main(string[] args)
        // {
        //     var landscape = Input.GetLandscapeSection();
        //     landscape = DuplicateLandscape(landscape, 50);
        //     TraverseLandscape(landscape);
        // }

        static void Main(string[] args)
        {
            IEnumerable<(int x, int y)> slopesVariations = new (int x, int y)[]
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };

            var multiplied = 1;

            foreach (var variation in slopesVariations)
            {
                var landscape = Input.GetLandscapeSection();
                landscape = DuplicateLandscape(landscape, 100);
                multiplied *= TraverseLandscape(landscape, variation);
            }

            Console.WriteLine($"Multiplied: {multiplied}");
        }

        static char[,] DuplicateLandscape(char[,] landscapeSection, int multiplier)
        {
            var ranks = landscapeSection.GetLength(1);
            var extrapolatedRanks = ranks * multiplier;
            var files = landscapeSection.GetLength(0);

            char[,] extrapolatedLandscape = new char[files, extrapolatedRanks];

            for (var f = 0; f < files; f++)
            {
                for (var m = 0; m < multiplier; m++)
                {
                    for (var r = 0; r < ranks; r++)
                    {
                        var extrapolatedRank = (m * ranks) + r;
                        extrapolatedLandscape[f, extrapolatedRank] = landscapeSection[f, r];
                    }
                }
            }

            return extrapolatedLandscape;
        }

        static int TraverseLandscape(char[,] landscape, (int right, int down) slopeVariation)
        {
            Console.WriteLine("Plotting course...");

            var currentLocation = _startPoint;
            (int x, int y) nextLocation = (_startPoint.x + slopeVariation.right, _startPoint.y + slopeVariation.down);

            var treesHit = 0;

            for (var f = 0; f < landscape.GetLength(0); f++)
            {
                for (int r = 0; r < landscape.GetLength(1); r++)
                {
                    if (f == nextLocation.y && r == nextLocation.x)
                    {
                        currentLocation = nextLocation;
                        nextLocation = (currentLocation.x + slopeVariation.right, currentLocation.y + slopeVariation.down);

                        var terrain = landscape[f, r] == '#' ? 'X' : 'O';
                        var isTree = terrain == 'X';

                        if (isTree)
                            treesHit++;

                        landscape[f, r] = terrain;
                        break;
                    }
                }
            }

            //PrintLandscape(landscape);
            Console.WriteLine($"Course plotted for r: {slopeVariation.right} / d: {slopeVariation.down}.");
            Console.WriteLine($"Hit {treesHit} trees on journey.");
            Output.ToFile(landscape, $"course_{slopeVariation.right}_{slopeVariation.down}.txt");
            return treesHit;
        }

        static void PrintLandscape(char[,] landscape)
        {
            for (var f = 0; f < landscape.GetLength(0); f++)
            {
                for (var r = 0; r < landscape.GetLength(1); r++)
                {
                    Console.Write(landscape[f, r]);
                }

                Console.WriteLine();
            }
        }
    }
}