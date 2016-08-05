using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BaseballLeague.BLL;
using BaseballLeague.Models;

namespace BaseballLeague.Controllers
{
    public class PlayerController : ApiController
    {
        BaseballServicesManager _mgr;

        public PlayerController(BaseballServicesManager mgr)
        {
            _mgr = mgr;
        }

        public List<Player> Get()
        {
            var playerList = _mgr.GetAllPlayers();

            return playerList;
        }
    }
}