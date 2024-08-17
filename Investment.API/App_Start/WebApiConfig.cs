using Autofac;
using Autofac.Integration.WebApi;
using Investment.Domain.CalculateTaxStrategy;
using Investment.Domain.Interface;
using Investment.Domain.Service;
using Investment.Domain.Strategy;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Investment.API
{
    public static class WebApiConfig
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CalculateCDBService>().As<ICalculateCDBService>();

            builder.RegisterType<CalculateTaxStrategyService>().As<ICalculateTaxStrategyService>();
            builder.RegisterType<CalculateTaxUpTo6Months>().As<CalculateTaxStrategyBase>();
            builder.RegisterType<CalculateTaxUpTo12Months>().As<CalculateTaxStrategyBase>();
            builder.RegisterType<CalculateTaxUpTo24Months>().As<CalculateTaxStrategyBase>();
            builder.RegisterType<CalculateTaxAfter24Months>().As<CalculateTaxStrategyBase>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
