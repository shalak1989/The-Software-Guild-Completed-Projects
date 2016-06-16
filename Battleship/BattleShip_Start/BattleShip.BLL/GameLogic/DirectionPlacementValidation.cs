using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.GameLogic
{
    class DirectionPlacementValidation
    {
        public void DirectionValid(string a)
        {
            if (a.Substring(0).ToLower() != "down" || a.Substring(0).ToLower() != "up"
                || a.Substring(0).ToLower() != "left" || a.Substring(0).ToLower() != "right")
            {
                Console.WriteLine("That is not a valid direction!");
            }
        }
    }
}
