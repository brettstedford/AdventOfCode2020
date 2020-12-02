using System;

namespace Challenge2
{
    public class Program
    {
        public static void Main()
        {
            int validPasswords = 0;
            
            foreach (var ppas in Input.RealPasswordPoliciesAsStrings)
            {
                var pp = new PasswordPolicy(ppas);

                var result = "INVALID";

                if (pp.Valid())
                {
                    result = "VALID";
                    validPasswords++;
                }

                Console.WriteLine($"{pp.Password} - {pp.Policy.Display} - {result}");
            }
            
            Console.WriteLine($"# Valid Password: {validPasswords}");
        }
    }
}