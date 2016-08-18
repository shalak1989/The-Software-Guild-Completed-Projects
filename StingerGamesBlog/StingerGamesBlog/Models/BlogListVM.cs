using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StingerGamesBlog.Models
{
    public class BlogListVM
    {
        public List<Blog> BlogList;

        public BlogListVM()
        {
            BlogList = new List<Blog> { };
        }


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)BlogList).GetEnumerator();
        }
    }
}