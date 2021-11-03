using Autofac;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DocFlow.WebApp
{
  public class Bootstrap
  {
    public static IContainer Container { get; internal set; }

    public static void Run(string[] args, Action<ContainerBuilder> builder, int port, string connectionString = null)
    {
      Startup.RegisterExternalTypes = builder;
      ThreadPool.QueueUserWorkItem(starte => CreateWebHostBuilder(args, port, connectionString).Build().Run());
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args, int port, string connectionString)
    {
      KeyValuePair<string, string> kv = new KeyValuePair<string, string>("ConnectionStrings:DefaultConnection", connectionString);
      var c = WebHost.CreateDefaultBuilder(args)
        .UseKestrel(f => f.ListenAnyIP(port))
		.ConfigureLogging(logging =>
        {
          logging.AddConsole();
          logging.AddDebug();
        })
        .UseStartup<Startup>();
      if (connectionString != null)
      {
        c.ConfigureAppConfiguration(conf => conf.AddInMemoryCollection(new[] { kv }));
      }

      return c;
    }
  }
}
