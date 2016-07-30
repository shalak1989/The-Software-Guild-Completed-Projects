using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int PositionId { get; set; }
        public int TeamId { get; set; }
        public decimal? PreviousYearsBattingAverage { get; set; }
        public int YearsPlayed { get; set; }

    }
}
