namespace Challenge2
{
    public class PasswordPolicy
    {
        public string Password { get; }
        public Policy Policy { get; }

        public PasswordPolicy(string passwordPolicyAsString)
        {
            // regex if you want to be fancy
            var bits = passwordPolicyAsString.Split(":");
            Policy = new Policy(bits[0].Trim());
            Password = bits[1].Trim();
        }

        public bool Valid()
        {
            var chars = Password.ToCharArray();

            var lowestIndex = Policy.MinimumExpected - 1;
            var highestIndex = Policy.MaximumAllowed - 1;
            
            return (chars[lowestIndex] == Policy.ExpectedCharacter ||
                chars[highestIndex] == Policy.ExpectedCharacter) && 
                   !(chars[lowestIndex] == Policy.ExpectedCharacter &&
                     chars[highestIndex] == Policy.ExpectedCharacter);
        }
    }

    public class Policy
    {
        public int MinimumExpected { get; }
        public int MaximumAllowed { get; }
        public char ExpectedCharacter { get; }
        public string Display { get;  }
        
        public Policy(string policyAsString)
        {
            Display = policyAsString;
            var bits = policyAsString.Split(" ");
            MinimumExpected = int.Parse(bits[0].Split("-")[0]);
            MaximumAllowed = int.Parse(bits[0].Split("-")[1]);
            ExpectedCharacter = char.Parse(bits[1].Trim());
        }
    }
}