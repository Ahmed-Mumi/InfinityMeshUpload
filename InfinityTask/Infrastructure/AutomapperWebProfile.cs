using InfinityTask.Models;
using InfinityTask.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfinityTask.Infrastructure
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<BlogEditViewModel, Blog>();
            CreateMap<Blog, BlogEditViewModel>();

            CreateMap<UsersViewModel.UserInfo, Users>();
            CreateMap<Users, UsersViewModel.UserInfo>();

            CreateMap<UsersViewModel.BlogInfo, Blog>();
            CreateMap<Blog, UsersViewModel.BlogInfo>();

            CreateMap<Users, Users>();

        }
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a => {
                a.AddProfile<AutomapperWebProfile>();
            });
        }
    }
}