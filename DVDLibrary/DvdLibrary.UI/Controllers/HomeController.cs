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
        DVDManager mgr = new DVDManager();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ViewDVDList(string searchString)
        {
            List<DVD> dvd = new List<DVD>();

            dvd = mgr.GetDVDList();

            if (!String.IsNullOrEmpty(searchString))
            {
                dvd = dvd.FindAll(s => s.Title.Contains(searchString));
            }

            return View(dvd);

        }

        [HttpGet]
        public ActionResult ViewDVD(int DVDId)
        {
            var dvd = mgr.GetDVD(DVDId);

            return View(dvd);

        }

        public ActionResult LoadPartial()//for partial view
        {
            List<DVD> dvd = new List<DVD>();
            dvd = mgr.GetDVDList();

            return View("_DVDCount", dvd);
        }

        [HttpGet]
        public ActionResult DeleteDVD(int dvdId)
        {
            var dvd = mgr.GetDVD(dvdId);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult DeleteDVD(DVD dvd)
        {
            mgr.DeleteDVD(dvd.DVDId);
            return RedirectToAction("ViewDVDList");

        }

    }



}