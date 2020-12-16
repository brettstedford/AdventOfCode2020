using System.Collections.Generic;
using System.Linq;

namespace Challenge16
{
    public class Ticket
    {
        public int[] Values { get; }

        public Ticket(string raw)
        {
            Values = raw.Split(',').Select(int.Parse).ToArray();
        }

        public IEnumerable<int> GetInvalidValues(IEnumerable<Rule> rules)
        {
            for (var i = 0; i < Values.Length; i++)
            {
                var value = Values[i];

                var validValues = rules.SelectMany(r => r.ValidValues).Distinct();

                if (!validValues.Contains(value))
                    yield return value;
            }
        }
    }
}