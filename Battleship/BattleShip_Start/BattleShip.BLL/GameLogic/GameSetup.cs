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
    public class GameSetup
    {
        public void Execute()
        {

            Console.WriteLine("Player 1 enter your name: ");
            string player1Name = Console.ReadLine();
           // Console.WriteLine("Player 2 enter your name: ");
           // string player2Name = Console.ReadLine();

            Board b1 = new Board();
            Board b2 = new Board();

            CoordinateConverter coordvalid = new CoordinateConverter();
            DirectionConverter dirvalid = new DirectionConverter();
            ShipPlacement response = new ShipPlacement();

            string shipCoords;
            int shipXCoord = 0;
            string shipYCoord = "";
            int shipYCoordActual = 0;
            
            bool isValidXInput = false;
            bool isValidY;
            int num2;
            do//validation behaves strangely if this do/while loop is enabled, gives errors but does not
                //fail until the direction input
            {
                //-------------------------------------------------------------
                do
                {
                    /*enumloop*/Console.WriteLine("Player 1 enter your coordinates for your Destroyer");
                    shipCoords = Console.ReadLine();
                    shipXCoord = coordvalid.Validation(shipCoords);
                    if (shipXCoord > 0 && shipXCoord < 11)
                    {
                        isValidXInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Your X coordinate was not valid!");
                    }

                    shipYCoord = shipCoords.Substring(1);
                    isValidY = int.TryParse(shipYCoord, out num2);
                    if (isValidY == false)
                    {
                        Console.WriteLine("Your Y coordinate was not valid!");
                    }
                    else
                    {
                        shipYCoordActual = int.Parse(shipYCoord);
                    }

                } while (isValidY == false && isValidXInput == false && shipYCoordActual < 0 || shipYCoordActual > 10);
                //start direction
                int directionOfShip = -1;
                do
                {
             /*enumloop*/Console.WriteLine("What direction would you like to place your Destroyer? \n\nUp\nDown\nLeft\nRight");
                    string dir = Console.ReadLine();
                    directionOfShip = dirvalid.Validation(dir);
                    if (directionOfShip == -1)
                    {
                        Console.WriteLine("Enter a valid ship direction!");
                    }
                } while (directionOfShip == -1);

                PlaceShipRequest placingShip = new PlaceShipRequest();

                placingShip.Coordinate = new Coordinate(shipXCoord, shipYCoordActual);
                ShipDirection shipDirectionEnum = (ShipDirection)directionOfShip;
                placingShip.Direction = shipDirectionEnum;
                ShipType shipTypeEnum = 0;//need a way to loop through
                placingShip.ShipType = shipTypeEnum;

                response = b1.PlaceShip(placingShip);

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
                //--------------------------------------
            } while (response != ShipPlacement.Ok);

        }
            
            
            




                    
                
            












   }
}  

