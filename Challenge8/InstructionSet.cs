using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge8
{
    public class InstructionSet
    {
        private (string, int)[] _instructions;

        private int _currentInstruction = 0;

        private InstructionSet()
        { }

        public static InstructionSet LoadFrom(string filename)
        {
            var stringInstructions = File.ReadAllLines(filename);

            var instructions = stringInstructions.Select(i =>
            {
                var command = Regex.Match(i, "[a-z]+").Value;
                var argument = int.Parse(Regex.Match(i, "[-|+][0-9]+").Value);

                return (command, argument);
            }).ToArray();

            return new InstructionSet
            {
                _instructions = instructions,
                _currentInstruction = 0
            };
        }

        public (string cmd, int arg) CurrentInstruction => _instructions[_currentInstruction];
        public int CurrentInstructionIndex => _currentInstruction;

        public bool OutOfInstructions => _currentInstruction >= _instructions.Length;

        public (string cmd, int arg)[] Instructions => _instructions; 

        public void Jump(int numberOfInstructions)
        {
            _currentInstruction += numberOfInstructions;
        }

        public int Accumulate()
        {
            var argument = CurrentInstruction.arg;
            _currentInstruction++;
            return argument;
        }

        public void NoOperation()
        {
            _currentInstruction++;
        }
    }
}
