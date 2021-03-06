﻿using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation.Mvc;
using ItLabs.MyRecipes.Core.Automapper;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ItLabs.MyRecipes.API
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

            AutomapperBootstrap.Initialize();
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
