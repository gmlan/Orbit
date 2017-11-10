using Autofac;
using Com.Qualcomm.Qswat.Data.Context;
using Com.Qualcomm.Qswat.Data.Repositories;
using Com.Qualcomm.Qswat.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Com.Qualcomm.Qswat.Service.Test
{
    public static class StaticIoc
    {
        internal static IContainer TestContainer;

        public static void Register()
        {
            var builder = new ContainerBuilder();

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

            TestContainer = builder.Build();

        }
    }
}
