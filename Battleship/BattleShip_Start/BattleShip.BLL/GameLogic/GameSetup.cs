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

        public void SetupBoards(Board b)
        {

            CoordinateConverter coordvalid = new CoordinateConverter();
            DirectionConverter dirvalid = new DirectionConverter();
            ShipPlacement response = new ShipPlacement();

            string shipCoords;
            int shipXCoord = 0;
            string shipYCoord = "";
            int shipYCoordActual = 0;

            bool isValidY;
            int num2;

            Array shipValues = Enum.GetValues(typeof(ShipType));

            foreach (ShipType shipname in shipValues)
            {
                Enum.GetName(typeof(ShipType), shipname);

                do
                {
                    bool isValidCoordinates = false;
                    do
                    {
                        Console.WriteLine("Player 1 enter your coordinates for your {0}", shipname);
                        shipCoords = Console.ReadLine();
                        shipXCoord = coordvalid.Validation(shipCoords);
                        shipYCoord = shipCoords.Substring(1);
                        isValidY = int.TryParse(shipYCoord, out num2);
                        if (isValidY == true)
                        {
                            shipYCoordActual = int.Parse(shipYCoord);
                        }
                        else
                        {
                            Console.WriteLine("Your coordinate was not valid!");
                        }

                        if (shipXCoord <= 0 || shipXCoord > 10 || isValidY == false || shipYCoordActual <= 0 || shipYCoordActual > 10)
                        {
                            Console.WriteLine("Your coordinate was not valid!");
                        }

                        else
                        {
                            isValidCoordinates = true;
                        }

                    } while (isValidCoordinates == false);
                    //start direction
                    int directionOfShip = -1;
                    do
                    {
                        
                        Console.WriteLine("What direction would you like to place your {0}? \n\nUp\nDown\nLeft\nRight", shipname);
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
         
                    placingShip.ShipType = shipname;

                    response = b.PlaceShip(placingShip);

                    if (response == ShipPlacement.Ok)
                    {
                        Console.WriteLine("{0} placement is valid, Press any key to continue: ", shipname);
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
}
  

