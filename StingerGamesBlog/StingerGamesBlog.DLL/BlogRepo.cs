using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StingerGamesBlog.Models;
using System.Data.SqlClient;
using StingerGamesBlog.DLL.Config;
using System.Data;

namespace StingerGamesBlog.DLL
{
    public class BlogRepo : IBlogRepo
    {
     //static pages

        public void AddStaticPage(StaticPage NewPage)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "AddNewStaticPage";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageTitle", NewPage.PageTitle);
                cmd.Parameters.AddWithValue("@PageContent", NewPage.PageContent);
                //need to find a way to attach multiple tags

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<StaticPage> GetAllStaticPages()
        {
            List<StaticPage> StaticPages = new List<StaticPage>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllStaticPages";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        StaticPages.Add(AssignStaticPagesDataFromDR(dr));
                    }
                }
                return StaticPages;
            }
        }
        private StaticPage AssignStaticPagesDataFromDR(SqlDataReader dr)
        {
            StaticPage StaticPageNew = new StaticPage();

            StaticPageNew.PageId = (int)dr["PageId"];
            StaticPageNew.PageTitle= dr["PageTitle"].ToString();
            StaticPageNew.PageContent = dr["PageContent"].ToString();
            StaticPageNew.IsEnabled = (bool)dr["IsEnabled"];
            return StaticPageNew;

        }
        public void FlipStaticPageEnabledStatus(int PageId, bool IsEnabled)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                if(IsEnabled)
                    cmd.CommandText = "EnableStaticPage";
                else
                    cmd.CommandText = "DisableStaticPage";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PageId", PageId);
                //need to find a way to attach multiple tags

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record created successfully");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        
        //blog posts
        public void AddPost(Blog blogPost)
        {
            blogPost.Tags= GetHashtagIDs(blogPost.Tags);
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "AddNewPost";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", blogPost.Title);
                cmd.Parameters.AddWithValue("@BlogContent", blogPost.Content);
                cmd.Parameters.AddWithValue("@PostDate", blogPost.BlogDate);
                cmd.Parameters.AddWithValue("@Author", blogPost.Author);

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            blogPost.BlogId = (int)dr["BlogId"];
                            break;
                        }
                    }
                Console.WriteLine("Record created successfully");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            UpdateHashtagBlogTable(blogPost);
        }
        public List<Tag> GetHashtagIDs(List<Tag> TagList)
        {
            List<Tag> AllTags = new List<Tag>();
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllHashtags";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tag newtag = new Tag();
                        newtag.TagId = (int)dr["TagId"];
                        newtag.TagName = dr["TagName"].ToString();
                        AllTags.Add(newtag);
                    }
                }
            }

            foreach (var item in TagList)
            {
                var tagfound = false;
                foreach (var tag in AllTags)
                {
                    if(tag.TagName == item.TagName)
                    {
                        item.TagId = tag.TagId;
                        tagfound = true;
                    }
                }
                if (tagfound == false)
                {
                        item.TagId = AddNewHashtag(item.TagName);
                }
            }
            return TagList;
        }
        public int AddNewHashtag(string NewTagToAdd)
        {
            int NewTagId = 0;
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "AddNewHashtag";
                cmd.CommandType = CommandType.StoredProcedure;
                //if I have a parameter
                cmd.Parameters.AddWithValue("@TagName", NewTagToAdd);
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        NewTagId = (int)dr["TagId"];
                    }
                }
            }
            return NewTagId;
        }
        public void UpdateHashtagBlogTable(Blog BlogToAdd)
        {
            foreach (var item in BlogToAdd.Tags)
            {
                using (var cn = new SqlConnection(Settings.ConnectionString))
                {
                    var cmd = new SqlCommand();
                    cmd.CommandText = "UpdateBlogHashtagCrossTable";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogId", BlogToAdd.BlogId);
                    cmd.Parameters.AddWithValue("@TagId", item.TagId);

                    try
                    {
                        cmd.Connection = cn;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Record created successfully");
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        public void ApproveBlogPost(int BlogId)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "ApproveBlogPost";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogId", BlogId);
                //need to find a way to attach multiple tags

                try
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record created successfully");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public List<Tag> GetTagsPerPost(int BlogId)
        {
            List<Tag> blogTags = new List<Tag>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetTagsPerPost";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogId", BlogId);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tag newTag = new Tag();
                        newTag.TagId = (int)dr["TagId"];
                        newTag.TagName = dr["TagName"].ToString();
                        blogTags.Add(newTag);
                    }
                }
                return blogTags;
            }
        }
        public List<Blog> GetBlogsByHashtag(int TagId)
        {
            List<Blog> blogPosts = new List<Blog>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetBlogsByHashtag";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TagId", TagId);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogPosts.Add(PopulateBlogPostsFromDataReader(dr));
                    }
                }
             
            }
            foreach (var item in blogPosts)
            {
                item.Tags = GetTagsPerPost(item.BlogId);
            }
            return blogPosts;
        }
        public List<Tag> GetCommonTags()
        {
            List<Tag> blogTags = new List<Tag>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetCommonTags";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tag newTag = new Tag();
                        newTag.TagId = (int)dr["TagId"];
                        newTag.TagName = dr["TagName"].ToString();
                        blogTags.Add(newTag);
                    }
                }
                return blogTags;
            }
        }
        public List<Blog> GetAllBlogPosts()
        {
            List<Blog> blogPosts = new List<Blog>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllBlogPosts";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogPosts.Add(PopulateBlogPostsFromDataReader(dr));
                    }
                }
                return blogPosts;
            }
        }
        public Blog GetSingleBlogPosts(int BlogId)
        {
            Blog blog = new Blog();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetSingleBlogPosts";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BlogId", BlogId);
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blog  = PopulateBlogPostsFromDataReader(dr);
                    }
                }
                return blog;
            }
        }
        public List<Blog> GetAllApprovedBlogPosts()
        {
            List<Blog> blogPosts = new List<Blog>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetAllApprovedBlogPosts";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogPosts.Add(PopulateBlogPostsFromDataReader(dr));
                    }
                }
            }
            foreach (var item in blogPosts)
            {
                item.Tags = GetTagsPerPost(item.BlogId);
            }
            return blogPosts;
        }
        public List<Blog> GetUnapprovedBlogPosts()
        {
            List<Blog> blogPosts = new List<Blog>();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetUnapprovedBlogPosts";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogPosts.Add(PopulateBlogPostsFromDataReader(dr));
                    }
                }
                return blogPosts;
            }
        }
        private Blog PopulateBlogPostsFromDataReader(SqlDataReader dr)
        {
            Blog blogPost = new Blog();

            blogPost.BlogId = (int)dr["BlogId"];
            blogPost.Title = dr["Title"].ToString();
            blogPost.BlogDate = (DateTime)dr["PostDate"];
            blogPost.Author = dr["Author"].ToString();
            blogPost.Content = dr["BlogContent"].ToString();
            blogPost.IsApproved = (bool)dr["IsApproved"];

            return blogPost;

        }
    }
}
