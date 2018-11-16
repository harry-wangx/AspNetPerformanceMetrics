AspNetPerformanceMetrics
========================

这是跟张队那Fork过来的,原项目地址在[AspNetPerformanceMetrics](https://github.com/geffzhang/AspNetPerformanceMetrics).

使用说明
1. 添加对AspNetPerformance项目的引用
2. 注册PerformanceAttribute,如:
	filters.Add(new MvcPerformanceAttribute());
3. 添加Nuget包`Metrics.NET-net40`
4. 编辑Global.asax.cs
...c#
        protected void Application_Start()
        {
            ....

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
...

5. 配置Web.config文件.
	1) 在appSettings节点下加`<add key="AspNetPerformance.EnablePerformanceMonitoring" value="true" />`,##true##为打开监控,##false##为关闭监控
6. 运行程序,打开监控地址[http://localhost:1234/](http://localhost:1234/).

