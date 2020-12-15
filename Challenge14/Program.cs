using System;
using System.Linq;

namespace Challenge14
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructions = Input.GetFromFile("memory-instructions.txt").ToList();
            
            var memory = new Memory();
            instructions.ForEach(i => i.Execute(memory));
            Console.WriteLine($"Summed address values: {memory.DecimalAddresses.Sum(kvp => kvp.Value)}");
            
            var memoryV2 = new MemoryV2();
            instructions.ForEach(i => i.Execute(memoryV2));
            Console.WriteLine($"Summed address values: {memoryV2.DecimalAddresses.Sum(kvp => kvp.Value)}");
        }
    }
}