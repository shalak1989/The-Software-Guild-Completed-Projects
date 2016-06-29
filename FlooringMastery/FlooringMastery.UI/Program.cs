using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.UI.Workflows;
using FlooringMastery.BLL;

namespace FlooringMastery.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu startMenu = new MainMenu();
            //OrderRepository repo = new OrderRepository();

            startMenu.Execute();


            

            


        }
    }
}
