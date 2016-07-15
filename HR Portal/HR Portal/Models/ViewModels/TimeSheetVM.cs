using HR_Portal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Portal.Models.ViewModels
{
    public class TimeSheetVM
    {
        public TimeSheet TimeSheet { get; set; }
        public List<SelectListItem> EmployeesList { get; set; }

        public TimeSheetVM()
        {
            TimeSheet = new TimeSheet();
            EmployeesList = new List<SelectListItem>();
        }

        public void SetEmployeesList(IEnumerable<Employee> employee)
        {
            foreach (var e in employee)
            {
                EmployeesList.Add(new SelectListItem()
                {
                    Value = e.EmployeeId.ToString(),
                    Text = e.FirstName + " " + e.LastName
                });

            }
        }
    }
}