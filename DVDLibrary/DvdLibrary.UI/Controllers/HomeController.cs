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
        IDVDManager _mgr;

        public HomeController(IDVDManager mgr)
        {
            _mgr = mgr;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ViewDVDList(string searchString)
        {
            List<DVD> dvd = new List<DVD>();

            if(!string.IsNullOrEmpty(searchString))
            {
                StringComparison comp = StringComparison.OrdinalIgnoreCase;
                foreach (var item in _mgr.GetDVDList())
                {
                    if (item.Title.IndexOf(searchString, comp) >= 0)
                        dvd.Add(item);
                }
                return Json(dvd);
            }
            else
            {
                dvd = _mgr.GetDVDList();
            }
            

           

            return View(dvd);

        }

        [HttpGet]
        public ActionResult ViewDVD(int DVDId)
        {
            var dvd = _mgr.GetDVD(DVDId);

            return View(dvd);

        }

        public ActionResult LoadPartial()//for partial view
        {
            List<DVD> dvd = new List<DVD>();
            dvd = _mgr.GetDVDList();

            return View("_DVDCount", dvd);
        }

        [HttpGet]
        public ActionResult DeleteDVD(int dvdId)
        {
            var dvd = _mgr.GetDVD(dvdId);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult DeleteDVD(DVD dvd)
        {
            _mgr.DeleteDVD(dvd.DVDId);
            return RedirectToAction("ViewDVDList");

        }

    }



}