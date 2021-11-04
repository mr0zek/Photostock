using Autofac;
using PhotoStock.Sales.Application;

namespace PhotoStock.Sales.WebApp
{
  internal class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(typeof(ICommandHandler<>).Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();            
    }
  }
}