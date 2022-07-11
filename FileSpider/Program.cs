// See https://aka.ms/new-console-template for more information


using FileSpider.Services;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();
service.AddSingleton<IQueueService, QueueService>();
service.AddSingleton<IEndService, EndService>();
service.AddTransient<IFileService, FileService>();
service.AddTransient<IArgumentParser, ArgumentParser>();
service.AddTransient<ILogService, LogService>();
service.AddTransient<IWorkService, WorkService>();
service.AddTransient<ISpiderFileService, SpiderFileService>();

var spiderFileService = service.BuildServiceProvider().GetService<ISpiderFileService>();

spiderFileService?.Run(args);