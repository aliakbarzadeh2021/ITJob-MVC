using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ITJob.Infrastructure.Startup;
using Newtonsoft.Json;
using WebApiContrib.IoC.CastleWindsor;

namespace ITJob.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                //				defaults: new { controller = "Home", action = "Index" }

                defaults: new { id = RouteParameter.Optional }
            );


            // to instanciate ApiControllers without default Constructor
            // we must Set DependencyResolver for web app HttpConfiguration
            // a nuget extension is required: WebApiContrib.IoC.CastleWindsor
            config.DependencyResolver = new WindsorResolver(InfrastructureBootstrapper.Container);


            // for remove "k__backingfield"
            // from fields in classes that Serializable
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
        }
    }
}
