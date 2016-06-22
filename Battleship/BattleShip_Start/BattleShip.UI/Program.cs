﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI.Menu;
using BattleShip.BLL.GameLogic;


namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuItem obj = new MenuItem();
            GameManager game = new GameManager();
            GameSetup gameSetupObj = new GameSetup();
            
            obj.menuStart();
            game.StartGame();
            game.PlayerTurns();

        }
    }
}
