using InfinityTask.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTask.Services
{
    public interface IInfityService
    {
        IEnumerable<Users> GetUsersBySearchAndOrder(string search);
        IEnumerable<Blog> GetAllBlogs();
        IEnumerable<Blog> GetBlogsByDate(int id, DateTime? PublishFrom, DateTime? PublishTo);
        Users GetUserLogin(string Username, string Password);
        Blog GetBlogById(int id);
        Users GetUserByIdFilter(int id);
        void InsertNewBlog(Blog blog);
        void Save();
    }
}
