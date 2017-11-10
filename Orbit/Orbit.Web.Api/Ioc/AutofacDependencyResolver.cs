using Autofac;

namespace Orbit.Web.Api.Ioc
{
    internal class AutofacDependencyResolver
    {
        private IContainer container;

        public AutofacDependencyResolver(IContainer container)
        {
            this.container = container;
        }
    }
}