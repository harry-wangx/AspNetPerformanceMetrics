using Metrics;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            Metric.Config
               .WithHttpEndpoint("http://localhost:1234/")
               .WithAllCounters()
               .WithNancy(pipelines)
               .WithReporting(config => config.WithCSVReports(@"c:\temp\csv", TimeSpan.FromSeconds(10))
               .WithTextFileReport(@"C:\temp\reports\metrics.txt", TimeSpan.FromSeconds(10)));


            pipelines.AfterRequest += ctx =>
            {
                if (ctx.Response != null)
                {
                    ctx.Response
                        .WithHeader("Access-Control-Allow-Origin", "*")
                        .WithHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
                }
            };
        }

    }
}