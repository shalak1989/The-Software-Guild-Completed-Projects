﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_Portal.Models.Data;

namespace HR_Portal.Models.Repositories
{
    public static class PolicyRepository
    {
        private static List<Policy> _policies;

        static PolicyRepository()
        {
            _policies = new List<Policy>
            {
                new Policy {PolicyId = 1,
                    Category = new Category { CategoryId = 1, CategoryName = "Dress Code" },
                    Name = "Dress Code",
                    PolicyText = "The dress code for all employees is a clown suit" },

                new Policy {PolicyId = 2,
                    Category = new Category { CategoryId = 2, CategoryName = "Attendance" },
                    Name = "Attendance Policy",
                    PolicyText = "All employees are required to be present from 2 a.m. - 11:59 p.m." +
                    "remember, hail hydra"},

                new Policy {PolicyId = 3,
                    Category = new Category { CategoryId = 3, CategoryName = "Workplace Conduct" },
                    Name = "Witnesses Policy",
                    PolicyText = "All employees are required to never leave witnesses alive at a job site. " +
                    "Employees who leave witnesses alive will not be invited to the annual Christmas party."}

            };
        }

        public static IEnumerable<Policy> GetAll()
        {
            return _policies;
        }

    }
}
