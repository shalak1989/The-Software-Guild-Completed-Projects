using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableRockPaperScissors;
using TestableRockPaperScissors.Interfaces;

namespace TestableRockPaperScissors.Implementations
{
    public class RandomChoicePicker : IChoiceSelector
    {
        private Random _rng = new Random();

        public Choice GetComputerChoice()
        {
            int i = _rng.Next(0, 3);
            switch (i)
            {
                case 0:
                    return Choice.Rock;
                case 1:
                    return Choice.Paper;
                default:
                    return Choice.Scissors;
            }
        }
    }
}
