using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge11
{
    class Program
    {
        static void Main(string[] args)
        {
            var seatingPlan = Input
                //.GetSeatingPlanFrom("test-seating-plan.txt");
                .GetSeatingPlanFrom("seating-plan.txt");
            //PrintSeatingPlan(seatingPlan);

            (bool someoneMoved, char[,] newSeatingPlan, int seatsOccupied) = PredictSeating(seatingPlan);
            //PrintSeatingPlan(newSeatingPlan);
            Console.WriteLine($"Someone moved: {someoneMoved}");
            Console.WriteLine($"Seats occupied: {seatsOccupied}");
            Console.WriteLine();

            while (someoneMoved)
            {
                (someoneMoved, newSeatingPlan, seatsOccupied) = PredictSeating(newSeatingPlan);
                //PrintSeatingPlan(newSeatingPlan);
                Console.WriteLine($"Someone moved: {someoneMoved}");
                Console.WriteLine($"Seats occupied: {seatsOccupied}");
                Console.WriteLine();
            }
        }

        private static (bool, char[,], int) PredictSeating(char[,] seatingPlan)
        {
            var snapshot = (char[,]) seatingPlan.Clone();
            var updatedSeatingPlan = seatingPlan;
            var someoneMoved = false;
            var seatsOccupied = 0;

            for (var y = 0; y < seatingPlan.GetLength(0); y++)
            {
                for (var x = 0; x < seatingPlan.GetLength(1); x++)
                {
                    var floorItem = snapshot[y, x];

                    if (floorItem == '.')
                        continue;

                    var firstVisibleSeats = GetFirstVisibleSeatsIn(snapshot, (x, y)).ToList();
                    
                    if (floorItem == 'L' && firstVisibleSeats.All(s => s == 'L'))
                    {
                        floorItem = '#';
                        someoneMoved = true;
                    } else if (floorItem == '#' && firstVisibleSeats.Count(s => s == '#') >= 5)
                    {
                        floorItem = 'L';
                        someoneMoved = true;
                    }
                    
                    updatedSeatingPlan[y, x] = floorItem;

                    if (floorItem == '#')
                        seatsOccupied++;
                }
            }

            return (someoneMoved, updatedSeatingPlan, seatsOccupied);
        }

        private static IEnumerable<char> GetFirstVisibleSeatsIn(char[,] seatingPlan, (int x, int y) seatingPosition)
        {
            var lookAbove = seatingPosition.y > 0;
            var lookBelow = seatingPosition.y < seatingPlan.GetLength(0) - 1;
            var lookLeft = seatingPosition.x > 0;
            var lookRight = seatingPosition.x < seatingPlan.GetLength(1) - 1;

            var firstVisibleSeats = new List<char>();

            if (lookAbove)
            {
                var abovePosition = seatingPlan[seatingPosition.y - 1, seatingPosition.x];

                if (abovePosition == '.')
                {
                    int incr = 2;

                    while (abovePosition == '.' && seatingPosition.y - incr >= 0)
                    {
                        abovePosition = seatingPlan[seatingPosition.y - incr, seatingPosition.x];

                        if (abovePosition != '.')
                        {
                            firstVisibleSeats.Add(abovePosition);
                            break;
                        }

                        incr++;
                    }
                }
                else
                {
                    firstVisibleSeats.Add(abovePosition);
                }

                if (lookLeft)
                {
                    var aboveLeftPosition = seatingPlan[seatingPosition.y - 1, seatingPosition.x - 1];

                    if (aboveLeftPosition == '.')
                    {
                        int incr = 2;

                        while (aboveLeftPosition == '.' && seatingPosition.x - incr >= 0 && seatingPosition.y - incr >= 0)
                        {
                            aboveLeftPosition = seatingPlan[seatingPosition.y - incr, seatingPosition.x - incr];

                            if (aboveLeftPosition != '.')
                            {
                                firstVisibleSeats.Add(aboveLeftPosition);
                                break;
                            }
                            
                            incr++;
                        }
                    }
                    else
                    {
                        firstVisibleSeats.Add(aboveLeftPosition);
                    }
                }

                if (lookRight)
                {
                    var aboveRightPosition = seatingPlan[seatingPosition.y - 1, seatingPosition.x + 1];

                    if (aboveRightPosition == '.')
                    {
                        int incr = 2;

                        while (aboveRightPosition == '.' && seatingPosition.x + incr <= seatingPlan.GetLength(1) - 1 && seatingPosition.y - incr >= 0)
                        {
                            aboveRightPosition = seatingPlan[seatingPosition.y - incr, seatingPosition.x + incr];

                            if (aboveRightPosition != '.')
                            {
                                firstVisibleSeats.Add(aboveRightPosition);
                                break;
                            }
                            
                            incr++;
                        }
                    }
                    else
                    {
                        firstVisibleSeats.Add(aboveRightPosition);
                    }
                }
            }

            if (lookLeft)
            {
                var leftPosition = seatingPlan[seatingPosition.y, seatingPosition.x - 1];

                if (leftPosition == '.')
                {
                    int incr = 2;

                    while (leftPosition == '.' && seatingPosition.x - incr >= 0)
                    {
                        leftPosition = seatingPlan[seatingPosition.y, seatingPosition.x - incr];

                        if (leftPosition != '.')
                        {
                            firstVisibleSeats.Add(leftPosition);
                            break;
                        }

                        incr++;
                    }
                }
                else
                {
                    firstVisibleSeats.Add(leftPosition);
                }
            }

            if (lookRight)
            {
                var rightPosition = seatingPlan[seatingPosition.y, seatingPosition.x + 1];
                if (rightPosition == '.')
                {
                    int incr = 2;

                    while (rightPosition == '.' && seatingPosition.x + incr <= seatingPlan.GetLength(1) - 1)
                    {
                        rightPosition = seatingPlan[seatingPosition.y, seatingPosition.x + incr];

                        if (rightPosition != '.')
                        {
                            firstVisibleSeats.Add(rightPosition);
                            break;
                        }

                        incr++;
                    }
                }
                else
                {
                    firstVisibleSeats.Add(rightPosition);
                }
            }

            if (lookBelow)
            {
                var belowPosition = seatingPlan[seatingPosition.y + 1, seatingPosition.x];

                if (belowPosition == '.')
                {
                    int incr = 2;

                    while (belowPosition == '.' && seatingPosition.y + incr <= seatingPlan.GetLength(0) - 1)
                    {
                        belowPosition = seatingPlan[seatingPosition.y + incr, seatingPosition.x];

                        if (belowPosition != '.')
                        {
                            firstVisibleSeats.Add(belowPosition);
                            break;
                        }

                        incr++;
                    }
                }
                else
                {
                    firstVisibleSeats.Add(belowPosition);
                }

                if (lookLeft)
                {
                    var belowLeftPosition = seatingPlan[seatingPosition.y + 1, seatingPosition.x - 1];

                    if (belowLeftPosition == '.')
                    {
                        int incr = 2;

                        while (belowLeftPosition == '.' && seatingPosition.x - incr >= 0 && seatingPosition.y + incr <= seatingPlan.GetLength(0) - 1)
                        {
                            belowLeftPosition = seatingPlan[seatingPosition.y + incr, seatingPosition.x - incr];

                            if (belowLeftPosition != '.')
                            {
                                firstVisibleSeats.Add(belowLeftPosition);
                                break;
                            }

                            incr++;
                        }
                    }
                    else
                    {
                        firstVisibleSeats.Add(belowLeftPosition);
                    }
                }

                if (lookRight)
                {
                    var belowRightPosition = seatingPlan[seatingPosition.y + 1, seatingPosition.x + 1];

                    if (belowRightPosition == '.')
                    {
                        int incr = 2;

                        while (belowRightPosition == '.' && seatingPosition.x + incr <= seatingPlan.GetLength(1) - 1 && seatingPosition.y + incr <= seatingPlan.GetLength(0) - 1)
                        {
                            belowRightPosition = seatingPlan[seatingPosition.y + incr, seatingPosition.x + incr];

                            if (belowRightPosition != '.')
                            {
                                firstVisibleSeats.Add(belowRightPosition);
                                break;
                            }
                            
                            incr++;
                        }
                    }
                    else
                    {
                        firstVisibleSeats.Add(belowRightPosition);
                    }
                }
            }

            return firstVisibleSeats;
        }
        
        
        private static IEnumerable<char> GetAdjacentOccupiedSeatsIn(char[,] seatingPlan, (int x, int y) seatingPosition)
        {
            var lookAbove = seatingPosition.y > 0;
            var lookBelow = seatingPosition.y < seatingPlan.GetLength(0) - 1;
            var lookLeft = seatingPosition.x > 0;
            var lookRight = seatingPosition.x < seatingPlan.GetLength(1) - 1;

            var adjacentSeats = new List<char>();

            if (lookAbove)
            {
                var abovePosition = seatingPlan[seatingPosition.y - 1, seatingPosition.x];
                if (abovePosition == '#')
                    adjacentSeats.Add(abovePosition);
                
                if (lookLeft)
                {
                    var aboveLeftPosition = seatingPlan[seatingPosition.y - 1, seatingPosition.x - 1];
                    if (aboveLeftPosition == '#')
                     adjacentSeats.Add(aboveLeftPosition);
                }

                if (lookRight)
                {
                    var aboveRightPosition = seatingPlan[seatingPosition.y - 1, seatingPosition.x + 1];
                    if (aboveRightPosition == '#')
                        adjacentSeats.Add(aboveRightPosition);
                }
            }

            if (lookLeft)
            {
                var leftPosition = seatingPlan[seatingPosition.y, seatingPosition.x - 1];
                if (leftPosition == '#')
                    adjacentSeats.Add(leftPosition);
            }

            if (lookRight)
            {
                var rightPosition = seatingPlan[seatingPosition.y, seatingPosition.x + 1];
                if (rightPosition == '#')
                    adjacentSeats.Add(rightPosition);
            }

            if (lookBelow)
            {
                var belowPosition = seatingPlan[seatingPosition.y + 1, seatingPosition.x];
                if (belowPosition == '#')
                    adjacentSeats.Add(belowPosition);
                
                if (lookLeft)
                {
                    var belowLeftPosition = seatingPlan[seatingPosition.y + 1, seatingPosition.x - 1];
                    if (belowLeftPosition == '#')
                        adjacentSeats.Add(belowLeftPosition);
                }

                if (lookRight)
                {
                    var belowRightPosition = seatingPlan[seatingPosition.y + 1, seatingPosition.x + 1];
                    if (belowRightPosition == '#')
                        adjacentSeats.Add(belowRightPosition);
                }
            }

            return adjacentSeats;
        }

        static void PrintSeatingPlan(char[,] seatingPlan)
        {
            for (var f = 0; f < seatingPlan.GetLength(0); f++)
            {
                for (var r = 0; r < seatingPlan.GetLength(1); r++)
                {
                    Console.Write(seatingPlan[f, r]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}