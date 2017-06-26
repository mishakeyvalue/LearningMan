using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LearningMan.Utils
{
    public static class AutofacInitializer
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterServices();
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);                
        }

        private static void RegisterServices(this ContainerBuilder builder)
        {
            LearnersService service = LearnersService.GetManager();
            builder.RegisterApiControllers(typeof(MessagesController).Assembly)
                .WithParameter("service", service);
        }
    }
}