namespace Challenge4.Validators
{
    public class IssueYearValidator : IValidator<Passport>
    {
        public (bool valid, string reason) Validate(Passport testable)
        {
            if (string.IsNullOrEmpty(testable.IssueYear))
                return (false, "Issue year was not set");

            if (int.TryParse(testable.IssueYear, out var issueYear))
            {
                if (!(issueYear >= 2010 && issueYear <= 2020))
                    return (false, $"Issue year was out of bounds: {issueYear} - Should be 2010 - 2020");
            }
            else return (false, $"Issue year was invalid: {testable.IssueYear}");
            
            return (true, "Issue year is valid");
        }
    }
}