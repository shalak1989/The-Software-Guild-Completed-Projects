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

        public ActionResult LoadPartial()//for partial view
        {
            List<DVD> dvd = new List<DVD>();
            dvd = DVDManager.GetDVDList();

            return View("_DVDCount", dvd);
        }

        [HttpGet]
        public ActionResult DeleteDVD(int dvdId)
        {
            var dvd = DVDManager.GetDVD(dvdId);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult DeleteDVD(DVD dvd)
        {
            DVDManager.DeleteDVD(dvd.DVDId);
            return RedirectToAction("ViewDVDList");

        }

    }



}