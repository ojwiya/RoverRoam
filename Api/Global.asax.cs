﻿using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //NinjectModule registrations = new NinjectRegistrations();
            //var kernel = new StandardKernel(registrations);
            //var ninjectResolver = new NinjectDependencyResolver(kernel);

            //DependencyResolver.SetResolver(ninjectResolver); 
            //GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver;
        }
    }
}
