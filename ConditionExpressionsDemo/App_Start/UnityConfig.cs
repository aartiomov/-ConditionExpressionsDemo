using ConditionExpressionsDemo.Repository;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ConditionExpressionsDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IConditionService, InMemoryConditionService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICustomerRepository, FileCustomerRepository>(new ContainerControlledLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}