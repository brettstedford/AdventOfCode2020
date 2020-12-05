using Challenge5;
using NUnit.Framework;

namespace ChallengeTests
{
    public class Challenge5_Tests
    {
        [TestCase("FBFBBFFRLR", 44, 5, 357)]
        [TestCase("BFFFBBFRRR", 70, 7, 567)]
        [TestCase("FFFBBBFRRR", 14, 7, 119)]
        [TestCase("BBFFBBFRLL", 102, 4, 820)]
        public void ParseBoardingPasses(string bpCode, int row, int col, int seat)
        {
            var bp = new BoardingPass(bpCode);
            Assert.AreEqual(row, bp.Row);
            Assert.AreEqual(col, bp.Column);
            Assert.AreEqual(seat, bp.SeatNumber);
        }
    }
}