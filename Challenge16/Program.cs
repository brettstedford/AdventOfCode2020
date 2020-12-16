using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge16
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "ticket-data.txt";
            
            var rules = Input.GetRulesFrom(filename).ToList();
            var nearbyTickets = Input.GetNearbyTicketsFrom(filename).ToList();
            
            var invalidValues = new List<int>();

            foreach (var ticket in nearbyTickets)
            {
                invalidValues.AddRange(ticket.GetInvalidValues(rules));
            }

            Console.WriteLine($"Ticket Scanning Error Rate: {invalidValues.Sum()}");
        }
    }
}