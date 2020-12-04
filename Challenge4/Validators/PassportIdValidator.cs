using System.Text.RegularExpressions;

namespace Challenge4.Validators
{
    public class PassportIdValidator : IValidator<Passport>
    {
        private static string PassportIdPattern => "^[0-9]{9}$";

        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.PassportId))
                return (false, "PassportId was not set");

            if (!Regex.IsMatch(testable.PassportId, PassportIdPattern))
                return (false, $"PassportId was invalid: {testable.PassportId} - Should be nine digits");

            return (true, "PassportId is valid");
        }
    }
}