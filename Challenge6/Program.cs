using System;
using System.Linq;

namespace Challenge6
{
    class Program
    {
        static void Main(string[] args)
        {
            var forms = Input.GetDeclarationFormsFrom("declaration-forms.txt");

            var summedYesResults = forms.Sum(f => f.ResultsAllAnswered.Count());
            
            Console.WriteLine($"All Yes Answered Results: {summedYesResults}");
        }
    }
}