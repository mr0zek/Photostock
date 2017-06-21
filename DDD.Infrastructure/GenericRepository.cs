using DDD.Base.Domain;
using NHibernate;

namespace DDD.Infrastructure
{
  public abstract class GenericRepository<TAggregateRoot> : IGenericRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
  {
    private readonly IDependencyInjector _dependencyInjector;
    private readonly ISession _session;

    public GenericRepository(ISession session, IDependencyInjector dependencyInjector)
    {
      _session = session;
      _dependencyInjector = dependencyInjector;
    }

    public TAggregateRoot Load(AggregateId id)
    {
      var result = _session.Get<TAggregateRoot>(id);
      if (result == null)
      {
        return null;
      }
      if (result.IsRemoved())
      {
        return null;
      }
      _dependencyInjector.InjectDependencies(result);

      return result;
    }

    public void Save(TAggregateRoot aggregateRoot)
    {
      _session.SaveOrUpdate(aggregateRoot);
    }

    public void Delete(AggregateId id)
    {
      var obj = _session.Get<TAggregateRoot>(id);
      obj.MarkAsRemoved();
      _session.SaveOrUpdate(obj);
    }
  }
}