using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sample.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Metric.Config
               .WithHttpEndpoint("http://localhost:1234/")
               .WithAllCounters()
               .WithReporting(config => config.WithCSVReports(@"c:\temp\csv", TimeSpan.FromSeconds(10))
               .WithTextFileReport(@"C:\temp\reports\metrics.txt", TimeSpan.FromSeconds(10)));
        }

        protected void Application_End()
        {
            AspNetPerformance.PerformanceMetricFactory.CleanupPerformanceMetrics();
        }
    }
}
