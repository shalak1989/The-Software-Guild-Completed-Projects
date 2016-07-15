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
                new Employee {EmployeeId = 1, FirstName = "Bob", LastName = "Smith", TimeSheetList = TimeSheetRepository.Get(1), HireDate = DateTime.Parse("10/3/2015 3:30 PM")},
                new Employee {EmployeeId = 2, FirstName = "Joe", LastName = "Crabapple", TimeSheetList = TimeSheetRepository.Get(2), HireDate = DateTime.Parse("7/11/2016")}, 
                new Employee {EmployeeId = 3, FirstName = "Agent", LastName = "Rumple", TimeSheetList = TimeSheetRepository.Get(3), HireDate = DateTime.Parse("12/5/2013")},
            };
        }

        public static IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public static Employee Get(int employeeId)
        {
            var emp = _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            emp.TimeSheetList = TimeSheetRepository.Get(emp.EmployeeId);
            return emp; 
        }

        public static void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public static void Delete(int employeeId)
        {
            _employees.RemoveAll(e => e.EmployeeId == employeeId);
        }

        public static List<TimeSheet> BuildFakeTimeSheets(int? employeeId, string firstName, string lastName)
        {
            List<TimeSheet> timesheets = new List<TimeSheet>() {
                new TimeSheet {EmpID = employeeId , TimeSubmitted = DateTime.Now, FirstName = firstName, LastName = lastName, HoursWorked = 10, },
                new TimeSheet {EmpID = employeeId , TimeSubmitted = DateTime.Now.AddDays(1), FirstName = firstName, LastName = lastName, HoursWorked = 13, },
                new TimeSheet {EmpID = employeeId , TimeSubmitted = DateTime.Now.AddDays(2), FirstName = firstName, LastName = lastName, HoursWorked = 8, },
            };

            return timesheets;
        }
        


    }
}