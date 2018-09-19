using InfinityTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InfinityTask.DAL
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("ConnectionString")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}