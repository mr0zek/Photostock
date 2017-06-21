using System;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public class DiscountFactory : IDiscountFactory
  {
    public IDiscountPolicy Create(Client.Client client)
    {
      IDiscountPolicy result = new DiscountPolicy();
      if (DateTime.Today.Month == 12 && DateTime.Today.Day == 24) // Eve
      {
        return new PercentDiscountPolicyDecorator(result, "Eve", 10);
      }
      return result;
    }
  }
}