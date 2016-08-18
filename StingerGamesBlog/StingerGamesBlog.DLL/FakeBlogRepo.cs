using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StingerGamesBlog.Models;
using StingerGamesBlog.DLL.Config;
using System.Data;

namespace StingerGamesBlog.DLL
{
    public class FakeBlogRepo : IBlogRepo
    {
        private static List<Blog> _blogPosts;
        private static List<Tag> _hashTags;
        private static List<StaticPage> _staticPages;

        public FakeBlogRepo()
        {

            _blogPosts = new List<Blog>
            {
                new Blog
                {
                    BlogId = 1,
                    BlogDate = DateTime.Parse("8-17-2016"),
                    Title = "Apocalypse",
                    Author = "Caleb",
                    Content = "This blog post is a test, This blog post is a test, This blog post is a test, This blog post is a test",
                    IsApproved = true,
                    Tags = new List<Tag>()
                    {
                        new Tag
                        {
                            TagId = 1,
                            TagName = "#CatVideo"
                        },

                        new Tag
                        {
                            TagId = 1,
                            TagName = "#DogVideo"
                        }
                    }
                },

                new Blog
                {
                    BlogId = 2,
                    BlogDate = DateTime.Parse("8-24-2016"),
                    Title = "Meowf",
                    Author = "James",
                    Content = "This blog post is a cat, This cat post is a blog, This cat blog is a post, This horse cat is a whale",
                    IsApproved = false,
                    Tags = new List<Tag>()
                    {
                        new Tag
                        {
                            TagId = 1,
                            TagName = "#Whale"
                        },

                        new Tag
                        {
                            TagId = 1,
                            TagName = "#Magic"
                        }
                    }
                }
            };

            _hashTags = new List<Tag>()
            {
                new Tag
                {
                    TagId = 1,
                    TagName = "#CatVideo"
                },

                new Tag
                {
                    TagId = 2,
                    TagName = "#DogVideo"
                }
            };

            _staticPages = new List<StaticPage>()
            {
                new StaticPage
                {
                    PageId = 1,
                    PageTitle = "About Us",
                    PageContent = "We are, we are, the youth of the nation",
                    IsEnabled = true,
                },

                new StaticPage
                {
                    PageId = 2,
                    PageTitle = "TESTER",
                    PageContent = "Can I has jobz?",
                    IsEnabled = true,
                }
            };


        }

        public int AddNewHashtag(string NewTagToAdd)
        {
            Tag tagtoAdd = new Tag();
            
            var tagList = GetHashtagIDs(_hashTags);
            int tagIdCount = tagList.Max(x => x.TagId);


            tagtoAdd.TagName = NewTagToAdd;
            tagtoAdd.TagId = tagIdCount + 1;

            _hashTags.Add(tagtoAdd);

            return (tagtoAdd.TagId);
        }

        public void AddPost(Blog blogPost)
        {
            var blogList = GetAllBlogPosts();
            int blogIdCount = blogList.Max(x => x.BlogId);

            blogPost.BlogId = blogIdCount + 1;

            _blogPosts.Add(blogPost);

        }

        public void AddStaticPage(StaticPage NewPage)
        {
            var staticPageList = GetAllStaticPages();
            int staticPageIdCount = staticPageList.Max(x => x.PageId);

            NewPage.PageId = staticPageIdCount + 1;

            _staticPages.Add(NewPage);

        }

        public void ApproveBlogPost(int BlogId)
        {
            var blogList = GetAllBlogPosts();

            foreach (var post in blogList)
            {
                if (post.BlogId == BlogId)
                {
                    post.IsApproved = true;
                }
            }
        }

        public void EnableStaticPage(int PageId)
        {
            var staticPageList = GetAllStaticPages();

            foreach (var staticPage in staticPageList)
            {
                if (staticPage.PageId == PageId)
                {
                    staticPage.IsEnabled = true;
                }
            }
        }

        public List<Blog> GetAllApprovedBlogPosts()
        {
            var blogList = GetAllBlogPosts();
            List<Blog> approvedBlogs = new List<Blog>();

            foreach (var post in blogList)
            {
                if (post.IsApproved == true)
                {
                    approvedBlogs.Add(post);
                }
            }

            return approvedBlogs;

        }

        public List<Blog> GetAllBlogPosts()
        {
            return _blogPosts;
        }

        public List<StaticPage> GetAllStaticPages()
        {
            return _staticPages;
        }

        public List<Tag> GetHashtagIDs(List<Tag> TagList)
        {
            return _hashTags;
        }

        public List<Tag> GetTagsPerPost(int BlogId)
        {
            var blogList = GetAllBlogPosts();

            Blog blog = blogList.First(x => x.BlogId == BlogId);

            return blog.Tags;
        }

        public List<Blog> GetUnapprovedBlogPosts()
        {
            var blogList = GetAllBlogPosts();
            List<Blog> unApprovedBlogs = new List<Blog>();

            foreach (var post in blogList)
            {
                if (post.IsApproved == false)
                {
                    unApprovedBlogs.Add(post);
                }
            }

            return unApprovedBlogs;
        }

        public void UpdateHashtagBlogTable(Blog BlogToAdd)
        {
            throw new NotImplementedException();
            //this is for a cross table which does not exist in the fake repo
        }

        public void FlipStaticPageEnabledStatus(int PageId, bool IsEnabled)
        {
            var staticPageList = GetAllStaticPages();

            staticPageList.First(x => x.PageId == PageId).IsEnabled = IsEnabled;
        }

        public List<Blog> GetBlogsByHashtag(int TagId)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetCommonTags()
        {
            throw new NotImplementedException();
        }

        public Blog GetSingleBlogPosts(int BlogId)
        {
            var blogList = GetAllBlogPosts();

            var blog = blogList.First(x => x.BlogId == BlogId);

            return blog;
        }
    }
}
