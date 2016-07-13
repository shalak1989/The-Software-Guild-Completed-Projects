using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;

namespace HR_Portal.Models.Repositories
{
    public static class EmployeeRepository
    {
        private static List<Employee> _employees;

        static EmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee {EmployeeId = 1, FirstName = "Bob", LastName = "Smith", TimeSheetList = "taco", TotalHoursWorked = 60 },
                new Employee {CategoryId = 2, CategoryName = "Attendance" },
                new Employee {CategoryId = 3, CategoryName = "Workplace Conduct" }
            };
        }

        public static IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public static Category Get(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public static void Add(Category category)
        {
            _categories.Add(category);
        }

        public static void Delete(int categoryId)
        {
            _categories.RemoveAll(c => c.CategoryId == categoryId);
        }
    }
}