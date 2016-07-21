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


        public List<DVD> Get()
        {
            var dvdList = DVDManager.GetDVDList();

            return dvdList;
        }

        public HttpResponseMessage Post(DVD newDVD)
        {

            DVDManager.AddDVD(newDVD);

            var response = Request.CreateResponse(HttpStatusCode.Created, newDVD);
           
            return response;
        }


    }
}