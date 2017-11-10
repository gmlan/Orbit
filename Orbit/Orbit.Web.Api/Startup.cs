using Autofac;
using Autofac.Integration.WebApi;
using Com.Qualcomm.Qswat.Service.Common;
using Microsoft.Owin;
using Orbit.Web.Api.Ioc;
using Owin;
using System.Web.Http;
using Com.Qualcomm.Qswat.Core.Interface;

[assembly: OwinStartup(typeof(Orbit.Web.Api.Startup))]

namespace Orbit.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            DependencyRegister.Register(builder);
            var container = builder.Build();

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            // var dependencyResolver = new AutofacDependencyResolver(container);

            var dependencyWebApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyWebApiResolver;
            ConfigureAuth(app);
        }
    }
}
