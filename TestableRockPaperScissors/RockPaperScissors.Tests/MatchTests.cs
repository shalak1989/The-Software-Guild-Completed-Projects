using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RockPaperScissors.Tests.Implementations;
using TestableRockPaperScissors;

namespace RockPaperScissors.Tests
{
    [TestFixture]
    public class MatchTests
    {
        [Test]
        public void PaperBeatsRock()
        {
            var userChoice = Choice.Rock;
            var g = new Game(new AlwaysPickPaper());

            var result = g.PlayRound(userChoice);

            Assert.AreEqual(result.Result, GameResult.Loss);
        }
    }
}
