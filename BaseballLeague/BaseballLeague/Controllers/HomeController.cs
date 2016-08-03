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
            return RedirectToAction("ViewPlayerList");
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
            var team = _mgr.GetTeam(player);


            player.Team.Name = "ValentineBullets";
            player.Team.TeamId = 2;

            _mgr.TradePlayer(player.PlayerId);
            return RedirectToAction("ViewPlayerList");
        }
    }
}