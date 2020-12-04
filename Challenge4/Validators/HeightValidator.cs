using System.Text.RegularExpressions;

namespace Challenge4.Validators
{
    public class HeightValidator : IValidator<Passport>
    {
        private static string HeightPattern => "^(((1[5-8][0-9])|(19[0-3]))cm)$|^(((59|6[0-9]|7[0-6]))in)$";

        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.Height))
                return (false, "Height year was not set");

            if (!Regex.IsMatch(testable.Height, HeightPattern))
                return (false, $"Height was invalid: {testable.Height} - Should be 150cm - 193cm OR 59in - 76in");

            return (true, "Height is valid");
        }
    }
}