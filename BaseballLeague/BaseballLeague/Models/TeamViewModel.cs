using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballLeague.Models
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public List<Team> TeamList { get; set; }
        public List<SelectListItem> ListOfLeagues { get; set; }
        public List<League> LeagueList { get; set; }


        public TeamViewModel()
        {
            Team = new Team();
            ListOfLeagues = new List<SelectListItem>();
            TeamList = new List<Team>();
            LeagueList = new List<League>();
        }

        public void SetListOfLeagues(List<League> leagues)
        {
            foreach (var league in leagues)
            {
                ListOfLeagues.Add(new SelectListItem()
                {
                    Value = league.LeagueId.ToString(),
                    Text = league.Name
                });
            }
        }

    }
}