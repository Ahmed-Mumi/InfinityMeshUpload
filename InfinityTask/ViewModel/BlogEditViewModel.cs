using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinityTask.ViewModel
{
    public class BlogEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is requireddddddddddddddddddddddddd.")]
        [MaxLength(40, ErrorMessage = "Title can't be longer then 64 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Summary is required.")]
        [MaxLength(350, ErrorMessage = "Summary can't be longer then 350 characters")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        [MaxLength(3500, ErrorMessage = "Content can't be longer then 3500 characters")]
        [AllowHtml]
        public string Content { get; set; }
        [Required(ErrorMessage = "PublishingDateTime is required.")]
        public DateTime Now { get; set; } = DateTime.Now;
        [GreaterThanOrEqualTo("Now")]
        [DataType(DataType.Date)]
        public DateTime PublishingDateTime { get; set; }
        public int UserId { get; set; }

        public bool Successful { get; set; } = false;
    }
}