namespace Challenge4.Validators
{
    public class BirthYearValidator : IValidator<Passport>
    {
        private static string HeightPattern => "^(((1[5-8][0-9])|(19[0-3]))cm)$|^(((59|6[0-9]|7[0-6]))in)$";

        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.BirthYear))
                return (false, "Birth year was not set");

            if (int.TryParse(testable.BirthYear, out var birthYear))
            {
                if (!(birthYear >= 1920 && birthYear <= 2002))
                    return (false, $"Birth year was out of bounds: {birthYear} - Should be 1920 - 2002");
            }
            else return (false, $"Birth year was invalid: {testable.BirthYear}");

            return (true, "Birth year is valid");
        }
    }
}