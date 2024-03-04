using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mod2LabPractice.App.Posts
{
    public class PostRepository
    {
        public IEnumerable<Post> GetAllPosts() 
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Tools\Mod2Practice\Mod2LabPractice\Mod2LabPractice\App_Data\TwitterClone.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Posts";

                //Using ExecuteReader directly instead of casting to IDataRecord... copy isn't complete
                //var reader = command.ExecuteReader();
                //var posts = new List<Post>();

                //while (reader.Read())
                //{
                //    posts.Add(new Post()
                //    { 
                        
                //    }
                //        );
                //}

                //return posts;

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Post()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBy"],
                        PostedOn = (DateTime)row["postedOn"],
                        }
                    )
                    .ToList();
            }
        }

        public IEnumerable<Post> GetPostOfUser(string username)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Tools\Mod2Practice\Mod2LabPractice\Mod2LabPractice\App_Data\TwitterClone.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"SELECT * FROM Posts WHERE PostedBy = @username";
                command.Parameters.AddWithValue("username", username);

                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Post()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBy"],
                        PostedOn = (DateTime)row["postedOn"],
                    }
                    )
                    .ToList();
            }
        }

        public void CreatePost(Post post)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Tools\Mod2Practice\Mod2LabPractice\Mod2LabPractice\App_Data\TwitterClone.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"INSERT INTO Posts(content, postedOn, postedBy) " +
                $"VALUES (@content, @postedOn, @postedBy)";
                command.Parameters.AddWithValue("content", post.Content);
                command.Parameters.AddWithValue("postedOn", post.PostedOn);
                command.Parameters.AddWithValue("postedBy", post.PostedBy);

                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        //public IEnumerable<Post> GetAllPosts() {
        //    return new List<Post>() {
        //        new Post()
        //        {
        //            Content = "Hello world",
        //            PostedBy = "joblipat",
        //            PostedOn = DateTime.Now,
        //        },
        //        new Post()
        //        {
        //            Content = "Hello new world",
        //            PostedBy = "joeama",
        //            PostedOn = DateTime.Now,
        //        },
        //        new Post()
        //        {
        //            Content = "Hello new new world",
        //            PostedBy = "joebiden",
        //            PostedOn = DateTime.Now,
        //        }
        //    };
    }
}
