using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestableRockPaperScissors.Implementations;

namespace TestableRockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Game game;

            Console.Write("(W)eighted mode, (R)andom mode, or (2) player mode? ");
            input = Console.ReadLine();

            if (input == "W")
                game = new Game(new WeightedRockPicker());
            else if (input == "2")
                game = new Game(new SecondPlayerPicker());
            else
                game = new Game(new RandomChoicePicker());

            do
            {
                Choice userChoice = GetUserChoice();
                var result = game.PlayRound(userChoice);

                ProcessResult(result);

                Console.Write("Press Q to quit: ");
                input = Console.ReadLine();
            } while (input != "Q");
        }

        private static void ProcessResult(MatchResult result)
        {
            Console.WriteLine("You picked {0}, the computer picked {1}", Enum.GetName(typeof(Choice), result.UserChoice),
                Enum.GetName(typeof(Choice), result.ComputerChoice));

            switch (result.Result)
            {
                case GameResult.Tie:
                    Console.WriteLine("You tied!");
                    break;
                case GameResult.Loss:
                    Console.WriteLine("You lose!");
                    break;
                default:
                    Console.WriteLine("You won!");
                    break;
            }
        }

        private static Choice GetUserChoice()
        {
            Console.Clear();
            Console.Write("Player 1: Enter a choice (R)ock, (P)aper, (S)cissors: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "P":
                    return Choice.Paper;
                case "S":
                    return Choice.Scissors;
                default:
                    return Choice.Rock;
            }
        }
    }
}
