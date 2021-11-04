using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;

namespace PhotoStock.Sales.Infrastructure
{
  public class InMemoryPurchaseRepository :IPurchaseRepository
  {
    private static Dictionary<string, Purchase> _items = new Dictionary<string, Purchase>();

    public Purchase Get(AggregateId id)
    {
      return _items[id];
    }

    public void Delete(AggregateId id)
    {
      _items.Remove(id);
    }

    public void Save(Purchase entity)
    {
      _items[entity.AggregateId] = entity;
    }
  }
}