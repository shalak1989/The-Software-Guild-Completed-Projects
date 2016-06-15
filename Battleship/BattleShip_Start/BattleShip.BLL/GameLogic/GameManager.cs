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
        
        CoordinateConverter valid = new CoordinateConverter();
        DirectionConverter dirvalid = new DirectionConverter();

        string player1Name = "";
        string player2Name = "";
        ShipPlacement response = new ShipPlacement();

        public void setUpPlayer1()
        {
            Console.Clear();
            Console.WriteLine("Player 1 enter your name: ");
            player1Name = Console.ReadLine();

            //begin destroyer placement
            string destroyerCoords;
            int destroyerXCoordinate = 0;
            int destroyerYCoordinate = 0;
            bool isValidInput = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 1 enter your coordinates for your destroyer: ");
                    destroyerCoords = Console.ReadLine();
                    destroyerYCoordinate = valid.Validation(destroyerCoords);
                    destroyerXCoordinate = int.Parse(destroyerCoords.Substring(1));
                    if (destroyerYCoordinate != -1 && destroyerXCoordinate < 11)
                        isValidInput = true;
                }
                while (!isValidInput);

                int destroyerDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Destoyer? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    destroyerDirection = dirvalid.Validation(dir);

                }
                while (destroyerDirection == -1);


                PlaceShipRequest placeShip = new PlaceShipRequest();

                placeShip.Coordinate = new Coordinate(destroyerXCoordinate, destroyerYCoordinate);
                ShipDirection destroyerDirectionEnum = (ShipDirection)destroyerDirection;
                placeShip.Direction = destroyerDirectionEnum;
                ShipType destroyerShipTypeEnum = (ShipType)0;
                placeShip.ShipType = destroyerShipTypeEnum;

                response = b1.PlaceShip(placeShip);

                if (response == ShipPlacement.Ok)
                {
                    Console.WriteLine("Ship placement is valid, Press any key to continue: ");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error there is {0} within those coordinates, press any key to try again: ", response);
                    Console.ReadLine();
                }
            }
            while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);
            //end Destroyer placement

            //begin Submarine placement
            /* string submarineCoords;
             do
             {
                 do
                 {
                     Console.WriteLine("Player 1 enter your coordinates for your Submarine: ");
                     submarineCoords = Console.ReadLine();
                     submarineCoords = valid.Validation(submarineCoords);
                 }
                 while (submarineCoords == "enter a valid coordinate");

                 int submarineDirection = -1;
                 do
                 {
                     Console.WriteLine("What direction would you like to place your Submarine? \n\nUp\nDown\nLeft\nRight");
                     string dir = Console.ReadLine();
                     submarineDirection = dirvalid.Validation(dir);
                 }
                 while (submarineDirection == -1);

                 int submarineXCoordinate = int.Parse(submarineCoords.Substring(0, 1));
                 int submarineYCoordinate = int.Parse(submarineCoords.Substring(1, 1));

                 PlaceShipRequest placeShip = new PlaceShipRequest();

                 placeShip.Coordinate = new Coordinate(submarineXCoordinate, submarineYCoordinate);
                 ShipDirection submarineDirectionEnum = (ShipDirection)submarineDirection;
                 placeShip.Direction = submarineDirectionEnum;
                 ShipType submarineShipTypeEnum = (ShipType)1;
                 placeShip.ShipType = submarineShipTypeEnum;

                 response = b1.PlaceShip(placeShip);
                 if (response == ShipPlacement.Ok)
                 {
                     Console.WriteLine("Ship placement is valid, Press any key to continue: ");
                     Console.ReadLine();
                 }
                 else
                 {
                     Console.WriteLine("Error there is {0} within those coordinates, press any key to try again: ", response);
                     Console.ReadLine();
                 }
             }
             while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);
             //end Submarine placement

             //begin Cruiser placement
             string cruiserCoords;
             do
             {
                 do
                 {
                     Console.WriteLine("Player 1 enter your coordinates for your Cruiser: ");
                     cruiserCoords = Console.ReadLine();
                     cruiserCoords = valid.Validation(cruiserCoords);
                 }
                 while (cruiserCoords == "enter a valid coordinate");

                 int cruiserDirection = -1;
                 do
                 {
                     Console.WriteLine("What direction would you like to place your Submarine? \n\nUp\nDown\nLeft\nRight");
                     string dir = Console.ReadLine();
                     cruiserDirection = dirvalid.Validation(dir);
                 }
                 while (cruiserDirection == -1);

                 int cruiserXCoordinate = int.Parse(cruiserCoords.Substring(0, 1));
                 int cruiserYCoordinate = int.Parse(cruiserCoords.Substring(1, 1));

                 PlaceShipRequest placeShip = new PlaceShipRequest();

                 placeShip.Coordinate = new Coordinate(cruiserXCoordinate, cruiserYCoordinate);
                 ShipDirection cruiserDirectionEnum = (ShipDirection)cruiserDirection;
                 placeShip.Direction = cruiserDirectionEnum;
                 ShipType cruiserShipTypeEnum = (ShipType)2;
                 placeShip.ShipType = cruiserShipTypeEnum;

                 response = b1.PlaceShip(placeShip);
                 if (response == ShipPlacement.Ok)
                 {
                     Console.WriteLine("Ship placement is valid, Press any key to continue: ");
                     Console.ReadLine();
                 }
                 else
                 {
                     Console.WriteLine("Error there is {0} within those coordinates, press any key to try again: ", response);
                     Console.ReadLine();
                 }
             }
             while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);
             //end Cruiser placement

             //begin Battleship placement
             string battleshipCoords;
             do
             {
                 do
                 {
                     Console.WriteLine("Player 1 enter your coordinates for your Battleship: ");
                     battleshipCoords = Console.ReadLine();
                     battleshipCoords = valid.Validation(battleshipCoords);
                 }
                 while (battleshipCoords == "enter a valid coordinate");

                 int battleshipDirection = -1;
                 do
                 {
                     Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
                     string dir = Console.ReadLine();
                     battleshipDirection = dirvalid.Validation(dir);
                 }
                 while (battleshipDirection == -1);

                 int battleshipXCoordinate = int.Parse(battleshipCoords.Substring(0, 1));
                 int battleshipYCoordinate = int.Parse(battleshipCoords.Substring(1, 1));

                 PlaceShipRequest placeShip = new PlaceShipRequest();

                 placeShip.Coordinate = new Coordinate(battleshipXCoordinate, battleshipYCoordinate);
                 ShipDirection battleshipDirectionEnum = (ShipDirection)battleshipDirection;
                 placeShip.Direction = battleshipDirectionEnum;
                 ShipType battleshipShipTypeEnum = (ShipType)3;
                 placeShip.ShipType = battleshipShipTypeEnum;

                 response = b1.PlaceShip(placeShip);
                 if (response == ShipPlacement.Ok)
                 {
                     Console.WriteLine("Ship placement is valid, Press any key to continue: ");
                     Console.ReadLine();
                 }
                 else
                 {
                     Console.WriteLine("Error there is {0} within those coordinates, press any key to try again: ", response);
                     Console.ReadLine();
                 }
             }
             while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);
             //end Battleship placement

             //begin Carrier placement
             string carrierCoords;
             do
             {
                 do
                 {
                     Console.WriteLine("Player 1 enter your coordinates for your Carrier: ");
                     carrierCoords = Console.ReadLine();
                     carrierCoords = valid.Validation(carrierCoords);
                 }
                 while (carrierCoords == "enter a valid coordinate");

                 int carrierDirection = -1;
                 do
                 {
                     Console.WriteLine("What direction would you like to place your Carrier? \n\nUp\nDown\nLeft\nRight");
                     string dir = Console.ReadLine();
                     carrierDirection = dirvalid.Validation(dir);
                 }
                 while (carrierDirection == -1);

                 int carrierXCoordinate = int.Parse(carrierCoords.Substring(0, 1));
                 int carrierYCoordinate = int.Parse(carrierCoords.Substring(1, 1));

                 PlaceShipRequest placeShip = new PlaceShipRequest();

                 placeShip.Coordinate = new Coordinate(carrierXCoordinate, carrierYCoordinate);
                 ShipDirection carrierDirectionEnum = (ShipDirection)carrierDirection;
                 placeShip.Direction = carrierDirectionEnum;
                 ShipType carrierShipTypeEnum = (ShipType)4;
                 placeShip.ShipType = carrierShipTypeEnum;

                 response = b1.PlaceShip(placeShip);
                 if (response == ShipPlacement.Ok)
                 {
                     Console.WriteLine("Ship placement is valid, Press any key to continue: ");
                     Console.ReadLine();
                 }
                 else
                 {
                     Console.WriteLine("Error there is {0} within those coordinates, press any key to try again: ", response);
                     Console.ReadLine();
                 }
             }
             while (response == ShipPlacement.NotEnoughSpace || response == ShipPlacement.Overlap);
             //end Carrier placement

         }

             /* Console.WriteLine("Player 1 enter your coordinates for your Submarine: ");
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
         }*/



































        }
  }
}
