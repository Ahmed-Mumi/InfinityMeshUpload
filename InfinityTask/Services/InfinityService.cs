using InfinityTask.DAL;
using InfinityTask.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityTask.Services
{
    public class InfinityService : IInfityService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Users> GetUsersBySearchAndOrder (string search)
        {
            return unitOfWork.UsersRepository.Get(p => p.Name == search || p.Email == search || string.IsNullOrEmpty(search), 
                orderBy: q => q.OrderBy(n => n.Name));
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return unitOfWork.BlogRepository.GetAll();
        }
        public IEnumerable<Blog> GetBlogsByDate(int id, DateTime? PublishFrom, DateTime? PublishTo)
        {
            return unitOfWork.BlogRepository.Get((x => x.UserId == id && ((x.PublishingDateTime >= PublishFrom && x.PublishingDateTime <= PublishTo)
              || (PublishFrom == null || PublishTo == null))), orderBy: q => q.OrderBy(d => d.PublishingDateTime));
        }
        public Users GetUserLogin(string Username, string Password)
        {
            return unitOfWork.UsersRepository.GetOne(x => x.Username == Username && x.Password == Password);
        }
        public Blog GetBlogById(int id)
        {
            return unitOfWork.BlogRepository.GetByID(id);
        }
        public void InsertNewBlog(Blog blog)
        {
            unitOfWork.BlogRepository.Insert(blog);
        }
        public Users GetUserByIdFilter(int id)
        {
            return unitOfWork.UsersRepository.GetOne(x => x.Id == id);
        }
        public void Save()
        {
            unitOfWork.Save();
        }
    }
}