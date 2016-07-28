using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.DLL;
using DVDLibrary.Models;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {

            ShowAllDVD();
            //ShowIndividualDVD(1);
            //DeleteDVD(1);
            Console.ReadLine();
         
        }

        private static void AddDVD()
        {
            DVD dvd = new DVD();
            SQLRepository repo = new SQLRepository();
            repo.Add(dvd);
        }

        private static void DeleteDVD(int dvdId)
        {
            SQLRepository repo = new SQLRepository();
            repo.Delete(dvdId);


        }

        private static void ShowAllDVD()
        {
            SQLRepository repo = new SQLRepository();

            var dvdList = repo.GetAll();

            Console.WriteLine("All DVDs");
            Console.WriteLine("-------------");
            foreach (DVD d in dvdList)
            {
                Console.WriteLine("{0}", d.DVDId);
                Console.WriteLine("{0}", d.Title);
                Console.WriteLine("{0}", d.ReleaseDate);
                Console.WriteLine("{0}", d.MPAARating);
                Console.WriteLine("{0}", d.ReleaseDate.ToShortDateString());
                Console.WriteLine("{0}", d.Studio);
                Console.WriteLine("{0}", d.Actors);
                Console.WriteLine("{0}", d.UserRating);
                Console.WriteLine("{0}", d.UserNotes);
                Console.WriteLine("{0}", d.BorrowerList.ToString().Split(','));
                Console.WriteLine("----------------------");


            }
        }

        private static void ShowIndividualDVD(int id)
        {
            SQLRepository repo = new SQLRepository();

            var dvd = repo.Get(id);

            Console.WriteLine("DVD");
            Console.WriteLine("-------------");
            
                Console.WriteLine("{0}", dvd.DVDId);
                Console.WriteLine("{0}", dvd.Title);
                Console.WriteLine("{0}", dvd.ReleaseDate);
                Console.WriteLine("{0}", dvd.MPAARating);
                Console.WriteLine("{0}", dvd.ReleaseDate.ToShortDateString());
                Console.WriteLine("{0}", dvd.Studio);
                Console.WriteLine("{0}", dvd.Actors);
                Console.WriteLine("{0}", dvd.UserRating);
                Console.WriteLine("{0}", dvd.UserNotes);
                Console.WriteLine("{0}", dvd.BorrowerList.ToString().Split(','));
                Console.WriteLine("----------------------");
        }

    }
}
