using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  internal class DiscountPolicy : IDiscountPolicy
  {
    public Discount ApplyDiscount(ProductData product)
    {
      string couse = "";
      Money actualCost = product.Price;
      if (product.Name.Contains("tree") || product.Name.Contains("grass"))
      {
        actualCost -= 1;
        couse += "Contains tree or grass\n";
      }

      return new Discount(couse, actualCost);
    }
  }
}