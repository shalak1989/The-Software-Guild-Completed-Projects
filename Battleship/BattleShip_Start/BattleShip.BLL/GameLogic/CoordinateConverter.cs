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
        public string Validation(string userCoordInput)
        {
            if (userCoordInput.Substring(0, 1).ToLower() == "a")
            {
                convertString = "1" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "b")
            {
                convertString = "2" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "c")
            {
                convertString = "3" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "d")
            {
                convertString = "4" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "e")
            {
                convertString = "5" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "f")
            {
                convertString = "6" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "g")
            {
                convertString = "7" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "h")
            {
                convertString = "8" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "i")
            {
                convertString = "9" + userCoordInput.Substring(1);
                return convertString;
            }
            else if (userCoordInput.Substring(0, 1).ToLower() == "j")
            {
                convertString = "10" + userCoordInput.Substring(1);
                return convertString;
            }
            return "enter a valid coordinate";
            
        }
        
    }
}
