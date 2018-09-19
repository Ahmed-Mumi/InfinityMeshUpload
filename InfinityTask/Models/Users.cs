using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityTask.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}