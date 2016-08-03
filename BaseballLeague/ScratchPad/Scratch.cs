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

        public static void GetAllPlayers()
        {
                Team team = new Team();
                Position position = new Position();

                BaseballRepo _repo = new BaseballRepo();
                var playerList = _repo.GetAllPlayers();

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

        public static void GetIndividualPlayer(int PlayerId)
        {
            Team team = new Team();
            Position position = new Position();

            BaseballRepo _repo = new BaseballRepo();
            var player = _repo.GetIndivdualPlayer(PlayerId);

                Console.WriteLine("Player Id: " + player.PlayerId);
                Console.WriteLine("Player Name: " + player.FirstName + " " + player.LastName);
                Console.WriteLine("Jersey Number: " + player.JerseyNumber);
                if (player.PreviousYearsBattingAverage != null)
                {
                    Console.WriteLine("Batting Average: " +  player.PreviousYearsBattingAverage);
                }
                else
                {
                    Console.WriteLine("No batting history");
                }
                Console.WriteLine("Years Played: " + player.YearsPlayed);
                team = _repo.GetTeamName(player);
                position = _repo.GetPositionName(player);

                Console.WriteLine("Team Name: " + team.Name);
                Console.WriteLine("Manager: " + team.ManagerFirstName + " " + team.ManagerLastName);
                Console.WriteLine("POSITON: " + position.PositionName);
                Console.WriteLine("POSITION ID: " + position.PositionId);
                Console.WriteLine("---------------------");
        }

        public static void AddPlayer()
        {

            BaseballRepo repo = new BaseballRepo();

            Player player = new Player();

            Console.WriteLine("Enter player's first name: ");
            player.FirstName = Console.ReadLine();

            Console.WriteLine("Enter player's last name: ");
            player.LastName = Console.ReadLine();

            Console.WriteLine("Enter player's Jersey Number: ");
            player.JerseyNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter player's previous years batting average or enter NONE: ");


            var checkInput = Console.ReadLine();

            if (checkInput == "NONE" || checkInput == "none")
            {
                player.PreviousYearsBattingAverage = null;
            }
            else
            {
                player.PreviousYearsBattingAverage = decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter player's number of years played: ");
            player.YearsPlayed = int.Parse(Console.ReadLine());

            List<Position>  positionList = new List<Position>();
            positionList = repo.GetAllPositions();

            for (int i = 0; i < positionList.Count(); i++)
            {
                Console.WriteLine("Position Id: " + positionList.ElementAt(i).PositionId);
                Console.WriteLine("Position Name: " + positionList.ElementAt(i).PositionName);
                Console.WriteLine("------------------------------");
            }

            Console.WriteLine("Type in the position ID you want to assign to his player: ");
            player.PositionId = int.Parse(Console.ReadLine());


            List<Team> teamList = new List<Team>();
            teamList = repo.GetAllTeams();

            for (int i = 0; i < teamList.Count; i++)
            {
                Console.WriteLine("Team Id: " + teamList.ElementAt(i).TeamId);
                Console.WriteLine("Team Name: " + teamList.ElementAt(i).Name);
                Console.WriteLine("Team Manager: " + teamList.ElementAt(i).ManagerFirstName + " " + teamList.ElementAt(i).ManagerLastName);
                Console.WriteLine("------------------------------------");
                
            }

            Console.WriteLine("Enter the team ID for the team you want the player to be on: ");
            player.TeamId = int.Parse(Console.ReadLine());

            repo.AddPlayer(player);
        }

        public static void AddTeam()
        {
            BaseballRepo repo = new BaseballRepo();

            Team team = new Team();

            Console.WriteLine("Enter the new team's name: ");
            team.Name = Console.ReadLine();

            Console.WriteLine("Enter the new team's Manager's first name: ");
            team.ManagerFirstName = Console.ReadLine();

            Console.WriteLine("Enter the new team's Manager's last name: ");
            team.ManagerLastName = Console.ReadLine();

            var leagueList = repo.GetAllLeagues();

            for (int i = 0; i < leagueList.Count(); i++)
            {
                Console.WriteLine("League Id: " + leagueList.ElementAt(i).LeagueId);
                Console.WriteLine("League Id: " + leagueList.ElementAt(i).Name);
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("Enter the League ID of the league you want to assign this team to: ");
            team.LeagueId = int.Parse(Console.ReadLine());

            repo.AddTeam(team);

        }

        public static void DeletePlayerById(int playerId)
        {
            Console.WriteLine("Enter a player Id to delete");
            BaseballRepo repo = new BaseballRepo();

            repo.DeletePlayer(playerId);
        }

        public static void TradePlayer(Player player)
        {
            BaseballRepo repo = new BaseballRepo();

            repo.TradePlayer(player);

        }










    }
        
}

