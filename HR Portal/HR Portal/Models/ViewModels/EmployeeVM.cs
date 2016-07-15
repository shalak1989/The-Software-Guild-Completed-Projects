using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;
using HR_Portal.Models.Repositories;
using System.Web.Mvc;

namespace HR_Portal.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee employee { get; set; }
        public List<SelectListItem> employeeList { get; set; }


        public EmployeeVM()
        {
            employee = new Employee();
            employeeList = new List<SelectListItem>();
        }

        public void SetEmployeeList(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employeeList.Add(new SelectListItem()
                {
                    Value = employee.EmployeeId.ToString(),
                    Text = employee.FirstName + " " + employee.LastName,
                });

            }
        }

    }
}