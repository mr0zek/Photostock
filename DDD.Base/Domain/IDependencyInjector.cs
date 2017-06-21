namespace DDD.Base.Domain
{
  public interface IDependencyInjector
  {
    void InjectDependencies(AggregateRoot aggregateRoot);
  }
}