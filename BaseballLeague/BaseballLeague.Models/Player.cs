using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Player
    {
        public Player()
        {
            Position = new Position();
            Team = new Team();
        }
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public Position Position { get; set; }
        public Team Team { get; set; }
        public decimal? PreviousYearsBattingAverage { get; set; }
        public int YearsPlayed { get; set; }

    }
}
