using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Portal.Models.Data
{
    public class TimeSheet
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateSubmitted { get; set; }
        [Range(0, 16, ErrorMessage = "Hours worked must be less than or equal to 16")]
        public int HoursWorked { get; set; }
    }
}