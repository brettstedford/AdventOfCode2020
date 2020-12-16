using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge16
{
    public class Rule
    {
        public string Name { get; }
        public List<string> Values { get; } = new List<string>();

        public IEnumerable<int> ValidValues
        {
            get
            {
                foreach (var value in Values)
                {
                    var range = value.Split('-');

                    var start = int.Parse(range[0]);
                    var count = int.Parse(range[1]) - start;

                    foreach (var num in Enumerable.Range(start, count+1))
                        yield return num;
                }
            }
        }

        public Rule(string raw)
        {
            var elements = raw.Split(':');
            Name = elements[0].Trim();
            Values.AddRange(elements[1].Split("or").Select(e => e.Trim()));
        }
    }
}