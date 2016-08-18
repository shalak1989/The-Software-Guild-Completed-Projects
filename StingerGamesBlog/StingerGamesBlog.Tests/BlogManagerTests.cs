using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StingerGamesBlog.Models;
using StingerGamesBlog.DLL;
using StingerGamesBlog.BLL;

namespace StingerGamesBlog.Tests
{   
    [TestFixture]
    class BlogManagerTests
    {
        

        [Test]
        public void AddBlogPostWorks()
        {           
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            var blogList = mgr.GetAllBlogs();

            TinyMCEModelVM blog = new TinyMCEModelVM();
            blog.Content = "This content is a test";

            blog.Title = "Tomato";
            string authorName = "Caleb";
            string blogTags = "#taco, #nachos, #apple";

            mgr.AddBlogPost(blog, blogTags, authorName);

            var newBlogList = mgr.GetAllBlogs();

            Assert.AreEqual(3, newBlogList.ElementAt(2).BlogId);
        }

        [Test]
        public void GetIndividualPostWorks()
        {
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            var blog = mgr.GetIndividualBlogPost(1);

            Assert.AreEqual(1, blog.BlogId);
            Assert.True(blog.Author == "Caleb");
        }

        [Test]
        public void ConvertTagStringToListWorks()
        {
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            string tags = "#Bacon, #Sausage, #Cheese";

            var tagList = mgr.ConvertTagStringToList(tags);

            Assert.AreEqual(3, tagList.Count());
            Assert.True(tagList.ElementAt(1).TagName == "#Sausage");
        }

        [Test]
        public void AddStaticPageWorks()
        {
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            StaticPage page = new StaticPage();

            page.PageTitle = "DayZ";
            page.PageContent = "This is a zombie page";
            page.IsEnabled = true;

            mgr.AddStaticPage(page);

            var staticPageList = mgr.GetAllStaticPages();

            Assert.AreEqual(3, staticPageList.Count());
            Assert.True(staticPageList.ElementAt(2).PageTitle == "DayZ");
            Assert.True(staticPageList.ElementAt(2).PageId == 3);
        }

        [Test]
        public void GetUnapprovedBlogPostsWorks()
        {
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            var unapprovedBlogList = mgr.GetUnapprovedBlogPosts();

            Assert.AreEqual(1, unapprovedBlogList.Count());
            Assert.True(unapprovedBlogList.ElementAt(0).IsApproved == false);
        }

        [Test]
        public void FlipStaticPageEnabledStatusWorks()
        {
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            int pageId = 1;
            bool isEnabled = false;

            mgr.FlipStaticPageEnabledStatus(pageId, isEnabled);

            var staticPageList = mgr.GetAllStaticPages();

            Assert.True(staticPageList.ElementAt(0).IsEnabled == false);
        }

        [Test]
        public void GetAllBlogPostsWorks()
        {
            var repo = new FakeBlogRepo();
            BlogManager mgr = new BlogManager(repo);

            var blogPostList = mgr.GetAllBlogs();

            Assert.True(blogPostList.Count == 2);
        }


    }
}
