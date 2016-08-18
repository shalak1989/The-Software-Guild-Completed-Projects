using System.Collections.Generic;
using StingerGamesBlog.Models;

namespace StingerGamesBlog.DLL
{
    public interface IBlogRepo
    {
        int AddNewHashtag(string NewTagToAdd);
        void AddPost(Blog blogPost);
        void AddStaticPage(StaticPage NewPage);
        void ApproveBlogPost(int BlogId);
        void FlipStaticPageEnabledStatus(int PageId, bool IsEnabled);
        List<Blog> GetAllApprovedBlogPosts();
        List<Blog> GetAllBlogPosts();
        List<StaticPage> GetAllStaticPages();
        List<Blog> GetBlogsByHashtag(int TagId);
        List<Tag> GetCommonTags();
        List<Tag> GetHashtagIDs(List<Tag> TagList);
        Blog GetSingleBlogPosts(int BlogId);
        List<Tag> GetTagsPerPost(int BlogId);
        List<Blog> GetUnapprovedBlogPosts();
        void UpdateHashtagBlogTable(Blog BlogToAdd);
    }
}