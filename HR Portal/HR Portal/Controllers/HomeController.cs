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
            category.CategoryId = categoryCount + 1;
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

            policy.PolicyId = policyCount + 1;

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

    }
}

//[HttpGet]
//public ActionResult Add()
//{
//    var viewModel = new StudentVM();
//    viewModel.SetCourseItems(CourseRepository.GetAll());
//    viewModel.SetMajorItems(MajorRepository.GetAll());
//    return View(viewModel);
//}

//[HttpPost]
//public ActionResult Add(StudentVM studentVM)
//{
//    if (ModelState.IsValid)
//    {
//        studentVM.Student.Courses = new List<Course>();

//        foreach (var id in studentVM.SelectedCourseIds)
//            studentVM.Student.Courses.Add(CourseRepository.Get(id));

//        studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

//        StudentRepository.Add(studentVM.Student);

//        return RedirectToAction("List");
//    }

//    studentVM.SetCourseItems(CourseRepository.GetAll());
//    studentVM.SetMajorItems(MajorRepository.GetAll());
//    return View(studentVM);
//}