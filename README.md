AspNetPerformanceMetrics
========================

���Ǹ��Ŷ���Fork������,ԭ��Ŀ��ַ��[AspNetPerformanceMetrics](https://github.com/geffzhang/AspNetPerformanceMetrics).

ʹ��˵��
1. ��Ӷ�AspNetPerformance��Ŀ������
2. ע��PerformanceAttribute,��:
	filters.Add(new MvcPerformanceAttribute());
3. �������Nuget��
	NancyFx.Metrics-net40
	Nancy.Hosting.Aspnet
4. ���� Bootstrapper ��,����ο�Sample.Mvc��Ŀ�µ�`Bootstrapper.cs`
5. ����Web.config�ļ�.
	1) ��configSections�ڵ������`<section name="nancyFx" type="Nancy.Hosting.Aspnet.NancyFxSection" />`
	2) ��configuration���ڵ������`<nancyFx><bootstrapper assembly="Sample.Mvc" type="App.Bootstrapper" /> </nancyFx>`,����assemblyΪ��ǰweb��Ŀ������
	3) ��appSettings�ڵ��¼�`<add key="AspNetPerformance.EnablePerformanceMonitoring" value="true" />`,trueΪ�򿪼��,falseΪ�رռ��
6. ���г���,�򿪼�ص�ַ[Metrics](http://localhost:1234/).

