using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Core;

namespace LearningMan.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
        }
    }
}