using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.DLL;
using BaseballLeague.Models;
using BaseballLeague.BLL;

namespace ScratchPad
{
    class Program
    {
       public static void Main()
        {

            Player player = new Player();

            Console.WriteLine("Enter the ID of the player you wish to trade: ");
            player.PlayerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the ID of the team that you wish to trade the player to: ");
            player.TeamId = int.Parse(Console.ReadLine());

            Scratch.TradePlayer(player);

            Console.ReadLine();
        }
            


    }

}
           
        
           
        

        
        


































