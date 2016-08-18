using StingerGamesBlog.DLL;
using StingerGamesBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StingerGamesBlog.BLL
{
    public class BlogManager : IBlogManager
    {
        private IBlogRepo _repo;

        public BlogManager(IBlogRepo repo)
        {
            _repo = repo;
        }
//Get Data from Sql
        public List<Blog> GetAllBlogs()
        {
            var blogList = _repo.GetAllBlogPosts();

            return blogList;
        }
        public Blog GetIndividualBlogPost(int blogId)
        {
            var blog = _repo.GetSingleBlogPosts(blogId);

            return blog;
        }
        public List<Blog> GetUnapprovedBlogPosts()
        {
            var unapprovedBlogList = _repo.GetUnapprovedBlogPosts();

            return unapprovedBlogList;
        }
        public List<Blog> GetBlogsByHashtag(int TagId)
        {
            var unapprovedBlogList = _repo.GetBlogsByHashtag(TagId);

            return unapprovedBlogList;
        }
        public List<StaticPage> GetAllStaticPages()
        {
            var staticPageList = _repo.GetAllStaticPages();

            return staticPageList;
        }
        public List<StaticPage> GetEnabledStaticPages()
        {
            var staticPageList = _repo.GetAllStaticPages().Where(s=>s.IsEnabled == true).ToList();

            return staticPageList;
        }
        public List<Blog> GetAllApprovedBlogPosts()
        {

            var approvedBlogPosts = _repo.GetAllApprovedBlogPosts().OrderByDescending(s => s.BlogId).ToList();

            return approvedBlogPosts;
        }

        public List<Tag> GetCommonTags()
        {
            var taglist = _repo.GetCommonTags();
            return taglist;
        }
//Post Data to Sql
        public void AddStaticPage(StaticPage newPage)
        {
            _repo.AddStaticPage(newPage);
        }
        public void AddBlogPost(TinyMCEModelVM BlogPostData, string TagString, string authorName)
        {
            Blog blogPost = new Blog();
            blogPost.Tags = ConvertTagStringToList(TagString);
            blogPost.Title = BlogPostData.Title;
            blogPost.Author = authorName;
            blogPost.Content = BlogPostData.Content;
            blogPost.BlogDate = DateTime.Now;

            _repo.AddPost(blogPost);
        }
//Data conversion
        public List<Tag> ConvertTagStringToList(string TagString)
        {
            TagString = Regex.Replace(TagString, @"\s+", "");

            List<Tag> NewTaglist = new List<Tag>();
            var TagArray = TagString.Split(',').ToList();
            foreach (var item in TagArray)
            {
                Tag tag = new Tag();
                tag.TagName = item;
                NewTaglist.Add(tag);
            }
            return NewTaglist;
        }

//Administration
        public void FlipStaticPageEnabledStatus(int PageId, bool IsEnabled)
        {
            _repo.FlipStaticPageEnabledStatus(PageId, IsEnabled);
        }

        public void ApproveBlogPost(int BlogId)
        {
            _repo.ApproveBlogPost(BlogId);
        }
    }
}
