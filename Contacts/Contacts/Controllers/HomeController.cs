using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var database = new FakeContactDatabase();
            var contacts = database.GetAll();//get contacts from the database
            return View(contacts);//send the contacts to the view
        }

        public ActionResult Add()
        {
            var model = new Contact();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddContact(Contact c)
        {
            var database = new FakeContactDatabase();
            database.Add(c);//add the new contact to the database
            return RedirectToAction("Index");//tell the browser to navigate to /home/index
        }

        public ActionResult Edit(int id)
        {
            var database = new FakeContactDatabase();
            var contact = database.GetById(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            var database = new FakeContactDatabase();
            database.Edit(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteContact(int id)
        {
            var database = new FakeContactDatabase();
            database.Delete(id);
            var contacts = database.GetAll();
            return View("Index", contacts);
        }

    }
}