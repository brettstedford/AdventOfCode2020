using System.Text.RegularExpressions;

namespace Challenge12
{
    public class NavigationInstruction
    {
        public string Action { get; }

        public int Value { get; set; }
        private string _raw;
        public NavigationInstruction(string raw)
        {
            _raw = raw;
            var groups = Regex.Match(raw, "(^[NSEWLRF])([0-9]+)").Groups;
            Action = groups[1].Value;
            Value = int.Parse(groups[2].Value);
        }

        public override string ToString() => _raw;
    }
}