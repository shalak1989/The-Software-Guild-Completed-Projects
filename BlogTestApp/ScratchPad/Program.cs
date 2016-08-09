using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTestApp.DLL;
using BlogTestApp.Models;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogRepo repo = new BlogRepo();
            BlogPost post = new BlogPost();

            post.PostName = "My story";
            post.PostDate = DateTime.Now;
            post.UserId = 1;
            post.Tags.Add(
                new Tag { TagId = 1, TagName = "#Emo"}
               
            );
            post.Tags.Add(
                new Tag { TagId = 2, TagName = "#IAmUnique" }

            );


        }
    }
}
