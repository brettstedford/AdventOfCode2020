using System;
using System.Collections.Generic;

namespace Challenge12
{
    public class PartOneFerry
    {
        public string Direction { get; private set; }
        public int Northing { get; private set; }
        public int Easting { get; private set; }

        public int ManhattanDistance => Math.Abs(Easting) + Math.Abs(Northing);

        public PartOneFerry()
        {
            Direction = "E";
        }

        private List<string> Compass = new List<string> {"N", "E", "S", "W"};

        private void RotateAntiClockwise(int times)
        {
            var currentIndex = Compass.IndexOf(Direction);
            
            for (var i = 0; i < times; i++)
            {
                if (currentIndex == 0)
                {
                    currentIndex = Compass.Count - 1;
                }
                else
                {
                    currentIndex--;
                }
            }

            Direction = Compass[currentIndex];
        }

        private void RotateClockwise(int times)
        {
            var currentIndex = Compass.IndexOf(Direction);
            
            for (var i = 0; i < times; i++)
            {
                if (currentIndex == Compass.Count - 1)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }
            }

            Direction = Compass[currentIndex];
        }

        private void MoveInDirection(int distance)
        {
            switch (Direction)
            {
                case "N":
                    Northing += distance;    
                    break;
                case "E":
                    Easting += distance;
                    break;
                case "S":
                    Northing -= distance;
                    break;
                case "W":
                    Easting -= distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Direction), Direction, "Unknown direction");
            }
        }
        
        public void Navigate(NavigationInstruction instruction)
        {
            switch (instruction.Action)
            {
                case "N":
                    Northing += instruction.Value;
                    break;
                case "S":
                    Northing -= instruction.Value;
                    break;
                case "E":
                    Easting += instruction.Value;
                    break;
                case "W":
                    Easting -= instruction.Value;
                    break;
                case "L":
                    RotateAntiClockwise(instruction.Value / 90);
                    break;
                case "R":
                    RotateClockwise(instruction.Value / 90);
                    break;
                case "F":
                    MoveInDirection(instruction.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instruction.Action), instruction.Action, "Unknown instruction action");
            }
        }
    }
}