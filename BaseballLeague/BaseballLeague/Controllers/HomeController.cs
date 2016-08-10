using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Models;
using BaseballLeague.BLL;
using BaseballLeague.DLL;

namespace BaseballLeague.Controllers
{
    public class HomeController : Controller
    {
        BaseballServicesManager _mgr;

        public HomeController(BaseballServicesManager mgr)
        {
            _mgr = mgr;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 

        [HttpGet]
        public ActionResult ViewPlayerList(int? teamId)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel();

            if (teamId == null)
            {
                playerViewModel.PlayerList.AddRange(_mgr.GetAllPlayers().ToList());
            }
            else
            {
                playerViewModel.PlayerList.AddRange(_mgr.GetAllPlayers().Where(p => p.Team.TeamId == teamId).ToList());
            }

            playerViewModel.SetListOfTeams(_mgr.GetAllTeams());
            
            return View(playerViewModel);
        }

        [HttpGet]
        public ActionResult DeletePlayer(int playerId)
        {
            var player = _mgr.GetPlayer(playerId);

            return View(player);
        }

        [HttpPost]
        public ActionResult DeletePlayer(Player player)
        {
            _mgr.DeletePlayer(player.PlayerId);
            //return RedirectToAction("ViewTeams?teamId=" + player.Team.TeamId);
            return RedirectToAction("ViewTeams");
        }

        [HttpGet]
        public ActionResult TradePlayer(int playerId)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel();
            playerViewModel.SetListOfTeams(_mgr.GetAllTeams());
            var player = _mgr.GetPlayer(playerId);

            playerViewModel.Player = player;

            return View(playerViewModel);
        }

        [HttpPost]
        public ActionResult TradePlayer(Player player)
        {
            _mgr.TradePlayer(player.PlayerId, player.Team.TeamId);
            return RedirectToAction("ViewPlayerList");
        }

        [HttpGet]
        public ActionResult ViewTeams(int? leagueId)
        {
            TeamViewModel teamViewModel = new TeamViewModel();

            var playerList = _mgr.GetAllPlayers();
            teamViewModel.SetListOfLeagues(_mgr.GetAllLeagues());
      
            teamViewModel.LeagueList = _mgr.GetAllLeagues();

            if (leagueId == null)
            {
                teamViewModel.TeamList.AddRange(_mgr.GetAllTeams().ToList());
  
            }
            else
            {
                teamViewModel.TeamList.AddRange(_mgr.GetAllTeams().Where(p => p.LeagueId == leagueId).ToList());
                
            }

            foreach (var team in  teamViewModel.TeamList)
            {
                team.PlayersList = _mgr.GetAllPlayers().Where(x => x.Team.TeamId == team.TeamId).ToList();
            }
            return View(teamViewModel);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            TeamViewModel teamViewModel = new TeamViewModel();

            teamViewModel.SetListOfLeagues(_mgr.GetAllLeagues());

            teamViewModel.LeagueList = _mgr.GetAllLeagues();

            return View(teamViewModel);
        }

        [HttpPost]
        public ActionResult AddTeam(Team team)
        {
            _mgr.AddTeam(team);
           return RedirectToAction("ViewTeams");
        }

        [HttpGet]
        public ActionResult AddPlayer()
        {
            PlayerViewModel playerVM = new PlayerViewModel();

            playerVM.SetListOfTeams(_mgr.GetAllTeams());
            playerVM.SetListOfPositions(_mgr.GetAllPositions());

            return View(playerVM);
        }

        [HttpPost]
        public ActionResult AddPlayer(PlayerViewModel playerVM)
        {
            Player player = new Player();
            player = playerVM.Player;

            _mgr.AddPlayer(player);

            return RedirectToAction("ViewPlayerList");
        }
        
    }
}