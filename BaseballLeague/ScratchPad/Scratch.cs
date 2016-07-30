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
    public static class Scratch
    {

        public static void ShowAllPlayers()
        {
                Team team = new Team();
                Position position = new Position();

                BaseballSQLRepo _repo = new BaseballSQLRepo();
                var playerList = _repo.GetAll();

            foreach (var player in playerList)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(player.PlayerId);
                Console.WriteLine(player.FirstName);
                Console.WriteLine(player.LastName);
                Console.WriteLine(player.JerseyNumber);
                if (player.PreviousYearsBattingAverage != null)
                {
                    Console.WriteLine(player.PreviousYearsBattingAverage);
                }
                else
                {
                    Console.WriteLine("No batting history");
                }
                Console.WriteLine(player.YearsPlayed);
                team = _repo.GetTeamName(player);
                position = _repo.GetPositionName(player);

                Console.WriteLine("Team Name: " + team.Name);
                Console.WriteLine(team.ManagerFirstName);
                Console.WriteLine(team.ManagerLastName);
                Console.WriteLine("POSITON: " + position.PositionName);
                Console.WriteLine("POSITION ID: " + position.PositionId);
                Console.WriteLine("---------------------");
            }
        } 












    }
        
}

