using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mod2LabPractice.App.Posts;

namespace Mod2LabPractice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //public IEnumerable<Post> posts = new List<Post>() {
        //    new Post()
        //    {
        //        Content = "Hello world",
        //        PostedBy = "joblipat",
        //        PostedOn = DateTime.Now,
        //    },
        //    new Post()
        //    {
        //        Content = "Hello new world",
        //        PostedBy = "joeama",
        //        PostedOn = DateTime.Now,
        //    },
        //    new Post()
        //    {
        //        Content = "Hello new new world",
        //        PostedBy = "joebiden",
        //        PostedOn = DateTime.Now,
        //    }
        //};

        public IEnumerable<Post> posts = new List<Post>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //PostRepeater.DataSource = posts;
            //PostRepeater.DataBind();

            var repository = new PostRepository();


            repository.CreatePost(new Post()
            {
                Content = "This is a new post",
                PostedBy = "joebiden",
                PostedOn = DateTime.Now,
            }
            );

            repository.GetPostOfUser("joebiden");
            //^ Originally had posts =  at the start, but something broke and removing that fixed it
        }


    }
}