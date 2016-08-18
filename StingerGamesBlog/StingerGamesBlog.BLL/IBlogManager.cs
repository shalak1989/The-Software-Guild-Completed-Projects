using System.Collections.Generic;
using StingerGamesBlog.Models;

namespace StingerGamesBlog.BLL
{
    public interface IBlogManager
    {
        void AddBlogPost(TinyMCEModelVM BlogPostData, string TagString, string authorName);
        void AddStaticPage(StaticPage newPage);
        void ApproveBlogPost(int BlogId);
        List<Tag> ConvertTagStringToList(string TagString);
        void FlipStaticPageEnabledStatus(int PageId, bool IsEnabled);
        List<Blog> GetAllApprovedBlogPosts();
        List<Blog> GetAllBlogs();
        List<StaticPage> GetAllStaticPages();
        List<Blog> GetBlogsByHashtag(int TagId);
        List<Tag> GetCommonTags();
        List<StaticPage> GetEnabledStaticPages();
        Blog GetIndividualBlogPost(int blogId);
        List<Blog> GetUnapprovedBlogPosts();
    }
}