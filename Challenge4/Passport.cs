using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        public (bool valid, string reason) IsValid()
        {
            if (string.IsNullOrEmpty(BirthYear))
                return (false, "Birth year was not set");

            if (int.TryParse(BirthYear, out var birthYear))
            {
                if (birthYear < 1920 || birthYear > 2002)
                    return (false, $"Birth year was out of bounds: {birthYear} - Should be 1920 - 2002");
            }
            else return (false, $"Birth year was invalid: {BirthYear}");

            if (string.IsNullOrEmpty(IssueYear))
                return (false, "Issue year was not set");

            if (int.TryParse(IssueYear, out var issueYear))
            {
                if (issueYear < 2010 || issueYear > 2020)
                    return (false, $"Issue year was out of bounds: {issueYear} - Should be 2010 - 2020");
            }
            else return (false, $"Issue year was invalid: {IssueYear}");

            if (string.IsNullOrEmpty(ExpirationYear))
                return (false, "Expiration year was not set");

            if (int.TryParse(ExpirationYear, out var expYear))
            {
                if (expYear < 2020 || expYear > 2030)
                    return (false, $"Expiration year was out of bounds: {expYear} - Should be 2020 - 2030");
            }
            else return (false, $"Expiration year was invalid: {ExpirationYear}");

            if (string.IsNullOrEmpty(Height))
                return (false, "Height year was not set");

            var hgtPattern = "^(((1[5-8][0-9])|(19[0-3]))cm)|(((59|6[0-9]|7[0-6]))in)$";
            if (!Regex.IsMatch(Height, hgtPattern))
                return (false, $"Height was invalid: {Height} - Should be 150cm - 193cm OR 59in - 76in");

            if (string.IsNullOrEmpty(HairColour))
                return (false, "HairColour was not set");

            var hclPattern = "^#[0-9a-f]{6}$";
            if (!Regex.IsMatch(HairColour, hclPattern))
                return (false, $"HairColour was invalid: {HairColour} - Should be #0-9a-f");

            if (string.IsNullOrEmpty(EyeColour))
                return (false, "EyeColour was not set");

            var eclPattern = "^(amb|blu|brn|gry|grn|hzl|oth)$";
            if (!Regex.IsMatch(EyeColour, eclPattern))
                return (false, $"EyeColour was invalid: {EyeColour} - Should be [amb, blu, brn, gry, grn, hzl, oth]");

            if (string.IsNullOrEmpty(PassportId))
                return (false, "PassportId was not set");

            var pidPattern = "^[0-9]{9}$";
            if (!Regex.IsMatch(PassportId, pidPattern))
                return (false, $"PassportId was invalid: {PassportId} - Should be nine digits");

            return (true, "Everything looks great");
        }
    }
}