using InfinityTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityTask.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MyContext context = new MyContext();
        private GenericRepository<Blog> blogRepository;
        private GenericRepository<Users> usersRepository;

        public GenericRepository<Blog> BlogRepository
        {
            get
            {
                if (this.blogRepository == null)
                {
                    this.blogRepository = new GenericRepository<Blog>(context);
                }
                return blogRepository;
            }
        }
        public GenericRepository<Users> UsersRepository
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<Users>(context);
                }
                return usersRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}