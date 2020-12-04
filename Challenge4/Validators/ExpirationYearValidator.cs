namespace Challenge4.Validators
{
    public class ExpirationYearValidator : IValidator<Passport>
    {
        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.ExpirationYear))
                return (false, "Expiration year was not set");

            if (int.TryParse(testable.ExpirationYear, out var expYear))
            {
                if (!(expYear >= 2020 && expYear <= 2030))
                    return (false, $"Expiration year was out of bounds: {expYear} - Should be 2020 - 2030");
            }
            else return (false, $"Expiration year was invalid: {testable.ExpirationYear}");

            return (true, "Expiration year is valid");
        }
    }
}