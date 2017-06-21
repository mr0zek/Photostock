using Castle.Windsor;
using DDD.Base.Domain;
using System.Reflection;

namespace DDD.Infrastructure
{
  public class DependencyInjector : IDependencyInjector
  {
    private readonly IWindsorContainer _container;

    public DependencyInjector(IWindsorContainer container)
    {
      _container = container;
    }

    public void InjectDependencies(AggregateRoot aggregateRoot)
    {
      var fields = aggregateRoot.GetType().GetFields();
      foreach (FieldInfo fieldInfo in fields)
      {
        if (fieldInfo.FieldType.IsInterface)
        {
          object iface = _container.Resolve(fieldInfo.FieldType);
          fieldInfo.SetValue(aggregateRoot, iface);
        }
      }
    }
  }
}