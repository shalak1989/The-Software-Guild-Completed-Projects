using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.BLL;
using DVDLibrary.Models;


namespace DVDLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ViewDVDList(string searchString)
        {
            List<DVD> dvd = new List<DVD>();

            dvd = DVDManager.GetDVDList();

            if (!String.IsNullOrEmpty(searchString))
            {
                dvd = dvd.FindAll(s => s.Title.Contains(searchString));
            }

            return View(dvd);

        }

        [HttpGet]
        public ActionResult ViewDVD(int DVDId)
        {
            var dvd = DVDManager.GetDVD(DVDId);

            return View(dvd);

        }

        public ActionResult LoadPartial()
        {
            List<DVD> dvd = new List<DVD>();
            dvd = DVDManager.GetDVDList();

            return View("_DVDCount", dvd);
        }

    }


}