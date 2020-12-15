using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge14
{
    public class UpdateMemoryAddress : IInstruction
    {
        private int[] _value;
        private int _address;

        public UpdateMemoryAddress(string instructionText)
        {
            var matches = Regex.Matches(instructionText, "(\\[[0-9]+\\])|([0-9]+$)");
            _address = int.Parse(matches[0].Value.TrimStart('[').TrimEnd(']'));
            var decimalValue = int.Parse(matches[1].Value);
            _value = Convert.ToString(decimalValue, 2)
                .PadLeft(36, '0')
                .ToCharArray()
                .Select(c => int.Parse(c.ToString())).ToArray();
        }

        public void Execute(Memory memory)
        {
            memory.UpdateAddress(_address, _value);
        }
    }
}