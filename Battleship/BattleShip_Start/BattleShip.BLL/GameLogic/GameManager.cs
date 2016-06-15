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
                    Console.WriteLine("Player 1 enter your coordinates for your Destroyer: ");
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
            string submarineCoords;
            int submarineXCoordinate = 0;
            int submarineYCoordinate = 0;
            bool isValid2Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 1 enter your coordinates for your Submarine: ");
                    submarineCoords = Console.ReadLine();
                    submarineYCoordinate = valid.Validation(submarineCoords);
                    submarineXCoordinate = int.Parse(submarineCoords.Substring(1));
                    if (submarineYCoordinate != -1 && submarineXCoordinate < 11)
                        isValid2Input = true;
                }
                while (!isValid2Input);

                int submarineDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Submarine? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    submarineDirection = dirvalid.Validation(dir);

                }
                while (submarineDirection == -1);


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
            int cruiserXCoordinate = 0;
            int cruiserYCoordinate = 0;
            bool isValid3Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 1 enter your coordinates for your Cruiser: ");
                    cruiserCoords = Console.ReadLine();
                    cruiserYCoordinate = valid.Validation(cruiserCoords);
                    cruiserXCoordinate = int.Parse(cruiserCoords.Substring(1));
                    if (cruiserYCoordinate != -1 && cruiserXCoordinate < 11)
                        isValid3Input = true;
                }
                while (!isValid3Input);

                int cruiserDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Cruiser? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    cruiserDirection = dirvalid.Validation(dir);

                }
                while (cruiserDirection == -1);


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
            int battleshipXCoordinate = 0;
            int battleshipYCoordinate = 0;
            bool isValid4Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 1 enter your coordinates for your Battleship: ");
                    battleshipCoords = Console.ReadLine();
                    battleshipYCoordinate = valid.Validation(battleshipCoords);
                    battleshipXCoordinate = int.Parse(battleshipCoords.Substring(1));
                    if (battleshipYCoordinate != -1 && battleshipXCoordinate < 11)
                        isValid4Input = true;
                }
                while (!isValid4Input);

                int battleshipDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    battleshipDirection = dirvalid.Validation(dir);

                }
                while (battleshipDirection == -1);


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
            int carrierXCoordinate = 0;
            int carrierYCoordinate = 0;
            bool isValid5Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 1 enter your coordinates for your Carrier: ");
                    carrierCoords = Console.ReadLine();
                    carrierYCoordinate = valid.Validation(carrierCoords);
                    carrierXCoordinate = int.Parse(carrierCoords.Substring(1));
                    if (carrierYCoordinate != -1 && carrierXCoordinate < 11)
                        isValid5Input = true;
                }
                while (!isValid5Input);

                int carrierDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Carrier? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    carrierDirection = dirvalid.Validation(dir);

                }
                while (carrierDirection == -1);


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
        
        public void setUpPlayer2()
        {
            Console.Clear();
            Console.WriteLine("Player 2 enter your name: ");
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
                    Console.WriteLine("Player 2 enter your coordinates for your Destroyer: ");
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

                response = b2.PlaceShip(placeShip);

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
            string submarineCoords;
            int submarineXCoordinate = 0;
            int submarineYCoordinate = 0;
            bool isValid2Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 2 enter your coordinates for your Submarine: ");
                    submarineCoords = Console.ReadLine();
                    submarineYCoordinate = valid.Validation(submarineCoords);
                    submarineXCoordinate = int.Parse(submarineCoords.Substring(1));

                    if (submarineYCoordinate != -1 && submarineXCoordinate < 11)
                        isValid2Input = true;
                }
                while (!isValid2Input);

                int submarineDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Submarine? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    submarineDirection = dirvalid.Validation(dir);

                }
                while (submarineDirection == -1);


                PlaceShipRequest placeShip = new PlaceShipRequest();

                placeShip.Coordinate = new Coordinate(submarineXCoordinate, submarineYCoordinate);
                ShipDirection submarineDirectionEnum = (ShipDirection)submarineDirection;
                placeShip.Direction = submarineDirectionEnum;
                ShipType submarineShipTypeEnum = (ShipType)1;
                placeShip.ShipType = submarineShipTypeEnum;

                response = b2.PlaceShip(placeShip);

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
            int cruiserXCoordinate = 0;
            int cruiserYCoordinate = 0;
            bool isValid3Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 2 enter your coordinates for your Cruiser: ");
                    cruiserCoords = Console.ReadLine();
                    cruiserYCoordinate = valid.Validation(cruiserCoords);
                    cruiserXCoordinate = int.Parse(cruiserCoords.Substring(1));
                    if (cruiserYCoordinate != -1 && cruiserXCoordinate < 11)
                        isValid3Input = true;
                }
                while (!isValid3Input);

                int cruiserDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Cruiser? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    cruiserDirection = dirvalid.Validation(dir);

                }
                while (cruiserDirection == -1);


                PlaceShipRequest placeShip = new PlaceShipRequest();

                placeShip.Coordinate = new Coordinate(cruiserXCoordinate, cruiserYCoordinate);
                ShipDirection cruiserDirectionEnum = (ShipDirection)cruiserDirection;
                placeShip.Direction = cruiserDirectionEnum;
                ShipType cruiserShipTypeEnum = (ShipType)2;
                placeShip.ShipType = cruiserShipTypeEnum;

                response = b2.PlaceShip(placeShip);

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
            int battleshipXCoordinate = 0;
            int battleshipYCoordinate = 0;
            bool isValid4Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 2 enter your coordinates for your Battleship: ");
                    battleshipCoords = Console.ReadLine();
                    battleshipYCoordinate = valid.Validation(battleshipCoords);
                    battleshipXCoordinate = int.Parse(battleshipCoords.Substring(1));
                    if (battleshipYCoordinate != -1 && battleshipXCoordinate < 11)
                        isValid4Input = true;
                }
                while (!isValid4Input);

                int battleshipDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Battleship? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    battleshipDirection = dirvalid.Validation(dir);

                }
                while (battleshipDirection == -1);


                PlaceShipRequest placeShip = new PlaceShipRequest();

                placeShip.Coordinate = new Coordinate(battleshipXCoordinate, battleshipYCoordinate);
                ShipDirection battleshipDirectionEnum = (ShipDirection)battleshipDirection;
                placeShip.Direction = battleshipDirectionEnum;
                ShipType battleshipShipTypeEnum = (ShipType)3;
                placeShip.ShipType = battleshipShipTypeEnum;

                response = b2.PlaceShip(placeShip);

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
            int carrierXCoordinate = 0;
            int carrierYCoordinate = 0;
            bool isValid5Input = false;
            do
            {
                do
                {
                    Console.WriteLine("Player 2 enter your coordinates for your Carrier: ");
                    carrierCoords = Console.ReadLine();
                    carrierYCoordinate = valid.Validation(carrierCoords);
                    carrierXCoordinate = int.Parse(carrierCoords.Substring(1));
                    if (carrierYCoordinate != -1 && carrierXCoordinate < 11)
                        isValid5Input = true;
                }
                while (!isValid5Input);

                int carrierDirection = -1;
                do
                {
                    Console.WriteLine("What direction would you like to place your Carrier? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    carrierDirection = dirvalid.Validation(dir);

                }
                while (carrierDirection == -1);


                PlaceShipRequest placeShip = new PlaceShipRequest();

                placeShip.Coordinate = new Coordinate(carrierXCoordinate, carrierYCoordinate);
                ShipDirection carrierDirectionEnum = (ShipDirection)carrierDirection;
                placeShip.Direction = carrierDirectionEnum;
                ShipType carrierShipTypeEnum = (ShipType)4;
                placeShip.ShipType = carrierShipTypeEnum;

                response = b2.PlaceShip(placeShip);

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



































    }
  }

