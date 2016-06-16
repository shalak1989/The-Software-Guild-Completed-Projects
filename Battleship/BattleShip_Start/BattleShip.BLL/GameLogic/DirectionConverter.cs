using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.GameLogic
{
    class DirectionConverter
    {
        int intDirection;

        public int Validation(string userDirectionInput)
        {
            if (userDirectionInput.ToLower() == "up")
            {
                intDirection = 2;
                return intDirection;
            }
            else if (userDirectionInput.ToLower() == "down")
            {
                intDirection = 3;
                return intDirection;
            }
            else if (userDirectionInput.ToLower() == "left")
            {
                intDirection = 0;
                return intDirection;
            }
            else if (userDirectionInput.ToLower() == "right")
            {
                intDirection = 1;
                return intDirection;
            }
            else return -1;
        }
    }
}
