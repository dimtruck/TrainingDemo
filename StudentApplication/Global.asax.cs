using Castle.Windsor;
using Castle.Windsor.Installer;
using Domain.Models;
using StudentApplication.Helpers;
using StudentApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "StudentRoute",
                "Student/{action}",
                new { controller = "Student", action = "Index" });
            routes.MapRoute(
                "StudentConstrainedRoute",
                "{school}",
                new { controller = "Student", action = "List" },
                new { school = @"\w*"});

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterMappers();
            log4net.Config.XmlConfigurator.Configure();
            RegisterIoC();
        }

        private void RegisterIoC()
        {
            //create new container
            //get all installers and register components specified there
            var container = new WindsorContainer().
                Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            //specifies a different controller factory from default
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            

        }

        private void RegisterMappers()
        {
            AutoMapper.Mapper.CreateMap<Student, StudentViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.ResolveUsing<FullNameResolver>())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.ResolveUsing<DateOfBirthResolver>())
                .ForMember(dest => dest.Grade, opt => opt.Ignore());
        }
    }
}