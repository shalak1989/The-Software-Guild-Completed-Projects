using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.DLL
{

    public static class DVDRepository
    {     
        private static List<DVD> _dvds;

        static DVDRepository()
        {
            _dvds = new List<DVD>
            {
                new DVD {
                DVDId = 1,
                DirectorName = "Steven Speilberg",
                Title = "The Man With No Purpose",
                ReleaseDate = DateTime.Parse("7/11/1993"),
                MPAARating = "R",
                Studio = "Warner Brothers",
                UserRating = 5.0M,
                UserNotes = "Movie makes me feel bad bro",
                Actors = { "Sylvester Stallone", "Katy Perry", "Mark Wahlberg", "Liam Neeson", "Scarlett Johansson" },
                BorrowerList = {
                        new Borrower { Name = "Creepy Bob", DateBorrowed = DateTime.Parse("7/01/2016"), DateReturned = DateTime.Parse("7/06/2016") },
                        new Borrower { Name = "Crazy Issac", DateBorrowed = DateTime.Parse("6/01/2016"), DateReturned = DateTime.Parse("06/03/2016") },
                        new Borrower { Name = "Dale Smith", DateBorrowed = DateTime.Parse("4/01/2016"), DateReturned = DateTime.Parse("4/04/2016") }

                    } },

                new DVD {
                DVDId = 2,
                DirectorName = "Donnie Yen",
                Title = "Life without taxes",
                ReleaseDate = DateTime.Parse("7/13/2016"),
                MPAARating = "G",
                Studio = "Pointless Studios",
                UserRating = 2.5M,
                UserNotes = "Movie makes me feel like I can dodge anything",
                Actors = { "Will Smith", "Bob Saggot", "Patrick Swayzee's Ghost", "John Snow", "Dennis Quade" },
                BorrowerList = {
                        new Borrower { Name = "Al Capone", DateBorrowed = DateTime.Parse("7/01/1945"), DateReturned = DateTime.Parse("07/06/1945") },
                        new Borrower { Name = "Mickey York", DateBorrowed = DateTime.Parse("12/03/2015"), DateReturned = DateTime.Parse("12/06/2015") }
                    } },

                new DVD {
                DVDId = 3,
                DirectorName = "George Bush",
                Title = "A Democrat who was a Republican but really a Democrat",
                ReleaseDate = DateTime.Parse("7/11/1993"),
                MPAARating = "PG-13",
                Studio = "Trump Towers",
                UserRating = 1.0M,
                UserNotes = "This movie feels like real life",
                Actors = { "Donald Trump", "Bernie Sanders", "Bill O'Reily", "Mike Tyson", "An unhatched dragon egg" },
                BorrowerList = {
                        new Borrower { Name = "Donald Trump", DateBorrowed = DateTime.Parse("11/25/2015"), DateReturned = DateTime.Parse("11/30/2015") },
                        new Borrower { Name = "Sean Hannity", DateBorrowed = DateTime.Parse("01/01/2016"), DateReturned = DateTime.Parse("01/05/2016") }

                    } },
            };
        }

        public static List<DVD> GetAll()
        {
            return _dvds;
        }

        public static DVD Get(int DVDId)
        {
            var dvd = _dvds.FirstOrDefault(d => d.DVDId == DVDId);
            return dvd;
        }

        public static void Add(DVD DVD)
        {
            _dvds.Add(DVD);
        }

        public static void Delete(int DVDId)
        {
            _dvds.RemoveAll(d => d.DVDId == DVDId);
        }

       





























    }
}


    

           

        
                

            

            

