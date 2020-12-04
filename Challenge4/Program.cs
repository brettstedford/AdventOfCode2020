using Challenge4.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge4
{
    class Program
    {
        private static readonly ICollection<IValidator<Passport>> Validators = new List<IValidator<Passport>>
        {
            new BirthYearValidator(),
            new IssueYearValidator(),
            new ExpirationYearValidator(),
            new HeightValidator(),
            new EyeColourValidator(),
            new HairColourValidator(),
            new PassportIdValidator()
        };

        static void Main(string[] args)
        {
            var passports = Input
                //.GetValidTestPassports();
                //.GetInvalidTestPassports();
                .GetPassportsFrom("passport-input.txt");

            var validPassports = 0;

            passports.ForEach(passport =>
            {
                if (Validators.All(v => v.Validate(passport).valid))
                    validPassports++;
            });

            Console.WriteLine($"Passports checked: {passports.Count}");
            Console.WriteLine($"Valid passports: {validPassports}");
        }
    }
}