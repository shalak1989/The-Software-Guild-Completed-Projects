using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }

            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            return View(studentVM);         
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {   

            var student = StudentRepository.Get(id);
            var studentVM = new StudentVM();
            studentVM.Student = student;
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());
            foreach (var courses in student.Courses)
            {
                studentVM.SelectedCourseIds.Add(courses.CourseId);
            }
            //set selected course IDS
            return View(studentVM);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM vm)
        {
            if (ModelState.IsValid)
            {
                //var name = Request.Form["Student.FirstName"];
                vm.Student.Courses = new List<Course>();

                foreach (var id in vm.SelectedCourseIds)
                    vm.Student.Courses.Add(CourseRepository.Get(id));

                vm.Student.Major = MajorRepository.Get(vm.Student.Major.MajorId);
                var studentVM = new StudentVM();       
                StudentRepository.Edit(vm.Student);

                return RedirectToAction("List");
            }

            vm.SetCourseItems(CourseRepository.GetAll());
            vm.SetMajorItems(MajorRepository.GetAll());
            return View(vm);
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            var studentVM = new StudentVM();
            studentVM.Student = student;
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetMajorItems(MajorRepository.GetAll());

            return View(studentVM);
        }

        [HttpPost]
        public ActionResult DeleteStudent(StudentVM vm)
        {
            StudentRepository.Delete(vm.Student.StudentId);
            return RedirectToAction("List");
        }

    }
}