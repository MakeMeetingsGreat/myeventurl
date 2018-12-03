using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Batch;
using Microsoft.OData.Edm;
using MyEventURL.Models;

namespace MyEventURL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null); //new line
            config.MapODataServiceRoute("odata", "odata", GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }


        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Board>("GetBoard");
            builder.EntitySet<Event>("GetEvent");
            builder.EntitySet<EngagementInfo>("GetEngagementInfo");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
