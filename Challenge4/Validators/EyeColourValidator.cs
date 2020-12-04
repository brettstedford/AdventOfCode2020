using System.Text.RegularExpressions;

namespace Challenge4.Validators
{
    public class EyeColourValidator : IValidator<Passport>
    {
        private static string EyeColourPattern => "^(amb|blu|brn|gry|grn|hzl|oth)$";

        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.EyeColour))
                return (false, "EyeColour was not set");

            if (!Regex.IsMatch(testable.EyeColour, EyeColourPattern))
                return (false, $"EyeColour was invalid: {testable.EyeColour} - Should be [amb, blu, brn, gry, grn, hzl, oth]");

            return (true, "Height is valid");
        }
    }
}