using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using InfinityTask.Services;
using InfinityTask.Controllers;

namespace InfinityTask
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IInfityService, InfinityService>();
            container.RegisterType<IController, HomeController>("Home");

            return container;
        }
    }
}