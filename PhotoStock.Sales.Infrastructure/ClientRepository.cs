using DDD.Base.Domain;
using DDD.Infrastructure;
using PhotoStock.Sales.Domain.Client;
using System.Collections.Generic;

namespace Photostock.Sales.Infrastructure
{
  public class InMemoryClientRepository : IClientRepository
  {
    Dictionary<AggregateId, Client> _clients = new Dictionary<AggregateId, Client>();

    public void Delete(AggregateId id)
    {
      _clients.Remove(id);
    }

    public Client Get(AggregateId id)
    {
      return _clients[id];
    }

    public void Save(Client entity)
    {
      _clients.Add(entity.AggregateId, entity);
    }
  }
}