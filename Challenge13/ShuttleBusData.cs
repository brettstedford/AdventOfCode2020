using System.Collections.Generic;
using System.Linq;

namespace Challenge13
{
    public sealed class ShuttleBusData
    {
        public int EarliestEstimatedDepartureTimestamp { get; }
        public IEnumerable<string> ShuttleBuses { get; }

        public ShuttleBusData(string raw)
        {
            var elements = raw.Split("\n");

            EarliestEstimatedDepartureTimestamp = int.Parse(elements[0]);

            ShuttleBuses = elements[1]
                .Split(",");
        }

        public int GetBusToCatch()
        {
            (int bus, int departureTime) earliest = (0, 0);
            var activeBuses = ShuttleBuses
                .Where(b => int.TryParse(b, out _))
                .Select(int.Parse);

            foreach (var bus in activeBuses)
            {
                var x = EarliestEstimatedDepartureTimestamp + bus;
                var y = x % bus;
                var z = x - y;

                if (earliest.bus == 0 && earliest.departureTime == 0 || z < earliest.departureTime)
                {
                    earliest.bus = bus;
                    earliest.departureTime = z;
                }
            }

            return earliest.bus * (earliest.departureTime - EarliestEstimatedDepartureTimestamp);
        }

        public long GetEarliestTimestamp_BruteForce()
        {
            long t = 0;
            var buses = ShuttleBuses.ToList();
            var firstBus = int.Parse(buses[0]);
            var lastBusIndex = buses.FindLastIndex(b => int.TryParse(b, out _));
            var lastBus = int.Parse(buses[lastBusIndex]);

            var highestBus = buses.Where(b => int.TryParse(b, out _)).Select(int.Parse).Max();

            var done = false;

            while (!done)
            {
                t += highestBus;

                if (t % firstBus == 0 && (t + lastBusIndex) % lastBus == 0)
                {
                    for (var i = 1; i <= lastBusIndex; i++)
                    {
                        if (i == lastBusIndex)
                        {
                            done = true;
                            break;
                        }

                        var nextBusString = buses[i];

                        if (int.TryParse(nextBusString, out var nextBus))
                        {
                            if ((t + i) % nextBus != 0)
                            {
                                i = lastBusIndex + 1;
                            }
                        }
                    }
                }
            }

            return t;
        }
    }
}