using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Portal.Models.Data
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        DateTime HireDate { get; set; }
        public int TotalHoursWorked { get { return TimeSheetList.Sum(t => t.HoursWorked); } }
        public List<TimeSheet> TimeSheetList { get; set; }
    }
}