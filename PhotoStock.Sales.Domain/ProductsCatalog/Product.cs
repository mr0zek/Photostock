using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.ProductsCatalog
{
  public class Product : AggregateRoot
  {
    private Money _price;

    private string _name;

    private ProductType _productType;

    private Product(AggregateId aggregateId, Money price, String name, ProductType productType)
      : base(aggregateId)
    {
      _price = price;
      _name = name;
      _productType = productType;
    }

    public ProductData GenerateSnapshot()
    {
      return new ProductData(AggregateId, _price, _name, _productType);
    }

    public bool CanBeSold()
    {
      return !IsRemoved();//TODO explore domain rules
    }
  }
}