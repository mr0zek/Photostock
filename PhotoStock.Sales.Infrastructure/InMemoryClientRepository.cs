using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Client;

namespace PhotoStock.Sales.Infrastructure
{
  public class InMemoryClientRepository : IClientRepository
  {
    static Dictionary<AggregateId, Client> _clients = new Dictionary<AggregateId, Client>();

    static InMemoryClientRepository()
    {
      _clients.Add("1", new Client("Bugs Bunny", true));
    }

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