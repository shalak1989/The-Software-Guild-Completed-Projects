using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseballLeague.Models;
using System.Web.Mvc;

namespace BaseballLeague.Models
{
    public class PlayerViewModel
    {
        public Player Player { get; set; }
        public List<Player> PlayerList { get; set; }
        public List<SelectListItem> ListOfTeams { get; set; }
        public List<SelectListItem> ListOfPositions { get; set; }

        public PlayerViewModel()
        {
            ListOfTeams = new List<SelectListItem>();
            PlayerList = new List<Player>();
            ListOfPositions = new List<SelectListItem>();
        }

        public void SetListOfPositions(List<Position> positions)
        {
            foreach (var position in positions)
            {
                ListOfPositions.Add(new SelectListItem()
                {
                    Value = position.PositionId.ToString(),
                    Text = position.PositionName
                });
            }
        }

        public void SetListOfTeams(List<Team> teams)
        {
            foreach (var team in teams)
            {
                ListOfTeams.Add(new SelectListItem()
                {
                    Value = team.TeamId.ToString(),
                    Text = team.Name
                });
            }
        }

    }
}