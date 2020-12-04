using System.Text.RegularExpressions;

namespace Challenge4.Validators
{
    public class HairColourValidator : IValidator<Passport>
    {
        private static string HairColourPattern => "^#[0-9a-f]{6}$";

        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.HairColour))
                return (false, "HairColour was not set");

            if (!Regex.IsMatch(testable.HairColour, HairColourPattern))
                return (false, $"HairColour was invalid: {testable.HairColour} - Should be #0-9a-f");

            return (true, "Height is valid");
        }
    }
}