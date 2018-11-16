AspNetPerformanceMetrics
========================

���Ǹ��Ŷ���Fork������,ԭ��Ŀ��ַ��[AspNetPerformanceMetrics](https://github.com/geffzhang/AspNetPerformanceMetrics).

ʹ��˵��
1. ��Ӷ�AspNetPerformance��Ŀ������
2. ע��PerformanceAttribute,��:`filters.Add(new MvcPerformanceAttribute())`,WebApi��Ŀ��Ҫͨ��`GlobalConfiguration.Configure()`����ע�ᵽ`HttpConfiguration`�����`Filters`������
3. ���Nuget��`Metrics.NET-net40`
4. �༭Global.asax.cs
```c#
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
```

5. ����Web.config�ļ�.
	1) ��appSettings�ڵ��¼�`<add key="AspNetPerformance.EnablePerformanceMonitoring" value="true" />`,**true**Ϊ�򿪼��,**false**Ϊ�رռ��
6. ���г���,�򿪼�ص�ַ�鿴: http://localhost:1234/
