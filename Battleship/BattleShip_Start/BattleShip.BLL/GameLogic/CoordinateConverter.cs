using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.GameLogic
{
    public class CoordinateConverter
    {
        string convertString = "";
        public int Validation(string userCoordInput)
        {
            if (userCoordInput.Substring(0, 1).ToLower() == "a")
            {
                return 1;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "b")
            {
                return 2;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "c")
            {
                return 3;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "d")
            {
                return 4;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "e")
            {
                return 5;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "f")
            {
                return 6;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "g")
            {
                return 7;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "h")
            {
                return 8;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "i")
            {
                return 9;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "j")
            {
                return 10;
            }
            return -1;
            
        }
        
    }
}
