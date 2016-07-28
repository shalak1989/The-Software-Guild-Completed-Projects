using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.BLL;
using DVDLibrary.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace DVDLibrary.Controllers
{
    public class DVDController : ApiController
    {
        IDVDManager _mgr;

        public DVDController(IDVDManager mgr)
        {
            _mgr = mgr;
        }


        public List<DVD> Get()
        {
            var dvdList = _mgr.GetDVDList();

            return dvdList;
        }

        public List<DVD> Get(string searchString)
        {
            List<DVD> dvd = new List<DVD>();

            if (!string.IsNullOrEmpty(searchString))
            {
                StringComparison comp = StringComparison.OrdinalIgnoreCase;
                foreach (var item in _mgr.GetDVDList())
                {
                    if (item.Title.IndexOf(searchString, comp) >= 0)
                        dvd.Add(item);
                }
               
            }
            else
            {
                dvd = _mgr.GetDVDList();
            }

            return (dvd);
        }

        public HttpResponseMessage Post(DVD newDVD)
        {

            _mgr.AddDVD(newDVD);

            var response = Request.CreateResponse(HttpStatusCode.Created, newDVD);
           
            return response;
        }


    }
}