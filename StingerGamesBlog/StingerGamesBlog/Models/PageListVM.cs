using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StingerGamesBlog.Models
{
    public class PageListVM
    {
        public List<StaticPage> pageList;

        public PageListVM()
        {
            pageList = new List<StaticPage>{ };
        }


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)pageList).GetEnumerator();
        }
    }
}