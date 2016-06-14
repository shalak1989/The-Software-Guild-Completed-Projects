using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.BLL.GameLogic
{
    public class GameManager
    {
        Board b1 = new Board();
        Board b2 = new Board();
        
        CoordinateConverter valid = new CoordinateConverter();

        string player1Name = "";
        string player2Name = "";

        public void setUpPlayer1()
        {
            Console.Clear();
            Console.WriteLine("Player 1 enter your name: ");
            player1Name = Console.ReadLine();

            Console.WriteLine("Player 1 enter your coordinates for your destroyer: ");
            string destroyerCoords = Console.ReadLine();
            destroyerCoords = valid.Validation(destroyerCoords);
            Console.WriteLine("What direction would you like to place your Destoyer? \n\nUp\nDown\nLeft\nRight");
            string destroyerDirection = Console.ReadLine();
            PlaceShipRequest placeShip = new PlaceShipRequest();
            placeShip.Coordinate.XCoordinate = int.Parse(destroyerCoords.Substring(0,1));
            placeShip.Coordinate.YCoordinate = int.Parse(destroyerCoords.Substring(1, 1));

            Console.WriteLine("Player 1 enter your coordinates for your Submarine: ");
            string submarineCoordinate = Console.ReadLine();
            submarineCoordinate = valid.Validation(submarineCoordinate);
            Console.WriteLine("What direction would you like to place your Submarine? \n\nUp\nDown\nLeft\nRight");
            string submarineDirection = Console.ReadLine();

            Console.WriteLine("Player 1 enter your coordinates for your Cruiser: ");
            string cruiserCoordinate = Console.ReadLine();
            cruiserCoordinate = valid.Validation(cruiserCoordinate);
            Console.WriteLine("What direction would you like to place your Cruiser? \n\nUp\nDown\nLeft\nRight");
            string cruiserDirection = Console.ReadLine();

            Console.WriteLine("Player 1 enter your coordinates for your Battleship: ");
            string battleshipCoordinate = Console.ReadLine();
            battleshipCoordinate = valid.Validation(battleshipCoordinate);
            Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
            string battleshipDirection = Console.ReadLine();

            Console.WriteLine("Player 1 enter your coordinates for your Carrier: ");
            string carrierCoordinate = Console.ReadLine();
            carrierCoordinate = valid.Validation(carrierCoordinate);
            Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
            string carrierDirection = Console.ReadLine();

            Console.WriteLine(destroyerCoords + "" + destroyerDirection);
            Console.WriteLine(submarineCoordinate + "" + submarineDirection);
            Console.WriteLine(cruiserCoordinate + "" + cruiserDirection);
            Console.WriteLine(battleshipCoordinate + "" + battleshipDirection);
            Console.WriteLine(carrierCoordinate + "" + carrierDirection);
            Console.ReadLine();
        }

        public void setUpPlayer2()
        {
            Console.Clear();
            Console.WriteLine("Player 2 enter your name: ");
            player2Name = Console.ReadLine();

            Console.WriteLine("Player 2 enter your coordinates for your destroyer: ");
            string destroyerCoordinate = Console.ReadLine();
            //coordinate validation goes here
            Console.WriteLine("What direction would you like to place your Destoyer? \n\nUp\nDown\nLeft\nRight");
            string destroyer1Direction = Console.ReadLine();

            Console.WriteLine("Player 2 enter your coordinates for your Submarine: ");
            string submarine1Coordinate = Console.ReadLine();
            //coordinate validation goes here
            Console.WriteLine("What direction would you like to place your Submarine? \n\nUp\nDown\nLeft\nRight");
            string submarine1Direction = Console.ReadLine();

            Console.WriteLine("Player 2 enter your coordinates for your Cruiser: ");
            string cruiser1Coordinate = Console.ReadLine();
            //coordinate validation goes here
            Console.WriteLine("What direction would you like to place your Cruiser? \n\nUp\nDown\nLeft\nRight");
            string cruiser1Direction = Console.ReadLine();

            Console.WriteLine("Player 2 enter your coordinates for your Battleship: ");
            string battleship1Coordinate = Console.ReadLine();
            //coordinate validation goes here
            Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
            string battleship1Direction = Console.ReadLine();

            Console.WriteLine("Player 2 enter your coordinates for your Carrier: ");
            string carrier1Coordinate = Console.ReadLine();
            //coordinate validation goes here
            Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
            string carrier1Direction = Console.ReadLine();
        }




































  }
}
