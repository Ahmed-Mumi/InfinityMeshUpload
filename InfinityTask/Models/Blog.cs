using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinityTask.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public DateTime PublishingDateTime { get; set; }
        public virtual Users User { get; set; }
        public int UserId { get; set; }
    }
}