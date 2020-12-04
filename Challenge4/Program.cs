using System;

namespace Challenge4
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = Input
                //.GetInvalidTestPassports();
                //.GetValidTestPassports();
                .GetPassportsFrom("passport-input.txt");

            var validPassports = 0;
            var invalidPassports = 0;
            
            passports.ForEach(pp =>
            {
                var result = pp.IsValid();

                if (result.valid)
                {
                    validPassports++;
                }
                else
                {
                    invalidPassports++;
                    Console.WriteLine(pp.Raw);
                    Console.WriteLine();
                    Console.WriteLine(result.reason);
                    Console.WriteLine("----------------------");
                }
            });

            Console.WriteLine($"Passports checked: {passports.Count}");
            Console.WriteLine($"Valid passports: {validPassports}");
            Console.WriteLine($"Invalid passports: {invalidPassports}");
            Console.WriteLine($"Total: {validPassports + invalidPassports}");
        }
    }
}