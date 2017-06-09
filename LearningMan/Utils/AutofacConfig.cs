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
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {

            LearnersManager manager = LearnersManager.GetManager();
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(MessagesController).Assembly)
                .WithParameter("manager", manager);

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                
        }
    }
}