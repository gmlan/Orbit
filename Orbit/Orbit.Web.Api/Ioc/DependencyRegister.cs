using Autofac;
using Autofac.Integration.WebApi;
using Com.Qualcomm.Qswat.Data.Context;
using Com.Qualcomm.Qswat.Data.Repositories;
using Com.Qualcomm.Qswat.Service;
using Com.Qualcomm.Qswat.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection;

namespace Orbit.Web.Api.Ioc
{
    public static class DependencyRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            //Register DB layer
            builder.RegisterGeneric(typeof(EfRepository<>)).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<EfContext>()
                .AsImplementedInterfaces()
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            //Register Service Layer
            builder.RegisterGeneric(typeof(GenericBusinessServices<>)).AsImplementedInterfaces().InstancePerLifetimeScope();

            var list = new List<Type>
            {
                typeof(UserService),
                typeof(IssueService),
            };

            list.ForEach(m =>
            {
                builder.RegisterType(m)
                    .AsSelf()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            });

            //registering api controller
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}