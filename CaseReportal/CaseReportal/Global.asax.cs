﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using CaseReportal.Model;
using CaseReportal.Models;

namespace CaseReportal
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerProviderAccessor
    {
        private static ContainerProvider _containerProvider;

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<ModelModule>();
            builder.RegisterType<AccountMembershipService>().InstancePerHttpRequest();
            _containerProvider = new ContainerProvider(builder.Build());
            // Set the controller factory using the container provider.
            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}