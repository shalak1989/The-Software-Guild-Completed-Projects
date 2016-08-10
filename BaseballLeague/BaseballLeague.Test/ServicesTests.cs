using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.BLL;
using BaseballLeague.Models;
using BaseballLeague.DLL;

namespace BaseballLeague.Test
{   
    [TestFixture]
    public class ServicesTests
    {
        [Test]
        public void PlayerAddWorks()
        {

            var repo = new TestRepo();
            var mgr = new BaseballServicesManager(repo);

            Player player = new Player();

            player.Position.PositionName = "Pitcher";
            player.PlayerId = 3;
            player.FirstName = "Bob";

            mgr.AddPlayer(player);

            var playerList = mgr.GetAllPlayers();

            Assert.AreEqual(playerList.ElementAt(2).FirstName, "Bob");
            Assert.AreEqual(3, playerList.Count);
        }

        [Test]
        public void PlayerDeleteWorks()
        {

            var repo = new TestRepo();
            var mgr = new BaseballServicesManager(repo);
            var player = mgr.GetPlayer(1);

            mgr.DeletePlayer(player.PlayerId);

            var playerList = mgr.GetAllPlayers();

            Assert.AreEqual(1, playerList.Count);
        }

        [Test]
        public void AddTeamWorks()
        {

            var repo = new TestRepo();
            var mgr = new BaseballServicesManager(repo);
            Team team = new Team();

            team.Name = "Tomatoes";

            mgr.AddTeam(team);

            var teamList = mgr.GetAllTeams();

            Assert.AreEqual(3, teamList.Count);
            Assert.True(teamList.ElementAt(2).Name == "Tomatoes");
        }

        [Test]
        public void TradePlayerWorks()
        {

            var repo = new TestRepo();
            var mgr = new BaseballServicesManager(repo);
            var player = mgr.GetPlayer(1);


            mgr.TradePlayer(1, 2);
            var playerList = mgr.GetAllPlayers();

            Assert.True(playerList.First(p => p.PlayerId == 1).Team.TeamId == 2);
        }

        //public void DVDDeleteWorks()
        //public void ListDVDWorks()
        //public void GetIndividualDVD()

    }
}
