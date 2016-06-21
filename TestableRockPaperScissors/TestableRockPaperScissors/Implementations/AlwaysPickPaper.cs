using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableRockPaperScissors;
using TestableRockPaperScissors.Interfaces;

namespace TestableRockPaperScissors.Implementations
{
    public class AlwaysPickPaper : IChoiceSelector
    {
        public Choice GetComputerChoice()
        {
            return Choice.Paper;
        }
    }
}
