using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  internal class DiscountPolicy : IDiscountPolicy
  {
    public Discount ApplyDiscount(Product product, Money regularCost, Money totalCost)
    {
      string couse = "";
      Money actualCost = regularCost;
      if (totalCost >= 100)
      {
        couse += "TotalCost >= 100\n";
        actualCost = actualCost - (5.0 / 100 * actualCost);
      }

      return new Discount(couse, actualCost);
    }
  }
}