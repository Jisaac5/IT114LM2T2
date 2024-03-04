using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Mod2LabPractice.App.Posts
{
    public class Post
    {
        public string Content{get;set;}
        public string PostedBy { get;set;}
        public DateTime PostedOn { get;set;}
    }
}