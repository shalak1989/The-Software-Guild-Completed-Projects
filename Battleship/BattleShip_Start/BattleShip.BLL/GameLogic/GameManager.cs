using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL.GameLogic
{
    public class GameManager
    {
        Board b1 = new Board();
        Board b2 = new Board();
        string player1Name;
        string player2Name;


        GameSetup setPlayer = new GameSetup();

        public void DrawBoard(Board b)
        {
            string[] letters = new string[]
            {
                "|A|", "|B|", "|C|", "|D|", "|E|", "|F|", "|G|", "|H|", "|I|", "|J|"
            };
            Console.WriteLine("   |1||2||3||4||5||6||7||8||9||10|");
            CoordinateConverter letterPlacer = new CoordinateConverter();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine();
                Console.Write(letters[i - 1]);
                
                //string boardRow = "";
                for (int j = 1; j <= 10; j++)
                {
                    
                    var coord = new Coordinate(i, j);

                    if (b.ShotHistory.ContainsKey(coord))
                    {
                        var hitOrMiss = b.ShotHistory[coord];
                        if (hitOrMiss == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" " + "H" + " ");//write better!
                            Console.ResetColor();
                        }
                        else if (hitOrMiss == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" " + "M" + " ");
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        Console.Write(" " + "X" + " ");
                    }

                    
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void StartGame()
        {
            Console.WriteLine("Player 1 enter your name: ");
            player1Name = Console.ReadLine();

            setPlayer.SetupBoards(b1);

            Console.WriteLine("Player 2 enter your name: ");
            player2Name = Console.ReadLine();

            setPlayer.SetupBoards(b2);

        }
        public void PlayerTurns()
        {   
            //do while loop over everything
            bool player1Victory = false;
            bool player2Victory = false;
            //start Player 1 turn
            do
            {
                DrawBoard(b2);
                string coordXInput;
                int coordX;
                int coordY;
                CoordinateConverter valid = new CoordinateConverter();

                Console.WriteLine("Player 1 enter X coordinate to fire at: ");
                coordXInput = Console.ReadLine();
                coordX = valid.Validation(coordXInput);
                Console.WriteLine("Player 1 enter Y coordinate to fire at: ");
                coordY = int.Parse(Console.ReadLine());
                var shotP1FiredCoordinates = new Coordinate(coordX, coordY);
                var responseShot = b2.FireShot(shotP1FiredCoordinates);

                Console.WriteLine("Your shot was a " + responseShot.ShotStatus);
                if (responseShot.ShotStatus == ShotStatus.Victory)
                {
                    player1Victory = true;
                }
                Console.WriteLine("Press any key to end your turn");
                Console.ReadLine();
                //end Player 1 turn

                //Start Player 2 turn
                DrawBoard(b1);
                string coordXInput2;
                int coordX2;
                int coordY2;
                CoordinateConverter valid2 = new CoordinateConverter();

                Console.WriteLine("Player 2 enter X coordinate to fire at: ");
                coordXInput2 = Console.ReadLine();
                coordX2 = valid.Validation(coordXInput2);
                Console.WriteLine("Player 2 enter Y coordinate to fire at: ");
                coordY2 = int.Parse(Console.ReadLine());
                var shotP2FiredCoordinates = new Coordinate(coordX2, coordY2);
                var responseShot2 = b1.FireShot(shotP2FiredCoordinates);

                Console.WriteLine("Your shot was a " + responseShot2.ShotStatus);
                if (responseShot2.ShotStatus == ShotStatus.Victory)
                {
                    player2Victory = true;
                }
                Console.WriteLine("Press any key to end your turn");
                Console.ReadLine();
                //end Player 2 turn
            }
            while (player1Victory == false && player2Victory == false);
            if (player1Victory == true)
            {
                Console.WriteLine("{0} wins!", player1Name);
                Console.WriteLine("Press any key to Exit");
                Console.ReadLine();
            }
            else if (player2Victory == true)
            {
                Console.WriteLine("{0} wins!", player2Name);
                Console.WriteLine("Press any key to Exit");
                Console.ReadLine();
            }
       }
        




























    }
  }

