using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class ContactsController : ApiController
    {
        public List<Contact> Get()
        {
            var repository = new FakeContactDatabase();
            return repository.GetAll();
        }

        public Contact Get(int id)
        {
            var repository = new FakeContactDatabase();
            return repository.GetById(id);
        }

        public HttpResponseMessage Post(Contact newContact)
        {
            var repository = new FakeContactDatabase();
            repository.Add(newContact);

            var response = Request.CreateResponse(HttpStatusCode.Created, newContact);
            //This is optional
            string uri = Url.Link("DefaultApi", new { id = newContact.ContactId });
            response.Headers.Location = new Uri(uri);
            //-----------------------
            return response;
        }
    }
}
