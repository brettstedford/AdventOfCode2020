using System.Text.RegularExpressions;

namespace Challenge14
{
    public class UpdateMask : IInstruction
    {
        private readonly char[] _newMask;

        public UpdateMask(string instructionText)
        {
            var newMask = Regex.Match(instructionText, "[01X]{36}").Value;
            _newMask = newMask.ToCharArray();
        }

        public void Execute(Memory memory)
        {
            memory.UpdateMask(_newMask);
        }
    }
}