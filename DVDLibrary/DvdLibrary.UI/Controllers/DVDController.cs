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
        public DVD Get(int DVDId)
        {
            return DVDManager.GetDVD(DVDId);
        }

        public HttpResponseMessage Delete(int id)
        {
            DVDManager.DeleteDVD(id);

            var response = Request.CreateResponse(HttpStatusCode.NoContent);

            return response;
        }


    }
}