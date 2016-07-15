using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;

namespace HR_Portal.Models.Repositories
{
    public static class TimeSheetRepository
    {
        private static List<TimeSheet> _timesheets;

        static TimeSheetRepository()
        {
            _timesheets = new List<TimeSheet>
            {
                new TimeSheet {TimeSheetID = 1, EmpID = 1, FirstName = "Bob", LastName = "Smith", HoursWorked = 8, TimeSubmitted = DateTime.Parse("7/11/15 3:30 PM")},
                new TimeSheet {TimeSheetID = 2, EmpID = 1, FirstName = "Bob", LastName = "Smith", HoursWorked = 4, TimeSubmitted = DateTime.Parse("7/12/15 1:15 PM")},
                new TimeSheet {TimeSheetID = 3, EmpID = 2, FirstName = "Joe", LastName = "Crabapple", HoursWorked = 5, TimeSubmitted = DateTime.Parse("7/01/15 1:30 PM")},
                new TimeSheet {TimeSheetID = 4, EmpID = 2, FirstName = "Joe", LastName = "Crabapple", HoursWorked = 1, TimeSubmitted = DateTime.Parse("7/13/15 1:23 PM")},
                new TimeSheet {TimeSheetID = 5, EmpID = 3, FirstName = "Agent", LastName = "Rumple", HoursWorked = 13, TimeSubmitted = DateTime.Parse("7/16/15 3:13 PM")},
                new TimeSheet {TimeSheetID = 6, EmpID = 3, FirstName = "Agent", LastName = "Rumple", HoursWorked = 16, TimeSubmitted = DateTime.Parse("7/18/15 1:01 PM")},
            };
        }

        public static IEnumerable<TimeSheet> GetAll()
        {
            return _timesheets;
        }

        public static List<TimeSheet> Get(int employeeId)
        {

            return _timesheets.Where(e => e.EmpID == employeeId).ToList();
        }

        public static void Add(TimeSheet timesheet)
        {
            _timesheets.Add(timesheet);
        }

        public static void Delete(int timeSheetId)
        {
            _timesheets.RemoveAll(e => e.TimeSheetID == timeSheetId);
        }

        internal static object GetSingleTimeSheet(int timeSheetId)
        {
            return _timesheets.First(e => e.TimeSheetID == timeSheetId);
        }
    }
}