using DDD.Base.Domain;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Invoicing.Domain
{
  public class Tax : ValueObject
  {
      public Money Amount { get; private set; }
      public string Description { get;  private set; }

    public Tax()
    {
    }

    public Tax(Money amount, String description)
    {
      Amount = amount;
      Description = description;
    }
  }
}