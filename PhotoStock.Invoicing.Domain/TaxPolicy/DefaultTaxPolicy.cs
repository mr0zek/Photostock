using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Invoicing.Domain.TaxPolicy
{
  public class DefaultTaxPolicy : ITaxPolicy
  {
    public Tax CalculateTax(ProductType productType, Money net)
    {
      decimal ratio;
      string desc = null;

      switch (productType)
      {
        case ProductType.Printed:
          ratio = (decimal)0.05;
          desc = "5% (D)";
          break;

        case ProductType.Electronic:
          ratio = (decimal)0.23;
          desc = "23%";
          break;

        default:
          throw new ArgumentOutOfRangeException(productType + " not Handled");
      }

      Money tax = net * ratio;

      return new Tax(tax, desc);
    }
  }
}