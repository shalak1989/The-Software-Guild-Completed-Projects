using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StingerGamesBlog.Models
{
    public class AdminVM
    {
        public List<Blog> BlogList{ get; set; }
        public List<StaticPage> PageList { get; set; }
    }
}