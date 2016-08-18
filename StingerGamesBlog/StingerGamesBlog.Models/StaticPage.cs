using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingerGamesBlog.Models
{
    public class StaticPage
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageContent { get; set; }
        public bool IsEnabled { get; set; }
    }
}
