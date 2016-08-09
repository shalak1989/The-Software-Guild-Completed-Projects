using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BlogTestApp.Models;

namespace BlogTestApp.DLL
{
    public class BlogRepo
    {
        public void AddPost(BlogPost blogPost)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "AddNewPost";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostName", blogPost.PostName);
                cmd.Parameters.AddWithValue("@Post", blogPost.Post);
                cmd.Parameters.AddWithValue("@PostDate", blogPost.PostDate);
                cmd.Parameters.AddWithValue("@UserId", blogPost.UserId);
                cmd.Parameters.AddWithValue("@TagId", blogPost.Tags.ElementAt(0).TagId);

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

        public List<BlogPost> GetAllBlogPosts()
        {
            List<BlogPost> blogPosts = new List<BlogPost>();

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

        private BlogPost PopulateBlogPostsFromDataReader(SqlDataReader dr)
        {
            BlogPost blogPost = new BlogPost();

            blogPost.BlogId = (int)dr["BlogId"];
            blogPost.PostName = dr["PostName"].ToString();
            blogPost.PostDate = (DateTime)dr["PostDate"];
            //for (int i = 0; i < blogPost.Tags.Count(); i++)
            //{
            //    blogPost.Tags.ElementAt(i).TagId = (int)dr["TagId"];
            //}
            blogPost.UserId = (int)dr["UserId"];
            blogPost.Post = dr["Post"].ToString();

            return blogPost;           
             
        }
    }
}

//private Player PopulatePlayerFromDataReader(SqlDataReader dr)
//{
//    Player player = new Player();

//    player.PlayerId = (int)dr["PlayerId"];
//    player.FirstName = dr["FirstName"].ToString();
//    player.LastName = dr["LastName"].ToString();
//    player.JerseyNumber = (int)dr["JerseyNumber"];
//    player.Position.PositionId = (int)dr["PositionId"];
//    player.Position.PositionName = dr["PositionName"].ToString();
//    player.Team.TeamId = (int)dr["TeamId"];
//    player.Team.Name = dr["Name"].ToString();
//    if (dr["PreviousYearsBattingAverage"] != DBNull.Value)
//    {
//        player.PreviousYearsBattingAverage = (decimal)dr["PreviousYearsBattingAverage"];
//    }
//    player.YearsPlayed = (int)dr["YearsPlayed"];

//    return player;
//}

