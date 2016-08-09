using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogTestApp.Models
{
    public class BlogPost
    {   
        public int BlogId { get; set; }
        public string PostName { get; set; }
        [AllowHtml]
        public string Post { get; set; }
        public DateTime PostDate { get; set; }
        public int UserId { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
