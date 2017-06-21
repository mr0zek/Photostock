using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.ProductsCatalog
{
  public class Product : AggregateRoot
  {
      public Money Price { get; private set; }

      public string Name { get; private set; }

      public ProductType ProductType { get; private set; }

    private Product(AggregateId aggregateId, Money price, String name, ProductType productType)
      : base(aggregateId)
    {
      Price = price;
      Name = name;
      ProductType = productType;
    }

    public ProductData GenerateSnapshot()
    {
      return new ProductData(AggregateId, Price, Name, ProductType);
    }

      public bool CanBeSold()
      {
          return !IsRemoved();//TODO explore domain rules
      }

    }
}