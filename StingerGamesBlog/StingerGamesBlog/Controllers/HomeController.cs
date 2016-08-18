using System.Linq;
using System.Web.Mvc;
using StingerGamesBlog.Models;
using StingerGamesBlog.DLL;
using StingerGamesBlog.BLL;
using Microsoft.AspNet.Identity;

namespace StingerGamesBlog.Controllers
{
    public class HomeController : Controller
    {
        IBlogManager _mgr;

        public HomeController(IBlogManager mgr)
        {
            _mgr = mgr;
        }
//Views
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("ViewBlogPosts");
        }
        [HttpGet]
        public ActionResult ViewStaticPage(int PageId)
        {
            PageListVM PageList = new PageListVM(); ;
            PageList.pageList = _mgr.GetAllStaticPages();
            StaticPage model = PageList.pageList.FirstOrDefault(s => s.PageId == PageId);
            return View(model);
        }
        [HttpGet]
        public ActionResult ViewBlogPost(int blogId)
        {
            var getBlog = _mgr.GetIndividualBlogPost(blogId);

            return View(getBlog);
        }
        [HttpGet]
        public ActionResult ViewBlogPosts()
        {
            BlogListVM blogPosts = new BlogListVM();
            blogPosts.BlogList = _mgr.GetAllApprovedBlogPosts();

            return View(blogPosts);
        }

        
        [HttpGet]
        public ActionResult GetBlogsByHashtag(int TagId)
        {
            BlogListVM blogPosts = new BlogListVM();
            blogPosts.BlogList = _mgr.GetBlogsByHashtag(TagId);

            return View("ViewBlogPosts", blogPosts);
        }

        public ActionResult _sideBar()
        {
            ViewBag.IsAdmin = User.IsInRole("Admin");
            ViewBag.IsContributor = User.IsInRole("Contributor");

            PageListVM PageList = new PageListVM(); ;
            PageList.pageList = _mgr.GetEnabledStaticPages();
            return PartialView(PageList);
        }

        public ActionResult _commonTagList()
        {
            var taglist=  _mgr.GetCommonTags();
            return PartialView(taglist);
        }

        //Administration
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Admin()
        {
            AdminVM manager = new AdminVM();

            manager.BlogList = _mgr.GetUnapprovedBlogPosts();
            manager.PageList = _mgr.GetAllStaticPages();

            return View(manager);
        }
        [HttpPost]
        public void ApprovePost(int BlogId)
        {
            _mgr.ApproveBlogPost(BlogId);
        }
        [HttpPost]
        public void FlipStaticPageEnabledStatus(int PageId, bool IsEnabled)
        {
            _mgr.FlipStaticPageEnabledStatus(PageId, IsEnabled);
        }


//Creation Actions
        [HttpGet]
        public ActionResult CreateBlogPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlogPost(TinyMCEModelVM blogPostData, string TagString)
        {
            string rawAuthorName = User.Identity.GetUserName();
            int indexToRemove = rawAuthorName.IndexOf("@");
            string authorName = rawAuthorName.Substring(0, indexToRemove);

            _mgr.AddBlogPost(blogPostData, TagString, authorName);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult CreateStaticPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStaticPage(TinyMCEModelVM blogPostData)
        {
            StaticPage newPage = new StaticPage();
            newPage.PageTitle = blogPostData.Title;
            newPage.PageContent = blogPostData.Content;
            _mgr.AddStaticPage(newPage);
            return RedirectToAction("Index");
        }
    }
}