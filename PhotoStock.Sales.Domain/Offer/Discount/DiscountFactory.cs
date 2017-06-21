using System;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public class DiscountFactory : IDiscountFactory
  {
    public IDiscountPolicy Create(Client.Client client)
    {
      IDiscountPolicy treeGrass = new DiscountPolicy();
      if (IsEve()) // Eve
      {
        return new PercentDiscountPolicy(treeGrass, "Eve", 10);
      }
      return treeGrass;
    }

    private bool IsEve()
    {
      return DateTime.Today.Month == 12 && DateTime.Now.Day == 24
    }
  }
}