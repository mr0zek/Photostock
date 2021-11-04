using Autofac;
using Autofac.Core;
using CQRS.Base.Command;

namespace DocFlow.WebApp
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