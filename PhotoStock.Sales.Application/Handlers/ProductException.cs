using System;
using DDD.Base.Domain;

namespace PhotoStock.Sales.Application.Handlers
{
  public class ProductException : Exception
  {
    public string ProductCannotBeSold { get; set; }
    public AggregateId ProductId { get; set; }

    public ProductException(string productCannotBeSold, AggregateId productId)
    {
      ProductCannotBeSold = productCannotBeSold;
      ProductId = productId;
    }
  }
}