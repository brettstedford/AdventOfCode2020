using System;

namespace Challenge1
{
    public class Program
    {
        public static void Main()
        {
            for (var i = 0; i < Input.NumbersToAdd.Length; i++)
            {
                for (var j = i + 1; j < Input.NumbersToAdd.Length; j++)
                {
                    for (var k = j + 1; k < Input.NumbersToAdd.Length; k++)
                    {
                        var first = Input.NumbersToAdd[i];
                        var second = Input.NumbersToAdd[j];
                        var third = Input.NumbersToAdd[k];
                        
                        if (first + second + third == 2020)
                        {
                            var multiplied = first * second * third;
                            Console.WriteLine($"First: {first}");
                            Console.WriteLine($"Second: {second}");
                            Console.WriteLine($"Third: {third}");
                            Console.WriteLine($"Answer: {multiplied}");
                            return;
                        }
                    }
                }
            }
        }
    }
}