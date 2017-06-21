using DDD.Base.Domain;
using DDD.Infrastructure;
using NHibernate;

namespace PhotoStock.Sales.Domain.Client
{
  public class ClientRepository : GenericRepository<Client>, IClientRepository
  {
    public ClientRepository(ISession session, IDependencyInjector dependencyInjector) : base(session, dependencyInjector)
    {
    }
  }
}