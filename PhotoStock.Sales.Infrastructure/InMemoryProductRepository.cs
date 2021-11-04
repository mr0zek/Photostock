using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Infrastructure
{
  public class InMemoryProductRepository : IProductRepository
  {
    static Dictionary<AggregateId, Product> _items = new Dictionary<AggregateId, Product>();

    static InMemoryProductRepository()
    {
      _items.Add("1", new Product("1", 10, "Vincent van Gogh - autoportret", ProductType.Printed));
      _items.Add("2", new Product("2", 10, "Leonardo da Vinci - dama z  łasiczką", ProductType.Printed));
      _items.Add("3", new Product("3", 10, "Salvador Dali - The Temptation of St. Anthony", ProductType.Electronic));
    }

    public Product Get(AggregateId id)
    {
      return _items[id];
    }

    public void Delete(AggregateId id)
    {
      _items.Remove(id);
    }

    public void Save(Product entity)
    {
      _items[entity.AggregateId] = entity;
    }
  }
}