using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using AutoMapper;
using ObjectMetadata.Integration.AspNet.WebApi;
using ObjectMetadata.Samples.Common;

namespace ObjectMetadata.Samples.AspNet.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var binderProvider = new SimpleModelBinderProvider(typeof(MyModel), new RequestedJsonInjectingBinder());
            config.Services.Insert(typeof(ModelBinderProvider), 0, binderProvider);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Mapper.Initialize(cfg => { cfg.CreateMap<MyModel, MyModel>(); });
        }
    }
}
