using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI.Menu
{   
    
    public class MenuItem
    {

        public void menuStart()
        {
            string menuStartChoice = " ";
            Console.WriteLine("Welcome to Battleship! Choose an option below: ");
            Console.WriteLine();
            Console.WriteLine("Start(s)");
            Console.WriteLine("Quit(q)");
            
            menuStartChoice = Console.ReadLine();

            if (menuStartChoice == "q" || menuStartChoice == "Q")
            {
                Console.Clear();
                Console.WriteLine("Quitting game...");
                Environment.Exit(0);
            }
            else if (menuStartChoice == "s" || menuStartChoice == "S")
            {
                Console.WriteLine("Starting Battleship...");
            }
        }

    }
}
