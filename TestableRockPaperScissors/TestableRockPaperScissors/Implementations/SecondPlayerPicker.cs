using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableRockPaperScissors.Interfaces;

namespace TestableRockPaperScissors.Implementations
{   

    public class SecondPlayerPicker : IChoiceSelector
    {
        public Choice GetComputerChoice()
        {
            Console.Clear();
            Console.WriteLine("Enter Choice: (R)ock, (P)aper or (S)cissors");
            var input = Console.ReadLine();

            if (input == "R")
                return Choice.Rock;
            else if (input == "P")
                return Choice.Paper;
            else
                return Choice.Scissors;
        }
        
    }
}
