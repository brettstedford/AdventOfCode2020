using System;

namespace Challenge12
{
    public class PartTwoFerry
    {
        private (int easting, int northing) _waypoint;
        public int Northing { get; private set; }
        public int Easting { get; private set; }

        public int ManhattanDistance => Math.Abs(Easting) + Math.Abs(Northing);

        public PartTwoFerry()
        {
            _waypoint = (10, 1);
        }

        private void RotateAntiClockwise(int times)
        {
            for (var i = 0; i < times; i++)
            {
                var easting = _waypoint.easting;
                var northing = _waypoint.northing;
                _waypoint.easting =  northing*-1;
                _waypoint.northing = easting;
            }
        }

        private void RotateClockwise(int times)
        {
            for (var i = 0; i < times; i++)
            {
                var easting = _waypoint.easting;
                var northing = _waypoint.northing;
                _waypoint.easting = northing;
                _waypoint.northing = easting*-1;
            }
        }

        private void MoveToWaypoint(int times)
        {
            for (var i = 0; i < times; i++)
            {
                Easting += _waypoint.easting;
                Northing += _waypoint.northing;
            }
        }

        public void Navigate(NavigationInstruction instruction)
        {
            switch (instruction.Action)
            {
                case "N":
                    _waypoint.northing += instruction.Value;
                    break;
                case "S":
                    _waypoint.northing -= instruction.Value;
                    break;
                case "E":
                    _waypoint.easting += instruction.Value;
                    break;
                case "W":
                    _waypoint.easting -= instruction.Value;
                    break;
                case "L":
                    RotateAntiClockwise(instruction.Value / 90);
                    break;
                case "R":
                    RotateClockwise(instruction.Value / 90);
                    break;
                case "F":
                    MoveToWaypoint(instruction.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instruction.Action), instruction.Action, "Unknown instruction action");
            }
        }
    }
}