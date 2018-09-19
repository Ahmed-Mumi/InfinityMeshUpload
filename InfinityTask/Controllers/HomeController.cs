using InfinityTask.DAL;
using InfinityTask.Models;
using InfinityTask.Services;
using InfinityTask.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfinityTask.Controllers
{
    public class HomeController : Controller
    {
        //moguće pogrešno/nepotrebno korištenje service layer-a (više nepotrebno nego pogrešno) jer nema neke prezahtjevne business logike osim jednostavnih 
        //if uslova te mapiranja
        //Jimmy Bogard(the creator of Automapper) said in AutoMapper 3.0, Portable Class Libraries and PlatformNotSupportedException
        //[...] if you whine about UI projects shouldn’t reference this library directly because of some silly faux architect-y reason(even referencing a 
        //certain smelly round vegetable), I will drive to your house and slap you silly.Get off your high horse and start being productive.
        private IInfityService service; 
        public HomeController(IInfityService service)
        {
            this.service = service;
        } 
        public ActionResult Index(int? page, string search)
        {
            UsersViewModel Model = new UsersViewModel();
            //var userAm = unitOfWork.UsersRepository.Get(p => p.Name == search || p.Email == search || string.IsNullOrEmpty(search), orderBy: q => q.OrderBy(n => n.Name));
            //var blogN1issue = unitOfWork.BlogRepository.GetAll();
            var userAm = this.service.GetUsersBySearchAndOrder(search);
            var blogN1issue = this.service.GetAllBlogs();
            if (!userAm.Any())
            {
                Model.msg = "There are no users..."; 
            }
            else
            {
                Model.users = userAm.Select(x => new UsersViewModel.UserInfo()
                {
                    Name = x.Name,
                    Email = x.Email,
                    Age = x.Age,
                    Id = x.Id,
                    //   mogući N+1 issue
                    //NumberOfBlogs = unitOfWork.BlogRepository.GetCount(z => z.UserId == x.Id)
                    NumberOfBlogs = blogN1issue.Count(z => z.UserId == x.Id)
                }).ToList().ToPagedList(page ?? 1, 5); 
            }
            return View(Model);
        }
        public ActionResult Profil(int id, int? page, DateTime? PublishFrom, DateTime? PublishTo)
        {
            UsersViewModel Model = new UsersViewModel();
            List<UsersViewModel.BlogInfo> blogInfo = new List<UsersViewModel.BlogInfo>();
            //var blogAm = unitOfWork.BlogRepository.Get((x => x.UserId == id && ((x.PublishingDateTime >= PublishFrom && x.PublishingDateTime <= PublishTo)
            //  || (PublishFrom == null || PublishTo == null))), orderBy: q => q.OrderBy(d => d.PublishingDateTime));
            var blogAm = this.service.GetBlogsByDate(id, PublishFrom, PublishTo);
            if (!blogAm.Any())
            {
                Model.msg = "There are no blogs..."; 
            }
            else
            {
                AutoMapper.Mapper.Map(blogAm, blogInfo);
                Model.blogovi = blogInfo.ToPagedList(page ?? 1, 3); 
            }
            if (id != 0)
            {
                Model.User = this.service.GetUserByIdFilter(id);
                Model.UserId = id;
            }
            else
                throw new Exception("Something went wrong...");
            return View(Model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel Model = new LoginViewModel();
            return View(Model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            var user = this.service.GetUserLogin(login.Username,login.Password);
            if (user != null)
                return RedirectToAction("Index");
            return RedirectToAction("Login");
        }
        public ActionResult AddEditBlog(int blogId, int userId)
        {
            BlogEditViewModel Model = new BlogEditViewModel();
            if (blogId > 0)
            {
                //Blog blog = unitOfWork.BlogRepository.GetByID(blogId); 
                Blog blog = this.service.GetBlogById(blogId);
                AutoMapper.Mapper.Map(blog, Model);
            }
            else
            {
                if(userId != 0)
                     Model.UserId = userId;
                else
                    throw new Exception("Something went wrong...");
            }
            return PartialView("Partial", Model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Save(string content, BlogEditViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Partial", blog);
            }
            Blog b;
            if (blog.Id == 0)
            {
                b = new Blog();
                //unitOfWork.BlogRepository.Insert(b);
                this.service.InsertNewBlog(b);
            }
            else
            {
                //b = unitOfWork.BlogRepository.GetByID(blog.Id);
                b = this.service.GetBlogById(blog.Id);
            }
            //if (!string.IsNullOrEmpty(content))
            //    blog.Content = content;
            //else
            //    blog.Content = "";
            AutoMapper.Mapper.Map(blog, b);
            this.service.Save();
            return RedirectToAction("Profil", new { id = blog.UserId });
        }
    }
}