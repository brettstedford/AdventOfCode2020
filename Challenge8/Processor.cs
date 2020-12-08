using System.Collections.Generic;
using System.Linq;

namespace Challenge8
{
    public static class Processor
    {
        public static bool Looped { get; private set; } = false;
        public static bool Complete { get; private set; } = false;
        private static List<(string cmd, int arg)> _processedCommands = new List<(string cmd, int arg)>();
        private static List<int> _processedCommandIndexes = new List<int>();

        public static int Accumulator { get; private set; }

        public static void Reset()
        {
            Looped = false;
            Complete = false;
            _processedCommands = new List<(string cmd, int arg)>();
            _processedCommandIndexes = new List<int>();
            Accumulator = 0;
        }
        
        public static void ProcessNextInstruction(InstructionSet instructionSet)
        {
            if (instructionSet.OutOfInstructions)
            {
                Complete = true;
                return;
            }
            
            var currentInstruction = instructionSet.CurrentInstruction;

            if(_processedCommandIndexes.Contains(instructionSet.CurrentInstructionIndex))
            {
                Looped = true;
                return;
            }

            _processedCommands.Add(currentInstruction);
            _processedCommandIndexes.Add(instructionSet.CurrentInstructionIndex);

            switch (currentInstruction.cmd)
            {
                case "acc":
                    Accumulator += instructionSet.Accumulate();
                    break;
                case "jmp":
                    instructionSet.Jump(currentInstruction.arg);
                    break;
                case "nop":
                default:
                    instructionSet.NoOperation();
                    break;
            }
        }
    }
}