using HR_Portal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Portal.Models.Data;
using HR_Portal.Models.ViewModels;

namespace HR_Portal.Controllers
{
    public class HomeController : Controller
    {   
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewPolicies(int id)
        {
            var category = CategoryRepository.Get(id);            
            var policyVM = new PolicyVM();

            var model = PolicyRepository.GetAll();

            policyVM.
            
            return View(policyVM);
        }


    }
}