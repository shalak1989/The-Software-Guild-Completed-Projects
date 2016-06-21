using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableRockPaperScissors.Interfaces;

namespace TestableRockPaperScissors
{
    public class Game
    {
        private IChoiceSelector _myChoiceSelector;

        public Game(IChoiceSelector choiceSelector)
        {
            _myChoiceSelector = choiceSelector;
        }

        public MatchResult PlayRound(Choice userChoice)
        {
            var result = new MatchResult();
            result.UserChoice = userChoice;
            result.ComputerChoice = _myChoiceSelector.GetComputerChoice();


            if (result.ComputerChoice == result.UserChoice)
            {
                result.Result = GameResult.Tie;
                return result;
            }


            if (result.ComputerChoice == Choice.Rock && result.UserChoice == Choice.Scissors ||
                result.ComputerChoice == Choice.Scissors && result.UserChoice == Choice.Paper ||
                result.ComputerChoice == Choice.Paper && result.UserChoice == Choice.Rock)
            {
                result.Result = GameResult.Loss;
                return result;
            }

            result.Result = GameResult.Win;
            return result;
        }
    }
}
