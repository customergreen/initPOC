﻿using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace CustomerGreen.Web.Capsule.Modules
{

    public class ControllerCapsuleModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            // Register the MVC Controllers
            //builder.RegisterControllers(Assembly.Load("CustomerGreen.Web"));

            // Register the Web API Controllers
            //builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterApiControllers(Assembly.Load("CustomerGreen.Web"));

        }
    }
}