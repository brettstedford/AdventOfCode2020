using System;
using System.Linq;

namespace Challenge4
{
    public class Passport
    {
        public string BirthYear { get; private set; }
        public string IssueYear { get; private set; }
        public string ExpirationYear { get; private set; }
        public string Height { get; private set; }
        public string HairColour { get; private set; }
        public string EyeColour { get; private set; }
        public string PassportId { get; private set; }
        public string CountryId { get; private set; }
        public string Raw { get; }

        public Passport(string passportDataAsString)
        {
            Raw = passportDataAsString;
            ParseRaw(passportDataAsString);
        }

        private void ParseRaw(string passportDataAsString)
        {
            var parts = passportDataAsString
                .Trim()
                .Split(Input.NewLine)
                .SelectMany(l => l.Split(Input.Whitespace))
                .ToList();

            foreach (var part in parts)
            {
                var propertyParts = part.Split(":");
                var property = propertyParts[0].Trim();
                var value = propertyParts[1].Trim();

                if (propertyParts.Length != 2)
                    continue;

                switch (property)
                {
                    case "byr":
                        BirthYear = value;
                        break;
                    case "iyr":
                        IssueYear = value;
                        break;
                    case "eyr":
                        ExpirationYear = value;
                        break;
                    case "hgt":
                        Height = value;
                        break;
                    case "hcl":
                        HairColour = value;
                        break;
                    case "ecl":
                        EyeColour = value;
                        break;
                    case "pid":
                        PassportId = value;
                        break;
                    case "cid":
                        CountryId = value;
                        break;
                    default:
                        throw new ApplicationException("Unknown property");
                }
            }
        }
    }
}