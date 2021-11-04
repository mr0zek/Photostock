using Autofac;

namespace PhotoStock.System
{
  public class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<SystemContext>().AsImplementedInterfaces();
    }
  }
}