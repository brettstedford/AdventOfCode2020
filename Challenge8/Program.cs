using System;

namespace Challenge8
{
    class Program
    {
        static void Main(string[] args)
        {
            var instructionSet = InstructionSet.LoadFrom("instruction-set.txt");
            Processor.Reset();

            while (!Processor.Looped && !Processor.Complete)
            {
                Processor.ProcessNextInstruction(instructionSet);
            }

            Console.WriteLine($"Accumulator when started looping: {Processor.Accumulator}");

            var fixIndexes = instructionSet.AllIndexesOf(new[] {"jmp", "nop"});

            foreach (var index in fixIndexes)
            {
                var fixedInstructionSet = InstructionSet.LoadFrom("instruction-set.txt");
                var instr = fixedInstructionSet.Instructions[index];
                instr.cmd = instr.cmd == "jmp" ? "nop" : "jmp";
                fixedInstructionSet.Instructions[index] = instr;

                Processor.Reset();

                while (!Processor.Looped && !Processor.Complete)
                {
                    Processor.ProcessNextInstruction(fixedInstructionSet);
                }

                if (Processor.Complete)
                    break;
            }

            Console.WriteLine($"Accumulator when started looping: {Processor.Accumulator}");
        }
    }
}