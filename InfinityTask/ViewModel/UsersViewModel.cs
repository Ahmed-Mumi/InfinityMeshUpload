using InfinityTask.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityTask.ViewModel
{
    public class UsersViewModel
    {
        public class UserInfo
        {

            public int NumberOfBlogs { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Id { get; set; }
            public int Age { get; set; }
        }

        public class BlogInfo
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Summary { get; set; }
            public string Content { get; set; }
            public DateTime Now { get; set; } = DateTime.Now;
            public DateTime PublishingDateTime { get; set; }
            public int UserId { get; set; }
            public Users User { get; set; }
        }

        public IPagedList<UserInfo> users { get; set; }
        public Users User { get; set; }
        public List<UserInfo> Useriviewmodel { get; set; }
        public List<BlogInfo> Blogiviewmodel { get; set; }
        public IPagedList<BlogInfo> blogovi { get; set; }
        public List<Blog> listOfBlogs { get; set; }
        public List<Users> listOfUsers { get; set; }
        public int UserId { get; set; }
        public int NumberOfBlogs { get; set; }
        public string msg { get; set; }
    }
}