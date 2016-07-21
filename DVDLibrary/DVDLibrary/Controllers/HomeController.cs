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

        [HttpGet]
        public ActionResult ViewDVDList()
        {
            List<DVD> dvd = new List<DVD>();

            dvd = DVDManager.GetDVDList();

            return View(dvd);

        }

    }


}