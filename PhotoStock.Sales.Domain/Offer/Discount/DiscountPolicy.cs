using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  internal class DiscountPolicy : IDiscountPolicy
  {
    public Discount GetDiscount(ProductData product, Money regularCost)
    {
      if (product.Name.Contains("tree") || product.Name.Contains("grass"))
      {
        return new Discount("Tree or grass discount", 1);
      }

      return new Discount("no discount", regularCost);           
    }
  }
}