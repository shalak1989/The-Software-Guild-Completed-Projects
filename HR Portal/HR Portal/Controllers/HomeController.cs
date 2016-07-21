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
        public ActionResult ViewPolicies(int? category)
        {
            PolicyVM policyViewModel = new PolicyVM();

            if (category == null)
            {
                policyViewModel.PolicyItems.AddRange(PolicyRepository.GetAll().ToList());
            }
            else
            {
                policyViewModel.PolicyItems.AddRange(PolicyRepository.GetAll().Where(p => p.Category.CategoryId == category).ToList());
            }

            policyViewModel.SetCategoryItems(CategoryRepository.GetAll());
            return View(policyViewModel);
        }

        [HttpGet]
        public ActionResult ViewPolicyItem(int policyId)
        {
            var policy = PolicyRepository.Get(policyId);

            return View(policy);
        }

        [HttpGet]
        public ActionResult ManagePolicies(int? category)
        {
            PolicyVM policyViewModel = new PolicyVM();

            if (category == null)
            {
                policyViewModel.PolicyItems.AddRange(PolicyRepository.GetAll().ToList());
            }
            else
            {
                policyViewModel.PolicyItems.AddRange(PolicyRepository.GetAll().Where(p => p.Category.CategoryId == category).ToList());
            }

            policyViewModel.SetCategoryItems(CategoryRepository.GetAll());
            return View(policyViewModel);
        }

        [HttpGet]
        public ActionResult DeletePolicy(int policyId)
        {
            var policy = PolicyRepository.Get(policyId);
            return View(policy);
        }

        [HttpPost]
        public ActionResult DeletePolicy(Policy policy)
        {
            PolicyRepository.Delete(policy.PolicyId);
            return RedirectToAction("ManagePolicies");
        }

        [HttpGet]
        public ActionResult ManageCategories()
        {
            var categories = CategoryRepository.GetAll();

            return View(categories);
        }

        [HttpGet]
        public ActionResult DeleteCategory(int categoryId)
        {
            var category = CategoryRepository.Get(categoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            CategoryRepository.Delete(category.CategoryId);
            return RedirectToAction("ManageCategories");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            Category category = new Category();
            var categoryList = CategoryRepository.GetAll();
            var categoryCount = categoryList.Max(c => c.CategoryId);
            category.CategoryId = categoryCount + 1;//bump the categoryId max to the post
            return View(category);
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryRepository.Add(category);
            return RedirectToAction("ManageCategories");
        }

        [HttpGet]
        public ActionResult AddPolicy()
        {
            Policy policy = new Policy();
            var viewModel = new AddPolicyVM();
            viewModel.SetCategoryItems(CategoryRepository.GetAll());

            var policyList = PolicyRepository.GetAll();
            var policyCount = policyList.Max(p => p.PolicyId);

            policy.PolicyId = policyCount + 1;//bump policyId count to the post method

            viewModel.Policy = policy;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddPolicy(Policy policy)
        {
            var category = CategoryRepository.Get(policy.Category.CategoryId);
            policy.Category.CategoryName = category.CategoryName;

            PolicyRepository.Add(policy);
            return RedirectToAction("ManagePolicies");
        }

        [HttpGet]
        public ActionResult apply()
        {
            Application application = new Application();

            return View(application);
        }

        [HttpPost]
        public ActionResult apply(Application application)
        {
            ApplicationRepository.Add(application);

            return RedirectToAction("apply");
        }

        [HttpGet]
        public ActionResult ViewTimeSheet(int? employeeId)
        {
            
            EmployeeVM employeeVM = new EmployeeVM();

            employeeVM.SetEmployeeList(EmployeeRepository.GetAll());
            if(employeeId.HasValue)
                employeeVM.employee = EmployeeRepository.Get(employeeId.Value);

            //employeeVM.employee.EmployeeId = employee.EmployeeId;

            return View(employeeVM);
        }

        [HttpGet]
        public ActionResult DeleteTimeSheet(int timeSheetId)
        {
            var timeSheet = TimeSheetRepository.GetSingleTimeSheet(timeSheetId);
            return View(timeSheet);
        }

        [HttpPost]
        public ActionResult DeleteTimeSheet(TimeSheet timeSheet)
        {
            TimeSheetRepository.Delete(timeSheet.TimeSheetID);
            return RedirectToAction("ViewTimeSheet");
        }

        [HttpGet]
        public ActionResult AddTimeSheet()
        {
            TimeSheetVM timeSheetVM = new TimeSheetVM();
            var timeSheetList = TimeSheetRepository.GetAll();
            var timeSheetCount = timeSheetList.Max(t => t.TimeSheetID);

            timeSheetVM.SetEmployeesList(EmployeeRepository.GetAll());
            timeSheetVM.TimeSheet.TimeSheetID = timeSheetCount + 1;

            return View(timeSheetVM);
        }

        [HttpPost]
        public ActionResult AddTimeSheet(TimeSheet timeSheet)
        {   
            if (ModelState.IsValid)
            {
                var employee = EmployeeRepository.Get(timeSheet.EmpID.Value);
                timeSheet.FirstName = employee.FirstName;
                timeSheet.LastName = employee.LastName;
                timeSheet.TimeSubmitted = DateTime.Now;
                TimeSheetRepository.Add(timeSheet);
                return RedirectToAction("ViewTimeSheet");
            }
            TimeSheetVM timeSheetVM = new TimeSheetVM();
            
            timeSheetVM.SetEmployeesList(EmployeeRepository.GetAll());

            return View(timeSheetVM);
           
        }



    }
}

//[HttpGet]
//public ActionResult ViewPolicies(int? category)
//{
//    PolicyVM policyViewModel = new PolicyVM();

//    if (category == null)
//    {
//        policyViewModel.PolicyItems.AddRange(PolicyRepository.GetAll().ToList());
//    }
//    else
//    {
//        policyViewModel.PolicyItems.AddRange(PolicyRepository.GetAll().Where(p => p.Category.CategoryId == category).ToList());
//    }

//    policyViewModel.SetCategoryItems(CategoryRepository.GetAll());
//    return View(policyViewModel);
//}

//[HttpGet]
//public ActionResult ViewPolicyItem(int policyId)
//{
//    var policy = PolicyRepository.Get(policyId);

//    return View(policy);
//}