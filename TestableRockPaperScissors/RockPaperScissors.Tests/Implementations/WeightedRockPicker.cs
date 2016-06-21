using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableRockPaperScissors;
using TestableRockPaperScissors.Interfaces;

namespace RockPaperScissors.Tests.Implementations
{
    public class WeightedRockPicker : IChoiceSelector
    {
        private Random _rng = new Random();

        public Choice GetComputerChoice()
        {
            int i = _rng.Next(1, 101);

            if (i <= 70)
                return Choice.Rock;
            if (i <= 90)
                return Choice.Scissors;

            return Choice.Paper;
        }
    }
}
