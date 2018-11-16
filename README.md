AspNetPerformanceMetrics
========================

这是跟张队那Fork过来的,原项目地址在[AspNetPerformanceMetrics](https://github.com/geffzhang/AspNetPerformanceMetrics).

使用说明
1. 添加对AspNetPerformance项目的引用
2. 注册PerformanceAttribute,如:
	filters.Add(new MvcPerformanceAttribute());
3. 添加如下Nuget包
	NancyFx.Metrics-net40
	Nancy.Hosting.Aspnet
4. 创建 Bootstrapper 类,代码参考Sample.Mvc项目下的`Bootstrapper.cs`
5. 配置Web.config文件.
	1) 在configSections节点中添加`<section name="nancyFx" type="Nancy.Hosting.Aspnet.NancyFxSection" />`
	2) 在configuration根节点下添加`<nancyFx><bootstrapper assembly="Sample.Mvc" type="App.Bootstrapper" /> </nancyFx>`,其中assembly为当前web项目的名称
	3) 在appSettings节点下加`<add key="AspNetPerformance.EnablePerformanceMonitoring" value="true" />`,true为打开监控,false为关闭监控
6. 运行程序,打开监控地址[Metrics](http://localhost:1234/).

