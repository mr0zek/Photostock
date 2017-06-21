using System.Collections;

namespace DDD.Base.Domain
{
  public interface IGenericRepository<T> where T : AggregateRoot
  {
    T Load(AggregateId id);

    void Delete(AggregateId id);

    void Save(T entity);
  }
}