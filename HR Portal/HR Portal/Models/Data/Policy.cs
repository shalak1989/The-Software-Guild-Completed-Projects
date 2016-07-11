using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Portal.Models.Data
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string PolicyText { get; set; }
    }
}