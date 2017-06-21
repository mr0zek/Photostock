using System;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public class DiscountFactory : IDiscountFactory
  {
    public IDiscountPolicy Create(Client.Client client)
    {
      IDiscountPolicy result = new DiscountPolicy();
      return result;
    }
  }
}