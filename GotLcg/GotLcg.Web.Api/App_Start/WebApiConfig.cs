using System;
using System.IO;
using System.Web.Http;
using GotLcg.Logger.Implementation;
using GotLcg.Logger.Interfaces;
using GotLcg.Web.Api.App_Data.Bootstrap;
using Microsoft.Practices.Unity;

namespace GotLcg.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // IoC configuration.
            string webApiProjectPath = AppDomain.CurrentDomain.BaseDirectory;
            string logFilesPath = Path.Combine(webApiProjectPath, "Logs", "startup-log-{Date}.txt");
            ILogger logger = new SerilogLoggerAdapter(logFilesPath);
            IUnityContainer container = new UnityContainer();

            config.DependencyResolver = new UnityResolver(container, logger);

            // Web API configuration and services.

            // Web API routes.
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}