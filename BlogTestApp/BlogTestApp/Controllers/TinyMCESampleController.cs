using System.Web.Mvc;
using BlogTestApp.Models;
using BlogTestApp.DLL;
using System;
using System.Collections.Generic;

namespace BlogTestApp.Controllers {

    public class TinyMCESampleController : Controller {

        BlogRepo repo = new BlogRepo();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(BlogPost blogPostData)
        {
            BlogPost blogPost = new BlogPost();

            blogPost.PostName = blogPostData.PostName;
            blogPost.Post = blogPostData.Post;
            blogPost.PostDate = DateTime.Now;
            blogPost.Tags = new List<Tag>
            {
                new Tag {TagId = 1},
            };

            blogPost.UserId = 2;

            repo.AddPost(blogPost);

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult ViewBlogPosts()
        {
            List<BlogPost> blogPosts = new List<BlogPost>();

            blogPosts = repo.GetAllBlogPosts();

            return View(blogPosts);
        }

    }
}