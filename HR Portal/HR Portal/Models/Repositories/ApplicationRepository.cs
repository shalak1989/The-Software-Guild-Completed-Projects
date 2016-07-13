using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;

namespace HR_Portal.Models.Repositories
{
    public static class ApplicationRepository
    {
        private static List<Application> _applications;

        static ApplicationRepository()
        {
            _applications = new List<Application>
            {
                new Application {FirstName = "Not", LastName = "A Killer", Position = "Wheelman"},
                new Application {FirstName = "I Am", LastName = "A Killer", Position = "Killer"},
                new Application {FirstName = "I May Be", LastName = "A Killer", Position = "Indecisive"},
            };
        }

        public static IEnumerable<Application> GetAll()
        {
            return _applications;
        }

        public static void Add(Application application)
        {
            _applications.Add(application);

        }
    }
}