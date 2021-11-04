using System;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PhotoStock.Sales.WebApp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static Action<ContainerBuilder> RegisterExternalTypes { get; set; }

    private void CheckRegistrations(IContainer container)
    {      
      var types = AppDomain.CurrentDomain.GetAssemblies().Where(f => f.ManifestModule.Name.Contains("PhotoStock")).SelectMany(x => x.GetTypes()).ToList();

      foreach (var componentRegistration in container.ComponentRegistry.Registrations)
      {
        foreach (var registrationService in componentRegistration.Services)
        {          
          var registeredTargetType = registrationService.Description;
          var type = GetType(registeredTargetType);          
          if(!types.Contains(type))
          {
            continue;
          }
          if (type == null)
            throw new Exception($"Failed to parse type '{registeredTargetType}'");

          var instance = container.Resolve(type);
          if(instance == null)
            throw new Exception($"Failed to resolve '{type}'");

          if (!componentRegistration.Activator.LimitType.IsInstanceOfType(instance))
            throw new Exception($"Failed to resolve '{type}'");
        }
      }
    }

    private static Type GetType(string typeName)
    {
      var type = Type.GetType(typeName);
      if (type != null) return type;

      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        type = assembly.GetType(typeName);
        if (type != null) return type;
      }
      return null;
    }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
             
      var builder = new ContainerBuilder();      
      builder.RegisterModule(new AutofacModule());
      builder.RegisterModule(new System.AutofacModule());
      builder.RegisterModule(new Application.AutofacModule());
      builder.RegisterModule(new Infrastructure.AutofacModule());
      RegisterExternalTypes(builder);      
      builder.Populate(services);      
      var container = builder.Build();
      CheckRegistrations(container);
      return new AutofacServiceProvider(container);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
