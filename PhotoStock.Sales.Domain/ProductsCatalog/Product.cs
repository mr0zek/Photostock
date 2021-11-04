using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.ProductsCatalog
{
  public class Product : AggregateRoot
  {
    internal Money Price { get; private set; }

    private string _name;

    private ProductType _productType;

    public Product(AggregateId aggregateId, Money price, String name, ProductType productType)
      : base(aggregateId)
    {
      Price = price;
      _name = name;
      _productType = productType;
    }

    public ProductData GenerateSnapshot()
    {
      return new ProductData(AggregateId, Price, _name, _productType);
    }

    public bool CanBeSold()
    {
      return !IsRemoved();//TODO explore domain rules
    }
  }
}