using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVD
    {   
        public DVD()
        {
            BorrowerList = new List<Borrower>();
            Actors = new List<string>();
        }
        

        public int DVDId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MPAARating { get; set; }
        public string DirectorName { get; set; }
        public string Studio { get; set; }
        public decimal UserRating { get; set; }
        public string UserNotes { get; set; }
        public List<string> Actors { get; set; }
        public List<Borrower> BorrowerList { get; set; }

    }

}
